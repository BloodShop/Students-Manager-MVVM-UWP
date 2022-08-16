# StudentsContainer
Simple application used to manage a list of candidates for studies, The manager class is able to Add, Remove, Get, Update students.
This class Inhertice from `IEnumrable` and `IRepository<T>`.
  
## MVVM Project devided to three parts
1. Model (Student / Person, Configuration, StudentsManager...)
  > Sudents manager class which organizes all the students and is able to Update, Get, Add, Remove any student and a sorting function which sort the whole Students to the UI.
  https://github.com/BloodShop/StudentsContainer/blob/9ca4a21b3c5ff05dbfa45f0444a668f2a192d66a/Dal/StudentContainer.cs#L41-L76
2. View (XAML)
<p align="center"> Running application - Manger page contains Search, Add, Sort and etc.. </p>
<p align="center">
  <img height="430"  src="https://user-images.githubusercontent.com/23366804/184883041-587ab0e7-4de3-4286-92d2-93debc6c5014.jpeg">
</p>

3. View-Model (MainView model)
```javascript
public class MainViewModelBase : INotifyPropertyChanged, INotifyCollectionChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public event NotifyCollectionChangedEventHandler CollectionChanged;
        event PropertyChangedEventHandler INotifyPropertyChanged.PropertyChanged
        {
            add { this.PropertyChanged += value; }
            remove { this.PropertyChanged -= value; }
        }
        protected virtual void RaisePropertyChanged([CallerMemberName] string propertyName = "")
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        public virtual void RaiseCollectionChanged(NotifyCollectionChangedEventArgs e) => this.CollectionChanged?.Invoke(this, e);
        public virtual void RaisePropertyChanged(PropertyChangedEventArgs e) => this.PropertyChanged?.Invoke(this, e);
    }
```
  
 ## Sorting Comparers
 > A sorting comparer allows the manager to select any kind of sort and display the results. Sorting comparers are delegates which the manager selects and passes it to the `StudentsContainer` class.
  https://github.com/BloodShop/StudentsContainer/blob/9ca4a21b3c5ff05dbfa45f0444a668f2a192d66a/Dal/Comparers/CompareGradesHigh.cs#L6-L10
