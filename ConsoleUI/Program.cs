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

        private static Dictionary<int,string> guests = new Dictionary<int, string>();
        private static int min = 1000;
        private static int max = 9999;
        private static int raffleNumber;
        private static Random rdm = new Random();
        static void Main(string[] args)
        {
            
            Console.WriteLine("Welcome to the Party!!");
            GetUserInfo();
            PrintGuestsName();
            // GetRaffleNumber(guests);
            PrintWinner();
            Console.WriteLine("Press enter to continue");
            Console.ReadLine();
            MultiLineAnimation();


        }

        //Start writing your code here

        static string GetUserInput (string message)
        {
            Console.WriteLine(message);
            string userInput = Console.ReadLine();
            return userInput;
        }

        // 2) Loop that asks for name. Then call GenerateRandomNumber and store it in the raffle number.
        //Validate input. Keep asking for the guest's name if user enter an empty string
        //Same thing for your random number, validate the data. You can't have the same raffleNumber. You can use a loop to keep calling GenerateRandomNumber() method.
        //Add both the raffleNumber and guest name in the dictionary by calling AddGuestsInRaffle() method (see description below)
        static void GetUserInfo()
        {
            string otherGuest;
            string name;
            do
            {         
            //while guestname is null               
            
             
            // Console.WriteLine(name);
             while (true)
                {
                    name = GetUserInput("Please enter your name \n");
                    if (string.IsNullOrEmpty(name))
                    {
                    Console.WriteLine("string is null or empty");
                    Console.WriteLine(name);
                    }

                    else
                    {
                        break;
                    }
                }             


             otherGuest = GetUserInput("Do you want to add another name? \n ").ToLower();             

             raffleNumber = GenerateRandomNumber(min,max);                           
             AddGuestsInRaffle(raffleNumber,name);
             name = otherGuest;
             
            while(guests.Keys.Contains(raffleNumber))
                {
                    raffleNumber = GenerateRandomNumber(min,max);
                }
             
            } while(otherGuest == "yes" || otherGuest == "y"); 
             
            
        }

        //3) Create a method that returns an integer. takes 2 parameters, returns random integer between min and max
        static int GenerateRandomNumber(int min, int max)
        {
            
            //raffleNumber = 
            return rdm.Next(min,max);
        }

        // 4) Create a method that returns nothing, this method take 2 parameters. Adds the raffleNumber and the guest name that you collect from the user
        // and store them in the guests dictonary that I created.
        static void AddGuestsInRaffle(int raffleNumber, string guest)
        {
            
                guests.Add(raffleNumber,guest);
            
        }

        //5) Use a  loop to print the name of all your guests with their assigned raffleNumber
        static void PrintGuestsName()
        {
            foreach(var d in guests)
            {

            Console.WriteLine($"{d.Value} =========>   {d.Key} ");
            }

        }

        //6 This takes a Dictionary as parameters.  Allows you to get random key from the dictionary and return it as the winner number.
        static int GetRaffleNumber(Dictionary<int,string> people)
        {
            List<int> raffleNum = new List<int>(guests.Keys);

            int randomRaffle = raffleNum[rdm.Next(raffleNum.Count)];

            return randomRaffle;

           // foreach(int d in raffleNum)
            //{
            //    Console.WriteLine(d);
            //}
            
     
        }


        //7 prints the name of the winner and the raffle Number
        // You should be able to call the GetRaffleNumber(). method and store it in an int variable named winnerNumber
        // You should be able to get the winnerName once you have the winnerNumber.
        static void PrintWinner()
        {
           int winnerNumber = GetRaffleNumber(guests);
           string winnerName = guests[winnerNumber];

            
            /*foreach (var wn in GetRaffleNumber())
            {
               int winnerNumber = wn.Key;
               string winnerName = wn.Value;

               Console.WriteLine($"The Winner is: {winnerName} with the #{winnerNumber}");



            }
             */  
            Console.WriteLine($"The Winner is: {winnerName} with the #{winnerNumber}");

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
