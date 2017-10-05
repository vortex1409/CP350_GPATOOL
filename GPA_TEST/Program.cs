using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Microsoft.VisualBasic.FileIO;

/*
 * MICHAEL DORFMAN
 * PROOF OF CONCEPT DESIGN
 * CONFEDERATION COLLEGE
 * COMPUTER PROGRAMMER GRAD GPA CALCULATOR
 * WORK IN PROGRESS - DO NOT COPY
*/

namespace GPA_TEST
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "GPA Tool";

            // Create Lists
            List<double> Grades = new List<double>();
            List<double> MinGrades = new List<double>();
            
            // Random Number Generator
            Random rnd = new Random();

            // Declare Variables
            int tmp = 0;
            int TempQualityPoints = 0;
            int TotalCourseHours = 0;
            int TempGPA = 0;
            double YearOneGPA = 0;

            // Loop - Loops 14 times
            // During Loop the Quality Points, Course Hours and GPA are Calculated
            for(int i = 0; i < 13; i++)
            {
                // Generate Percentage Grade
                tmp = rnd.Next(50, 100);

                if (tmp < 50)
                {
                    TempGPA = 0;
                    TempQualityPoints = TempQualityPoints + (TempGPA * 45);
                    TotalCourseHours = TotalCourseHours + 45;
                }
                else if (tmp >= 50 && tmp <= 59.9)
                {
                    TempGPA = 1;
                    TempQualityPoints = TempQualityPoints + (TempGPA * 45);
                    TotalCourseHours = TotalCourseHours + 45;
                }
                else if (tmp >= 60 && tmp <= 69.9)
                {
                    TempGPA = 2;
                    TempQualityPoints = TempQualityPoints + (TempGPA * 45);
                    TotalCourseHours = TotalCourseHours + 45;
                }
                else if (tmp >= 70 && tmp <= 79.9)
                {
                    TempGPA = 3;
                    TempQualityPoints = TempQualityPoints + (TempGPA * 45);
                    TotalCourseHours = TotalCourseHours + 45;
                }
                else if (tmp >= 80 && tmp <= 100)
                {
                    TempGPA = 4;
                    TempQualityPoints = TempQualityPoints + (TempGPA * 45);
                    TotalCourseHours = TotalCourseHours + 45;
                }

                Grades.Add(TempGPA);
            }

            // Adds special grade for Math
            //Quality Points, Course Hours and GPA are Calculated
            Grades.Add(rnd.Next(2,4));
            TempQualityPoints = TempQualityPoints + (3 * 60);
            TotalCourseHours = TotalCourseHours + 60;
            YearOneGPA = TempQualityPoints / TotalCourseHours;

            // Assigns Year 1 Data to Year 2 Data
            double Y2QualityPoints = TempQualityPoints;
            double Y2TotalHours = TotalCourseHours;
            double Y2GPA = YearOneGPA;

            int count = 0;

            // While the Year 1 GPA is Less than 2
            while (YearOneGPA < 2)
            {
                // During the first filling of the list start with the GPA of 1 (50%)
                // Then Calculate the GPA
                if (MinGrades.Count != 13)
                {
                    MinGrades.Add(1);
                    Y2QualityPoints = Y2QualityPoints + (1 * 45);
                    Y2TotalHours = Y2TotalHours + 45;
                    Y2GPA = Y2QualityPoints / Y2TotalHours;
                }
                // After looping through the list once we must now 
                // increment each list value by one and check GPA
                else
                {
                    if (count > 12)
                    {
                        count = 0;
                    }
                    MinGrades[count] = MinGrades[count] + 1;
                    Y2QualityPoints = Y2QualityPoints + (MinGrades[count] * 45);
                    Y2TotalHours = Y2TotalHours + 45;
                    Y2GPA = Y2QualityPoints / Y2TotalHours;
                    count++;
                }
            }

            // Reset Counter
            count = 0;

            // While Year 1 GPA is Greater than or Equal to 2
            while(YearOneGPA >= 2) 
            {
                // During the first filling of the list start with the GPA of 1 (50%)
                // Then Calculate the GPA
                if (MinGrades.Count != 13)
                {
                    MinGrades.Add(1);
                    Y2QualityPoints = Y2QualityPoints + (1 * 45);
                    Y2TotalHours = Y2TotalHours + 45;
                    Y2GPA = Y2QualityPoints / Y2TotalHours;
                }
                // After looping through the list once we must now 
                // increment each list value by one and check GPA
                else
                {
                    if (count > 12)
                    {
                        count = 0;
                    }
                    MinGrades[count] = MinGrades[count] + 1;
                    Y2QualityPoints = Y2QualityPoints + (MinGrades[count] * 45);
                    Y2TotalHours = Y2TotalHours + 45;
                    Y2GPA = Y2QualityPoints / Y2TotalHours;
                    count++;
                }
                // If the Year 2 GPA is 2 or greater and the list of grades is equal to 13 (Full)
                // then break the loop
                if(Y2GPA >= 2 && MinGrades.Count == 13)
                {
                    break;
                }
            }

            // Create Data Strings
            string Y1data = "";
            string Y2data = "";
            string C1data = "";

            // Fill Year 1 Data String with Grades
            foreach (double Y1 in Grades)
            {
                Y1data += Y1 + " ";
            }

            // Fill Year 2 Data String with Minimum Passing Grades
            foreach (double Y2 in MinGrades)
            {
                Y2data += Y2 + " ";
            }

            
            // Output Data
            Console.WriteLine("Year 1 Data");
            Console.WriteLine("Y1 GPA: " + YearOneGPA.ToString("0.##") + " Quality Points: " + TempQualityPoints + " Total Course Hours: " + TotalCourseHours);
            Console.WriteLine(Y1data);
            Console.WriteLine("");
            Console.WriteLine("Year 2 Minimum Graduating Data");
            Console.WriteLine("Y2 GPA: " + Y2GPA.ToString("0") + " Quality Points: " + Y2QualityPoints + " Total Course Hours: " + Y2TotalHours);
            Console.WriteLine(Y2data);

            // List that Holds GPA String Line
            List<double> _GPA = new List<double>();

            // Declaring Variables
            string line = "";
            double QP = 0;
            int _count = 0;
            double Y3GPA = 0;
            double HRS = 0;
            
            //Creating StreamReader Object to read all Combinations of Grades (Repeating Allowed)
            StreamReader reader = new StreamReader(@"combos.txt");

            // While the Current Line is Not Null (Empty)
            while ((line = reader.ReadLine()) != null)
            {
                // Reset Variables
                _GPA.Clear();
                count = 0;

                // Add Each Value to a string array from file
                string[] combination = line.Split(',');

                // For each value in array convert it to a double (floating point number)
                // and add it to a list
                foreach(string i in combination)
                {
                    _GPA.Add(Convert.ToDouble(i));
                }

                // For each item in the list calculate total quality points
                // and course hours and GPA
                for(int i = 0; i < 13; i++)
                {
                    QP = QP + (_GPA[i] * 45);
                    HRS = HRS + 45;
                    Y3GPA = QP / HRS;
                }

                // If the Quality points of the current grade list is
                // greater than the starting quality points that is a graduating set of data
                // and write it to screen for the user to see with the GPA
                if(QP >= Y2QualityPoints)
                {
                    // Prep data string for output
                    foreach (double C1 in _GPA)
                    {
                        C1data += C1 + " ";
                    }

                    // Output Data
                    Console.WriteLine(QP + " | " + Y2QualityPoints + " 2nd Year Line GPA: " + Y3GPA.ToString("0.00"));
                    Console.WriteLine(C1data + "\n");

                    // Reset Values
                    C1data = "";
                    QP = 0;
                    HRS = 0;
                    Y3GPA = 0;
                    _count++;
                }
            }

            Console.WriteLine("COUNT:" + _count);
            Console.ReadKey();
        }

        public static int TypeSelection(int type)
        {
            if(type == 0)
            {
                return 0;
            }
            else if(type == 1)
            {
                return 1;
            }
            else
            {
                return 2;
            }
        }

        public static int Num(double GPA)
        {
            if (GPA < 50)
            {
                return 0;
            }
            else if (GPA >= 50 && GPA <= 59.9)
            {
                return 1;
            }
            else if (GPA >= 60 && GPA <= 69.9)
            {
                return 2;
            }
            else if (GPA >= 70 && GPA <= 79.9)
            {
                return 3;
            }
            else if (GPA >= 80 && GPA <= 100)
            {
                return 4;
            }
            else
            {
                return 0;
            }
        }

        public static double CalcGPA(double QualityPoints, double Hours)
        {
            return QualityPoints / Hours;
        }

        public static double GradeConverter(int Switcher, double Percentage)
        {
            if (Percentage < 50)
            {
                return 0;
            }
            else if (Percentage >= 50 && Percentage <= 59.9)
            {
                return 1;
            }
            else if (Percentage >= 60 && Percentage <= 69.9)
            {
                return 2;
            }
            else if (Percentage >= 70 && Percentage <= 79.9)
            {
                return 3;
            }
            else if (Percentage >= 80 && Percentage <= 100)
            {
                return 4;
            }
            else
            {
                return 0;
            }
        }

        public static void DataOutput(int Year, List<Double> Data, double GPA, double QualityPoints, double Hours)
        {
            Console.WriteLine("Year " + Year + " Data");

            string Odata = "";
            foreach (double O in Data)
            {
                Odata += O + " ";
            }
            Console.WriteLine("GPA: " + GPA.ToString("0.##") + " Quality Points: " + QualityPoints + " Total Course Hours: " + Hours);
            Console.WriteLine(Odata);
        }
    }
}
