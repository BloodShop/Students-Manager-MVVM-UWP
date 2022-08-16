using Model;
using System.Collections.Generic;

namespace Dal.Comparers
{
    public class CompareGradesHigh : IComparer<Student>
    {
        public int Compare(Student x, Student y) => y.FinalGrade.CompareTo(x.FinalGrade);
        public override string ToString() => "Grades [ 100 - 1 ]";
    }
}