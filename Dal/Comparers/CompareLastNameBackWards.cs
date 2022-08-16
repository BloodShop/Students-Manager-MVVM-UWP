using Model;
using System.Collections.Generic;

namespace Dal.Comparers
{
    public class CompareLastNameBackWards : IComparer<Student>
    {
        public int Compare(Student x, Student y) => y.LastName.CompareTo(x.LastName);
        public override string ToString() => "Last-Names [ Z - A ]";
    }
}