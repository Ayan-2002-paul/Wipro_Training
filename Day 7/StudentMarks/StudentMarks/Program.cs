using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentMarks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Creating an instance of the class that contains the indexer
            StudentMarks myStudents = new StudentMarks();

            myStudents[0] = 90;
            myStudents[1] = 100;
            myStudents[2] = 200;
            myStudents[3] = 160;

            Console.WriteLine("student marks are ");

            Console.WriteLine(myStudents[0]);
            Console.WriteLine(myStudents[1]);
            Console.WriteLine(myStudents[2]);
            Console.WriteLine(myStudents[3]);

        }
    }

    class StudentMarks
    {
        private int[] marks = new int[5];

        public int this[int index]
        {
            get
            {
                // Return the value from the internal array
                return marks[index];
            }
            set
            {
                // 'value' is a keyword representing the data being assigned
                marks[index] = value;
            }
        }
    }
}
