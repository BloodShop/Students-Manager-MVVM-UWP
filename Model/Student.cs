using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Student : Person, IFormattable
    {
        string _email;
        int _finalGrade;
        string _personalPhoneNum;
        string _homePhoneNum;

        public string Email
        {
            get => _email;
            private set
            {
                if (IsValidEmail(value))
                    _email = value;
                else _email = "none";
            }
        }
        public int FinalGrade
        {
            get => _finalGrade;
            private set
            {
                if (value >= 0 && value <= 100)
                    _finalGrade = value;
                else
                    _finalGrade = 0;
            }
        }
        public string PersonalPhoneNum
        {
            get => _personalPhoneNum;
            private set
            {
                if (IsValidPhone(value))
                    _personalPhoneNum = value;
                else _personalPhoneNum = "05050505050";
            }
        }
        public string HomePhoneNum
        {
            get => _homePhoneNum;
            private set
            {
                if (IsValidPhone(value))
                    _homePhoneNum = value;
                else _homePhoneNum = "0999999999";
            }
        }

        public Student(string firstName, string lastName, string email, int finalGrade, string personalPhoneNum, string homePhoneNum, int id)
            : base(firstName, lastName, id)
        {
            Email = email;
            FinalGrade = finalGrade;
            PersonalPhoneNum = personalPhoneNum;
            HomePhoneNum = homePhoneNum;
        }

        public void Update(string email, string phoneNum, int grade)
        {
            _email = email;
            _personalPhoneNum = phoneNum;
            _finalGrade = grade;
        }
        public override string ToString() =>
            $"{FirstName} {LastName} {_email} {_finalGrade} {_personalPhoneNum} {_homePhoneNum}";
        public string ToString(string format, IFormatProvider formatProvider)
        {
            switch (format)
            {
                case "s": return LastName;
                default: return ToString();
            }
        }
        bool IsValidEmail(string email)
        {
            try
            {
                var trimmedEmail = email.Trim();

                if (trimmedEmail.EndsWith("."))
                    return false;

                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == trimmedEmail;
            }
            catch(Exception) { return false; }
        }
        bool IsValidPhone(string phone)
        {
            if (phone != string.Empty && phone.Substring(0, 1) == "0" && phone.Length == 10)
                return true;
            return false;
        }
    }
}