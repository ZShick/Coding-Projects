using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncomeComparison
{
    class Program
    {
        static void Main(string[] args)
        {
            //Income Comparison program.
            //Gathers the necessary information from Person 1 and converts the data into the correct type to be able to manipulate it with the correct operations.
            Console.WriteLine("Anonymous Income Comparison Program\nPerson 1\nWhat is Person 1's hourly rate of pay? \"##:##\" format please.");
            string hourRatePerson1 = Console.ReadLine();
            double HRP1 = Convert.ToDouble(hourRatePerson1);
            Console.WriteLine("How many hours does Person 1 work a week?");
            string hourPerWeekPerson1 = Console.ReadLine();
            double HPWP1 = Convert.ToDouble(hourPerWeekPerson1);

            //Same as above but for Person 2.
            Console.WriteLine("What is Person 2's hourly rate of pay? \"##:##\" format please.");
            string hourRatePerson2 = Console.ReadLine();
            double HRP2 = Convert.ToDouble(hourRatePerson2);
            Console.WriteLine("How many hours does Person 2 work a week?");
            string hourPerWeekPerson2 = Console.ReadLine();
            double HPWP2 = Convert.ToDouble(hourPerWeekPerson2);

            //Creating new variables that have the Annual Salary of each person based on what they entered above and then reflecting such in the Console.
            double Salary1 = HRP1 * HPWP1 * 52;
            double Salary2 = HRP2 * HPWP2 * 52;
            Console.WriteLine("Annual salary of Person 1:\n" + Salary1);
            Console.WriteLine("Annual salary of Person 2:\n" + Salary2);

            //Creating a boolean variable that compares Salary 1 with Salary 2 and tells the user if it is true or false that Person 1 makes more a year. Converts the bool to string as well.
            bool P1moreThanP2 = Salary1 > Salary2;
            string P1MTP2 = Convert.ToString(P1moreThanP2);
            Console.WriteLine("Does Person 1 make more money than Person 2?\n" + P1MTP2);
            Console.ReadLine();

        }
    }
}
