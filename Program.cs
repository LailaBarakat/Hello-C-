using System;
using System.Text;
using System.Reflection;

namespace helloWorld
{
    class Program
    {
        
        public static string DisplayObjectInfo(Object o)
        {
            StringBuilder sb = new StringBuilder();

            // Include the type of the object
            System.Type type = o.GetType();
            sb.Append("Type: " + type.Name);

            // Include information for each Field
            sb.Append("\r\n\r\nFields:");
            System.Reflection.FieldInfo[] fi = type.GetFields();
            if (fi.Length > 0)
            {
                foreach (FieldInfo f in fi)
                {
                    sb.Append("\r\n " + f.ToString() + " = " +
                              f.GetValue(o));
                }
            }
            else
                sb.Append("\r\n None");

            // Include information for each Property
            sb.Append("\r\n\r\nProperties:");
            System.Reflection.PropertyInfo[] pi = type.GetProperties();
            if (pi.Length > 0)
            {
                foreach (PropertyInfo p in pi)
                {
                    sb.Append("\r\n " + p.ToString() + " = " +
                              p.GetValue(o, null));
                }
            }
            else
                sb.Append("\r\n None");

            return sb.ToString();
        }
        
        
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, who are you?");
            string pickName; 
            pickName = Console.ReadLine();
            
            Console.WriteLine("Hello " + pickName + ", how are you?");
            string feeling;
            feeling = Console.ReadLine().ToLower();
            switch (feeling)
            {
                case "good":
                    Console.WriteLine("I feel good as well {0} :)", pickName);
                    break;
                case "bad":
                    Console.WriteLine("Oh..I'm sorry to hear that {0} :(", pickName);
                    break;
                default:
                    Console.WriteLine("I'm not sure what to say now, but I can count to 10... . Look!");
                    
                    for(int i = 1 ; i <= 10 ; i++)
                        Console.Write(i + " ");
                    
                    Console.WriteLine();
                    break;
            }
            
            Console.WriteLine("What year were you born in?");
            string year = Console.ReadLine();
            Console.WriteLine("What month were you born in? (As a number, eg: January would be 1)");
            string month = Console.ReadLine();
            Console.WriteLine("What day were you born in? (As a number, eg: 10)");
            string day = Console.ReadLine();

            DateTime birthDate = new DateTime(Int32.Parse(year), Int32.Parse(month), Int32.Parse(day));
            DateTime todayDate = DateTime.Today;

            TimeSpan dateDiffs = todayDate - birthDate;
            Console.WriteLine(DisplayObjectInfo(dateDiffs));
            int age = dateDiffs.Days / 365;
            
            Console.WriteLine("Thank you for this information! It means today you are {0} years old! Amazing!", age.ToString());
            Console.WriteLine();
            
            Console.WriteLine("Let's play a game! I have a number in mind between 1 and 100, and you try and guess it. I'll let you know if you guessed too high or too low!");
            
            Random rnd = new Random();
            int number  = rnd.Next(1, 100);
            int guess = 0;
            do
            {
                Console.WriteLine("What's your guess?");
                guess = Int32.Parse(Console.ReadLine());
                if (guess > number)
                    Console.WriteLine("Lower!");
                else if (guess < number)
                    Console.WriteLine("Higher!");
            } while (guess != number);
            
            Console.WriteLine("Congrats! You guessed it!");

        }
    }
}
