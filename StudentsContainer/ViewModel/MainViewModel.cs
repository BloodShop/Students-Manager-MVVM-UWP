﻿using Dal;
using Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Popups;

namespace StudentsContainer
{
    internal class MainViewModel : MainViewModelBase
    {
        StudentContainer _studentContainer = new StudentContainer();
        IEnumerable<Student> _resultStudents = new List<Student>();
        IComparer<Student> _selectedComparer;
        Student _selectedStudent;
        string _resultSpecificStudent;

        public StudentContainer StudentContainer => _studentContainer;
        public List<IComparer<Student>> SortStudent => DataMock.SortStudent;
        public IComparer<Student> SelectedComparer
        {
            get => _selectedComparer;
            set
            {
                _selectedComparer = value;
                IsSearchValid = true;
            }
        }
        public IEnumerable<Student> ResultStudents
        {
            get => _resultStudents;
            private set
            {
                _resultStudents = value;
                RaisePropertyChanged(nameof(ResultStudents));
            }
        }
        public Student SelectedStudent
        {
            get => _selectedStudent;
            set
            {
                _selectedStudent = value;
                if(_selectedStudent != null)
                {
                    UnEditID = _selectedStudent.Id;
                    EditEmail = _selectedStudent.Email;
                    EditGrade = _selectedStudent.FinalGrade;
                    EditPhone = _selectedStudent.PersonalPhoneNum;
                    IsRemoveValid = true;
                }
                else
                {
                    UnEditID = 0;
                    EditEmail = string.Empty;
                    EditGrade = 0;
                    EditPhone = string.Empty;
                    IsRemoveValid = false;
                }
            }
        }
        public string ResultSpecificStudent
        {
            get => _resultSpecificStudent;
            private set
            {
                _resultSpecificStudent = value;
                RaisePropertyChanged(nameof(ResultSpecificStudent));
            }
        }

        #region Props MVVM
        bool _isRemoveValid;
        public bool IsRemoveValid
        {
            get => _isRemoveValid;
            private set
            {
                _isRemoveValid = value;
                RaisePropertyChanged(nameof(IsRemoveValid));
            }
        }
        #region SearchEngine Properties
        bool _isSearchValid;
        public bool IsSearchValid
        {
            get => _isSearchValid;
            private set
            {
                _isSearchValid = value;
                RaisePropertyChanged(nameof(IsSearchValid));
            }
        }
        bool _isSearchSpecificValid;
        public bool IsSearchSpecificValid
        {
            get => _isSearchSpecificValid;
            private set
            {
                _isSearchSpecificValid = value;
                RaisePropertyChanged(nameof(IsSearchSpecificValid));
            }
        }
        string _searchEmail;
        public string SearchEmail
        {
            get => _searchEmail;
            set
            {
                if (IsValidEmail(value))
                {
                    _searchEmail = value;
                    IsSearchSpecificValid = true;
                    RaisePropertyChanged(nameof(SearchEmail));
                }
            }
        }
        #endregion
        #region AddStudent Properties
        string _email;
        int _finalGrade;
        string _personalPhoneNum;
        string _homePhoneNum;
        string _firstName;
        string _lastName;
        uint _id;
        uint _unEditId;

        public uint UnEditID
        {
            get => _unEditId;
            private set
            {
                _unEditId = value;
                RaisePropertyChanged(nameof(UnEditID));
            }
        }
        public uint ID
        {
            get => _id;
            set
            {
                if (IsValidID(value))
                    _id = value;
                //else return;
               
                if (AddCondition()) IsAddValid = true;
                RaisePropertyChanged(nameof(ID));
            }
        }
        public string FirstName
        {
            get => _firstName;
            set
            {
                _firstName = value;
                if (AddCondition()) IsAddValid = true;
                RaisePropertyChanged(nameof(FirstName));
            }
        }
        public string LastName
        {
            get => _lastName;
            set
            {
                _lastName = value;
                if (AddCondition()) IsAddValid = true;
                RaisePropertyChanged(nameof(LastName));
            }
        }
        public string Email
        {
            get => _email;
            set
            {
                if (IsValidEmail(value))
                {
                    _email = value;
                    if (AddCondition()) IsAddValid = true;
                    RaisePropertyChanged(nameof(Email));
                }
                else if (value == null)
                {
                    _email = value;
                    IsAddValid = false;
                    RaisePropertyChanged(nameof(Email));
                }
            }
        }
        public int FinalGrade
        {
            get => _finalGrade;
            set
            {
                if (value > 0 && value <= 100)
                {
                    _finalGrade = value;
                    if (AddCondition()) IsAddValid = true;
                    RaisePropertyChanged(nameof(FinalGrade));
                }

            }
        }
        public string PersonalPhoneNum
        {
            get => _personalPhoneNum;
            set
            {
                if (IsValidPhone(value))
                {
                    _personalPhoneNum = value;
                    if (AddCondition()) IsAddValid = true;
                    RaisePropertyChanged(nameof(PersonalPhoneNum));
                }
            }
        }
        public string HomePhoneNum
        {
            get => _homePhoneNum;
            set
            {
                if (IsValidPhone(value))
                {
                    _homePhoneNum = value;
                    if (AddCondition()) IsAddValid = true;
                    RaisePropertyChanged(nameof(HomePhoneNum));
                }
            }
        }
        bool _isAddValid;
        public bool IsAddValid
        {
            get => _isAddValid;
            private set
            {
                _isAddValid = value;
                RaisePropertyChanged(nameof(IsAddValid));
            }
        }
        bool AddCondition() => _firstName != null && _lastName != null && _email != null &&
            _finalGrade != default && _personalPhoneNum != null && _homePhoneNum != null && _id != default;
        #endregion
        #region Edit Student Props
        bool _isEditValid;
        public bool IsEditValid
        {
            get => _isEditValid;
            set
            {
                _isEditValid = value;
                RaisePropertyChanged(nameof(IsEditValid));
            }
        }

