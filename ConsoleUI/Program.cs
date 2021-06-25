using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
         
            Console.WriteLine("Welcome to the Party!!");
            GetUserInfo();
            PrintGuestsName();
            PrintWinner();
            Thread.Sleep(6000);
            MultiLineAnimation();
            


        }

        //Start writing your code here
        private static Dictionary<int, string> guests = new Dictionary<int, string>();

        private static int min = 1000;

        private static int max = 9999;

        private static int raffleNumber;

        private static Random rdm = new Random();

        private static string GetUserInput(string message)
        {
            Console.WriteLine(message);
            string input = Console.ReadLine();

            return input;
        }

        private static void GetUserInfo()
        {
            string guestName;
            

            while (true)
            {

                do
                {
                    guestName = GetUserInput("Please enter the guest name, or type \"exit\": ");
                }
                while (guestName == "" || guests.ContainsValue(guestName));
                         
                if (guestName.ToLower() == "exit")
                {
             
                    break;
                }
                
                do
                { 
                    raffleNumber = GenerateRandomNumber(min, max);
                }
                while (guests.ContainsKey(raffleNumber));

                AddGuestsInRaffle(raffleNumber, guestName);

                foreach (var i in guests)
                {
                    Console.WriteLine(i);
                }

            }                               
        }

        private static int GenerateRandomNumber(int min, int max)
        {
            return rdm.Next(min, max);
        }

        private static void AddGuestsInRaffle(int raffleNumber, string guest)
        {
            guests[raffleNumber] = guest;
        }

        private static void PrintGuestsName()
        {
            foreach(var i in guests)
            {
                Console.WriteLine($"Guest: {i.Value} has raffle number: {i.Key}");
            }
        }

        private static int GetRaffleNumber(Dictionary<int,string> dict)
        {
            int[] dictKeys = dict.Keys.ToArray();
            //int totalGuests = dict.Count();
            int index = rdm.Next(1, dictKeys.Length);
            int winningKey = dictKeys[index];

           // for (int i = 0; i < numIterations + 1; i++)
            //{
               //winningKey = dictKeys[numIterations];

           // }
            return winningKey;            
        }

        private static void PrintWinner()
        {
            int winnerNumber = GetRaffleNumber(guests);
            Console.WriteLine($"The winner is {guests[winnerNumber]}, with number {winnerNumber}");
        }






        static void MultiLineAnimation() // Credit: https://www.michalbialecki.com/2018/05/25/how-to-make-you-console-app-look-cool/
        {
            
            
            
            var counter = 0;
            for (int i = 0; i < 30; i++)
            {
                Console.Clear();

                switch (counter % 4)
                {
                    case 0:
                        {
                            Console.WriteLine("         ╔════╤╤╤╤════╗");
                            Console.WriteLine("         ║    │││ \\   ║");
                            Console.WriteLine("         ║    │││  O  ║");
                            Console.WriteLine("         ║    OOO     ║");
                            break;
                        };
                    case 1:
                        {
                            Console.WriteLine("         ╔════╤╤╤╤════╗");
                            Console.WriteLine("         ║    ││││    ║");
                            Console.WriteLine("         ║    ││││    ║");
                            Console.WriteLine("         ║    OOOO    ║");
                            break;
                        };
                    case 2:
                        {
                            Console.WriteLine("         ╔════╤╤╤╤════╗");
                            Console.WriteLine("         ║   / │││    ║");
                            Console.WriteLine("         ║  O  │││    ║");
                            Console.WriteLine("         ║     OOO    ║");
                            break;
                        };
                    case 3:
                        {
                            Console.WriteLine("         ╔════╤╤╤╤════╗");
                            Console.WriteLine("         ║    ││││    ║");
                            Console.WriteLine("         ║    ││││    ║");
                            Console.WriteLine("         ║    OOOO    ║");
                            break;
                        };
                }

                counter++;
                Thread.Sleep(200);
            }
            
        }
    }
}
