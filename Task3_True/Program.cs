using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.Cryptography;
using System.ComponentModel.Design;
using System.ComponentModel;

namespace Task3_True
{
    class Program
    {
        public static string[] input = Console.ReadLine().Split();
        public static bool work = true;

        public static void Main(string[] args)
        {

            bool work = true;
            int user_choice = 0;

            while (work)
            {
                if (input.Length % 2 == 0 || input.Length < 3) { Console.WriteLine("Incorrect input"); work = false; return; }
                Output(input);
                user_choice = Convert.ToInt32(Console.ReadLine());
                if (user_choice == 0)
                {
                    break;
                }
                Game(user_choice);
            }

        }
        public static void Output(string[] input)
        {
            int count = 0;

            Console.WriteLine("Menu");
            for (int i = 0; i < input.Length; i++)
            {
                count = i + 1;
                Console.WriteLine(count + "." + input[i]);
            }
            Console.WriteLine("Input 0 for exit");
            return;
        }
        public static void Game(int user_choice)
        {
            RNGCryptoServiceProvider random = new RNGCryptoServiceProvider();
            int computer_choice = 0;
            Random random_true = new Random();
            byte[] keydata = new byte[256];
            HMACSHA256 hmac = new HMACSHA256();
            random.GetBytes(keydata);
            string key = Convert.ToBase64String(hmac.ComputeHash(keydata));
            computer_choice = random_true.Next(1, input.Length);
            int win = (input.Length + (user_choice - 1) - computer_choice) % input.Length;
           if (win == 0)
            {
                Console.WriteLine("Draw!" + "Computer choose:" + input[computer_choice] + " HMAC:" + key);
            }
           else if (win%2==1)
            {
                Console.WriteLine("Computer win!" + "Computer choose:" + input[computer_choice] + " HMAC:" + key); 
            }
            else
            {
                Console.WriteLine("User win!" + "Computer choose:" + input[computer_choice] + " HMAC:" + key);
            }
  
        }
    }
}
