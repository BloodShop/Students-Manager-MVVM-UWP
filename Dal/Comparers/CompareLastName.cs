using Model;
using System.Collections.Generic;

namespace Dal.Comparers
{
    public class CompareLastName : IComparer<Student>
    {
        public int Compare(Student x, Student y) => x.LastName.CompareTo(y.LastName);
        public override string ToString() => "Last-Names [ A - Z ]";
    }
}