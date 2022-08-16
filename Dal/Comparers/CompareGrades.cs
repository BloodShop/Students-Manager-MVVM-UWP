using Model;
using System.Collections.Generic;

namespace Dal.Comparers
{
    public class CompareGradesLow : IComparer<Student>
    {
        public int Compare(Student x, Student y) => x.FinalGrade.CompareTo(y.FinalGrade);
        public override string ToString() => "Grades [ 1 - 100 ]";
    }
}