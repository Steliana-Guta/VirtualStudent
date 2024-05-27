using System;
namespace VirtualStudent
{
    public class Assignment
    {
        private float marks;
        public float Marks
        {
            get
            {
                return marks;
            }
        }

        private bool pass;
        public bool Pass
        {
            get
            {
                return pass;
            }
        }

        private float weighting;
        public float Weighting
        {
            get
            {
                return weighting;
            }
        }

        // constructor
        public Assignment(float marks, bool pass, float weighting)
        {
            // validate input - check marks
            if (!ValidateMarks(marks))
            {
                throw new ArgumentOutOfRangeException("marks", marks, "Invalid Marks value");
            }

            // validate input - check weighting
            if (!ValidateWeighting(weighting))
            {
                throw new ArgumentOutOfRangeException("weighting", weighting, "Invalid Weighting value");
            }

            this.marks = marks;
            this.pass = pass;
            this.weighting = weighting;
        }

        private bool ValidateMarks(float marks)
        {
            return marks >= 0 && marks <= 100;
        }

        private bool ValidateWeighting(float weighting)
        {
            return weighting >= 0 && weighting <= 100;
        }

        public void ObtainMarks()
        {
            // some local variables
            float marks;
            bool allOK;

            // validate input
            do
            {
                Console.Write("Marks: ");
                allOK = float.TryParse(Console.ReadLine(), out marks);

                // wrong input i.e. not a number OR
                // marks are out of bounds i.e. less than 0 or greater than 100
                if (!allOK || marks < 0 || marks > 100)
                {
                    Console.WriteLine("Please only type numbers between 0 and 100. Try again.");
                }

                // repeat as long as wrong input is given
            } while (!allOK);

            // set marks
            this.marks = marks;

            // check marks 
            CheckPass();
        }

        private void CheckPass()
        {
            // check if marks are at least 40 and
            // store the result, boolean, in the Pass property
            pass = (marks >= 30);
        }

        /// <summary>
        /// Calculates weighted assignment grade
        /// </summary>
        /// <returns>weighted grade</returns>
        public float GetGrade()
        {
            // this is the same as writing
            // if (Pass == true)
            // because the if condition needs to ultimately be
            // evaluated to a boolean, which is the same type as "Pass"
            if (Pass)
            {
                return Marks * Weighting;
            }

            return 0.4f * Weighting;
        }
    }
}
