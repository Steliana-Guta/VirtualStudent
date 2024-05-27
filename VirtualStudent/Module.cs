using System;
namespace VirtualStudent
{
    public class Module
    {
        private string name;
        public string Name
        {
            get
            {
                return name;
            }
        }

        private int noOfAssignments;
        public int NoOfAssignments
        {
            get
            {
                return noOfAssignments;
            }
        }

        private int credits;
        public int Credits
        {
            get
            {
                return credits;
            }
        }

        // one to many relationship
        private Assignment[] assignments;

        // constructor
        public Module(string name, int noOfAssignments, int credits)
        {
            this.name = name;
            this.noOfAssignments = noOfAssignments;
            this.credits = credits;

            // initialise array
            assignments = new Assignment[noOfAssignments];

            // create assignments
            AddAssignments();
        }

        private void AddAssignments()
        {
            for (int i = 0; i < noOfAssignments; i++)
            {
                try
                {
                    // declare and initialise with new instance
                    // NOTE: this variable will only exist within this for loop
                    Assignment assignment = new Assignment(
                        0, false, 0.5f
                    );

                    assignments[i] = assignment;

                } catch (ArgumentOutOfRangeException e)
                {
                    Console.WriteLine(
                        "Module.AddAssignments: Invalid value '{0}' for '{1}'",
                        e.ActualValue,
                        e.ParamName
                    );
                }
            }
        }

        public void ObtainMarks()
        {
            // loop through each assessment
            for (int i = 0; i < noOfAssignments; i++)
            {
                // access each assignment instance in turn
                Assignment assignment = assignments[i];

                // tell the user which assessment he's dealing with
                Console.WriteLine("Assessment {0}: ", i + 1);

                // run the relevant method
                assignment.ObtainMarks();
            }
        }

        /// <summary>
        /// Calculates the overall module grade
        /// </summary>
        /// <returns>module grade</returns>
        public float GetGrade()
        {
            float grade = 0;

            for (int i = 0; i < noOfAssignments; i++)
            {
                Assignment assignment = assignments[i];

                // add to module grade the weighted assignment grade
                grade += assignment.GetGrade();
            }

            return grade;
        }
    }
}
