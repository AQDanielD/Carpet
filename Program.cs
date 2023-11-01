using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Carpet
{
    internal class Program
    {
        public struct order
        {
            public string fname;
            public string sname;
            public decimal length;
            public string colour;
            public int choice;
            public string carpet;
            public decimal price;

        }


        public static string Choice(int choice)
        {
            switch(choice)
            {
                case 1:
                    return "Wool";
                case 2:
                    return "Artificial Fibre";
                case 3:
                    return "Mixed";
            }
            return " ";
        }

        public static string Carpet()
        {
            Console.WriteLine("Options for carpet:\n" +
    "1 - Wool (£42.99 per square metre)\n" +
    "2 - Artificial fibre (£18.99 per square metre)\n" +
    "3 - Mixed (£28.99 per square meter)");

            int count = 0;
            int choice = 0;
            while ((choice < 1 || choice > 3) && count < 3)
            {
                count++;
                try
                {
                    Console.Write("Enter your option: ");
                    choice = int.Parse(Console.ReadLine());

                }
                catch
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Please enter a valid option");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
            if (count == 3)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Failed to enter valid option, the deafult Woof has been seletected.");
                Console.ForegroundColor = ConsoleColor.Black;
                user.choice = 1;
            }



            else
            {
                Console.WriteLine($"You have selected {choice}");
                user.choice = choice;
            }

            Console.Write("Colour: "); string colour = Console.ReadLine(); user.colour = colour;

            Console.WriteLine("The carpet comes in widths of 4m");


            decimal length = 0;
            count = 0;
            bool flag = false;
            while (count != 3&&flag == false)
            {
                count++;
                try
                {
                    Console.Write("Please enter the length of which you would like: ");
                    length = decimal.Parse(Console.ReadLine());
                    flag = true;
                }
                catch
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Please enter a valid option");
                    Console.ForegroundColor = ConsoleColor.White;
                    flag = false;
                }
            }
            user.length = length;
            user.carpet = Choice(choice);
            Console.WriteLine($"You have selected {user.carpet} in {user.colour} at 4mx{user.length}m" +
                $"\nWould you like to continue (press y for yes and anyother key to go back to main menu)");
            string proceed = Console.ReadLine();
            double price = 0.0;
            if(choice == 1)
            {
                price = 42.99;
            }
            if (choice == 2)
            {
                price = 18.99;
            }
            if (choice == 3)
            {
                price = 28.99;
            }
            user.price = user.length * 4 * price;
            return proceed.ToLower();

        }
        public static order user = new order();

        static void Main(string[] args)
        {
            

                            Console.Write("Name: "); string name = Console.ReadLine().trim();

            if(name.Contains(" "))
            {
                int space = name.IndexOf(" ");
                user.fname = name.Substring(0,space);
                user.sname = name.Substring(space + 1);
            }
            else 
            {
                Console.Write("Second Name: "); string sname = Console.ReadLine();
                user.fname = name;
                user.sname = sname;
            }
            string result = "n";
            while(result != "y")
            {
                result = Carpet();
            }

            Console.WriteLine($"Receipt------" +
                              $"{user.colour} {user.carpet}-----" +
                              $"Price : {user.price}");
            StreamWriter sw = new StreamWriter("Orders.txt",flase);
            sw.write($"[{user.fname}, {user.lname}, {user.colour}, {user.carpet}, {carpet.length}, {user.price}]");
            sw.Close();


        }
    }
}
