using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Fall2020TestGroup12.etc
{
    public class HelperMethods
    {
        public List<string> GetAllWVUCourses()
        {
            using (var reader = new StreamReader(@"C:\Users\adams\source\repos\Fall2020SolutionGroup12\Fall2020SolutionGroup12\Fall2020AppGroup12\Data\wvu_course_list.csv"))
            {
                List<string> listA = new List<string>();
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(';');

                    listA.Add(values[0]);
                }
                return listA;
            }
        }
    }
}
