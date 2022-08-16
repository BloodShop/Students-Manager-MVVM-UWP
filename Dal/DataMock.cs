using Dal.Comparers;
using Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace Dal
{
    public class DataMock
    {
        static Dictionary<int, Student> _students;

        private static readonly object _lock = new object();
        public static List<IComparer<Student>> SortStudent { get; private set; }
        public Dictionary<int, Student> Students { get => _students; }


        public static int UniqueSeed = 100;
        static DataMock _instance;
        public static DataMock Instance
        {
            get
            {
                lock (_lock)
                {
                    if (_instance == null)
                        //_instance = new DataMock();
                        InitDataBaseJson();
                }
                return _instance;
            }
        }
        static DataMock() =>
           SortStudent = new List<IComparer<Student>>()
           {
                new CompareGradesLow(),
                new CompareGradesHigh(),
                new CompareLastName(),
                new CompareLastNameBackWards(),
                new CompareName(),
               // Can add as many sorting criterias
           };

        DataMock() => init();
        void init() // An initialization without Configuration file
        {
            if (_students != null) return;

            List<Student> temp = new List<Student>();
            temp.Add(new Student("Alon", "Kolyakov", "koliakovcr7@gmail.com", 99, "0503901000", "0777777777"));
            temp.Add(new Student("Dani", "Rebolo", "Dani123@gmail.com", 87, "0503901001", "0777777777"));
            temp.Add(new Student("Ronen", "Loyef", "Singleton@gmail.com", 76, "0503901002", "0777777777"));

            _students = new Dictionary<int, Student>();
            foreach (var std in temp)
                _students.Add(UniqueSeed++, std);
        }

        // My pc doesn't have access to write any text in files you probably would have
        public static void SaveDataBaseJson()
        {
            try
            {
                string json = JsonConvert.SerializeObject(_students);
                var configPath = Path.Combine(Environment.CurrentDirectory, "TextFiles\\DataBase.json"); // ms-appx:///
                File.WriteAllText(configPath, json);
            }
            catch (Exception) { }
        }
        static void InitDataBaseJson()
        {
            try
            {
                string configPath = Path.Combine(Environment.CurrentDirectory, "TextFiles\\DataBase.json");
                string raw = File.ReadAllText(configPath);
                if (raw != null) _students = JsonConvert.DeserializeObject<Dictionary<int, Student>>(raw);

            }
            catch (Exception) { }
            _instance = new DataMock();
        }
    }
}