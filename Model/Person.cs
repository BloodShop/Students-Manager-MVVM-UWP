using System;

namespace Model
{
    public class Person
    {
        public static BSTree<uint, Person> BstPeople { get; private set; } = new BSTree<uint, Person>();

        uint _id;
        string _firstName;
        string _lastName;

        public uint Id
        {
            get => _id;
            private set
            {
                if (BstPeople.FindValue(value, out Person p))
                    throw new Exception("ID already exists in out system");
                _id = value;
                BstPeople.Add(Id, this);
            }
        }
        public string FirstName => _firstName;
        public string LastName => _lastName;
        public Person(string firstName, string lastName, uint id)
        {
            _firstName = firstName;
            _lastName = lastName;
            Id = id;
        }
    }
}