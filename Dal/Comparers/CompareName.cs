using Model;
using System.Collections.Generic;

namespace Dal.Comparers
{
    public class CompareName : IComparer<Student>
    {
        public int Compare(Student x, Student y) => x.FirstName.CompareTo(y.FirstName);
        public override string ToString() => "First-Names [ A - Z ]";
    }
}