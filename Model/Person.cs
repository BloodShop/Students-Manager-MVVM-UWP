namespace Model
{
    public class Person
    {
        static int seed = 1;

        int _id;
        string _firstName;
        string _lastName;
        public int Id => _id;
        public string FirstName => _firstName;
        public string LastName => _lastName;
        public Person(string firstName, string lastName)
        {
            _firstName = firstName;
            _lastName = lastName;
            _id = seed++;
        }
    }
}