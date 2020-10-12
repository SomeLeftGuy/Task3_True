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
        
        public static bool work = true;

        public static void Main(string[] args)
        {
            RNGCryptoServiceProvider random = new RNGCryptoServiceProvider();
            byte[] keydata = new byte[256];
            HMACSHA256 hmac = new HMACSHA256();
            string key;
            bool work = true;
            int user_choice = 0;
            string[] input = args;
            while (work)
            {
                random.GetBytes(keydata);
                key = Convert.ToBase64String(hmac.ComputeHash(keydata));
                if (input.Length % 2 == 0 || input.Length < 3) { Console.WriteLine("Incorrect input"); work = false; return; }
                Output(input,key);
                user_choice = Convert.ToInt32(Console.ReadLine());
                if (user_choice == 0)
                {
                    break;
                }
                Game(user_choice,input,key);
            }

        }
        
        public static void Output(string[] input,string key)
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
        public static void Game(int user_choice, string[] input, string key)
        {
            RNGCryptoServiceProvider random = new RNGCryptoServiceProvider();
            int computer_choice = 0;
            Random random_true = new Random();
            
            computer_choice = random_true.Next(1, input.Length);
            int win = ( user_choice  - computer_choice) % input.Length-1;
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
