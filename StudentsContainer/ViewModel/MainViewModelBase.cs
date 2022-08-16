using System.Collections.Specialized;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace StudentsContainer
{
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
}