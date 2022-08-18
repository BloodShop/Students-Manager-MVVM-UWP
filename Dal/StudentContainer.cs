using Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Dal
{
    public class StudentContainer : IEnumerable, IRepository<Student>
    {
        readonly DataMock _data = DataMock.Instance;
        uint uniqueSeed = DataMock.UniqueSeed;

        public Student this[uint id]
        {
            get
            {
                var std = _data.Students.FirstOrDefault(x => x.Key == id).Value;
                if (std == null)
                    throw new Exception($"ID {id} doesnt exist in our lists...");
                return std;
            }
        }
        public string this[string email]
        {
            get
            {
                string phoneNum;
                try
                {
                    phoneNum = _data.Students.FirstOrDefault(x => x.Value.Email == email).Value.PersonalPhoneNum;
                }
                catch (Exception) { throw new Exception($"Email: {email} doesnt exist in our lists..."); }
                return phoneNum;
            }
        }

        public List<Student> Sort(IComparer<Student> comparison)
        {
            List<Student> temp = GetAll().ToList();
            temp.Sort(comparison);
            return temp;
        }
        public void Add(Student student)
        {
            if (student != null && !_data.Students.ContainsValue(student))
                _data.Students.Add(uniqueSeed++, student);
        }
        public void Remove(Student student)
        {
            if (student != null && _data.Students.ContainsValue(student))
            {
                var keyValuePair = _data.Students.First(kvp => kvp.Value == student);
                _data.Students.Remove(keyValuePair.Key);
            }
        }
        public Student Update(Student old, Student @new)
        {
            if (@new != null && old != null)
            {
                _data.Students.Remove(old.Id);
                _data.Students.Add(@new.Id, @new);
            }
            return @new;
        }
        public IQueryable<Student> GetAll() => _data.Students.Values.AsQueryable();
        public IEnumerator GetEnumerator()
        {
            // instead of writing CustomerEnum
            foreach (var std in _data.Students)
                yield return std;
        }
    }
}