    using System;
namespace VirtualStudent
{
    public class Student
    {
        // constant
        private const int NO_OF_MODULES = 4;

        private string name;
        public string Name // read-only property
        {
            get
            {
                return name;
            }
        }

        public float Grade // read-only property
        {
            get
            {
                float grade = 0;
                int credits = 0;

                for (int i = 0; i < NO_OF_MODULES; i++)
                {
                    Module module = modules[i];

                    // calculate sum of all credit-weighted grades
                    grade += module.GetGrade() * module.Credits;
                    // calculate sum of all credits
                    credits += module.Credits;
                }

                // final result
                return grade / credits;
            }
        }

        // one to many relationship
        private Module[] modules;

        public Student(string name)
        {
            // "this" keyword is needed to differentiate between
            // the attribute "name" and the constructor parameter
            // with the same title
            this.name = name;

            // initialise array
            modules = new Module[NO_OF_MODULES];

            // create a set of modules for this student
            AddModules();
        }

        private void AddModules()
        {
            // reusable variable
            Module module;

            // create a new module instance
            module = new Module(
                "Introduction to Programming", 2, 30
            );
            // add it to the array
            modules[0] = module;

            // create a new module instance
            module = new Module(
                "Fundamentals of Design", 1, 30
            );
            // add it to the array
            modules[1] = module;

            // create a new module instance
            module = new Module(
                "Computer Systems", 2, 30
            );
            modules[2] = module;
            // add it to the array

            // create a new module instance
            module = new Module(
                "Core Mathematics", 2, 15
            );
            // add it to the array
            modules[3] = module;
        }

        public void ObtainMarks()
        {
            for (int i = 0; i < NO_OF_MODULES; i++)
            {
                Module module = modules[i];

                Console.WriteLine(
                    "Module: {0} ({1} credits)",
                    module.Name,
                    module.Credits
                );

                module.ObtainMarks();

                Console.WriteLine();
            }
        }
    }
}
