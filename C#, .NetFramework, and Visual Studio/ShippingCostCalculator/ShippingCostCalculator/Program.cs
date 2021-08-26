using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingCostCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            //welcomes user and gets the weight of the package
            Console.WriteLine("Welcome to Package Express. Please follow the instructions below.\nHow much does your package weigh?");
            float weight = Convert.ToSingle(Console.ReadLine());

            //checks to see if the wieght is more than 50 or not. If it is, the user is informed that it is too heavy to be shipped. If not, then it moves on and asks for the width.
            if (weight > 50)
            {
                Console.WriteLine("Package too heavy to be shipped via Package Express. Have a good day.");
                Console.ReadLine();
                return;
            }
            else
            {
                Console.WriteLine("What is the width of your package?");

                float width = Convert.ToSingle(Console.ReadLine());

                //asks for the height
                Console.WriteLine("What is the height of your package?");
                float height = Convert.ToSingle(Console.ReadLine());

                //asks for the length
                Console.WriteLine("What is the length of your package?");
                float length = Convert.ToSingle(Console.ReadLine());

                //adds up the 3 dimensions given to see if the total is greater than 50. If it is, the user is informed that it is too big to be shipped. If not, then it lists the final price.
                if ((width + height + length) > 50)
                {
                    Console.WriteLine("Package too big to be shipped via Package Express.");
                    Console.ReadLine();
                    return;
                }
                else
                {
                    //final price is determined by multiplying all dimensions together. Then the product of that is multiplied by the weight. Finally, that product is divided by 100. The quotient is the final quote.
                    Console.WriteLine("Your estimated total for shipping this package is:");
                    float price = ((width * height * length) * weight) / 100;
                    Console.WriteLine("$" + price + "\nThank you!");
                    Console.ReadLine();
                }
               
            }
            

        }
    }
}