        string _editEmail;
        string _editPhone;
        int _editGrade;
        public string EditEmail
        {
            get => _editEmail;
            set
            {
                if (IsValidEmail(value))
                {
                    _editEmail = value;
                    if (EditStudentCondition()) IsEditValid = true;
                    else IsEditValid = false;
                    RaisePropertyChanged(nameof(EditEmail));
                }
                else
                {
                    _editEmail = string.Empty;
                    IsEditValid = false;
                    RaisePropertyChanged(nameof(EditEmail));
                }
            }
        }
        public string EditPhone
        {
            get => _editPhone;
            set
            {
                if (IsValidPhone(value))
                {
                    _editPhone = value;
                    if (EditStudentCondition()) IsEditValid = true;
                    else IsEditValid = false;
                    RaisePropertyChanged(nameof(EditPhone));
                }
                else
                {
                    _editPhone = string.Empty;
                    IsEditValid = false;
                    RaisePropertyChanged(nameof(EditPhone));
                }
            }
        }
        public int EditGrade
        {
            get => _editGrade;
            set
            {
                if(value >= 0 && value <= 100) _editGrade = value;
                if (EditStudentCondition()) IsEditValid = true;
                else IsEditValid = false;
                RaisePropertyChanged(nameof(EditGrade));
            }

        }
        bool EditStudentCondition() => _selectedStudent != null && _editEmail != null && _editPhone != null && _editGrade >= 0 && _editGrade <= 100;
        #endregion
        #endregion

        public MainViewModel() => ResultStudents = _studentContainer.GetAll();
        
        public ICommand SortCommand => new DelegateCommand(SortStudents);
        public ICommand RemoveCommand => new DelegateCommand(RemoveStudent);
        public ICommand AddCommand => new DelegateCommand(AddStudent);
        public ICommand SearchCommand => new DelegateCommand(SearchStudent);
        public ICommand EditCommand => new DelegateCommand(EditStudent);
        public ICommand SaveCommand => new DelegateCommand(SaveStudents);

        private void EditStudent()
        {
            SelectedStudent.Update(_editEmail, _editPhone, _editGrade);
            ResultStudents = _studentContainer.GetAll();
        }
        async void SearchStudent()
        {
            try
            {
                ResultSpecificStudent = _studentContainer[_searchEmail];
            }
            catch (Exception ex) { await Message(ex.Message, "No Email"); }
        }
        async void AddStudent()
        {
            try
            {
                _studentContainer.Add(new Student(FirstName, LastName, Email, FinalGrade, PersonalPhoneNum, HomePhoneNum, ID));
                ResultStudents = _studentContainer.GetAll();
                IsAddValid = false;
            }
            catch (Exception ex) { await Message(ex.Message, "Person With this unique id already exists"); }
        }
        void RemoveStudent()
        {
            _studentContainer.Remove(SelectedStudent);
            ResultStudents = _studentContainer.GetAll();
        }
        void SortStudents() => ResultStudents = _studentContainer.Sort(SelectedComparer);
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
            catch (Exception) { return false; }
        }
        bool IsValidPhone(string phone) => phone != string.Empty && phone.Length == 10 && phone.Substring(0, 1) == "0";
        bool IsValidID(uint id) => id.ToString().Length == 9/* && !Person.BstPeople.FindValue(id, out Person p)*/;

        async Task Message(string message, string title) => await new MessageDialog(message, title).ShowAsync();
        void SaveStudents() => DataMock.SaveDataBaseJson();
    }
}