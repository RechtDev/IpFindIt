using System;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace IpFindIt
{
    class Program
    {
        static void Main(string[] args)
        {
            //Sets size of Cosnole
            Console.BufferHeight = 42;           
            Console.SetWindowSize(100, 42);
            //Asks users name. (I think it adds personality)
            Messages.PromptMessage("Hello, Please enter your name.", ConsoleColor.Green);
            string name = Console.ReadLine();
            while (String.IsNullOrEmpty(name))
            {
                Messages.AlertMessage("Please enter your name!");
                name = Console.ReadLine();

            }
            //Menu items count as one Module. 
            bool BackToMenu = true;
            while (BackToMenu)
            {
                Console.WriteLine($"Hello {name}, welcome!");
                Console.WriteLine($"Now, {name} what would you like to do?\n");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("1)Find IP Address \n" +
                                  "2)Activate Geo-location services \n" +
                                  "3)Run GUI version of program \n" +
                                  "4)Exit Program");
                string menuChoice = Console.ReadLine();
                int menuNumber;
                while (!int.TryParse(menuChoice, out menuNumber))
                {
                    if (menuNumber > 4 || menuNumber < 1)
                    {
                        Messages.AlertMessage(message: "You have entered an invalid Number, please select a correct option! (1-3)");
                        menuChoice = Console.ReadLine();
                    }
                    else if (menuNumber == default)
                    {
                        Messages.AlertMessage("You have not entered anything! Please enter a choice of either 1, 2, or 3.");
                        menuChoice = Console.ReadLine();

                    }
                }
                bool repeat = true;
                while (repeat)
                {
                    switch (Int32.Parse(menuChoice))
                    {
                        case 1:
                            {
                                Console.Clear();
                                Messages.PromptMessage("Okay please enter the IP Address you want to resolve.", ConsoleColor.Green);
                                Messages.PromptMessage("IP Address: **Leave Blank To Check Your IP** **Add flags to specify search (Type help for list of flags)**\n", ConsoleColor.Green);
                                string ShowOptions = Console.ReadLine();
                                
                                if (ShowOptions == "help")
                                {
                                    Messages.PromptMessage("The flags that specify the returned results:\n" +
                                        "-f: Gives you every type of result there is\n" +
                                        "-b: Makes a short summery only the important results get displayed", ConsoleColor.White);
                                }
                                Messages.PromptMessage("IP Address [space] flag");
                                string IpFlag = Console.ReadLine();                                                              
                                string[] SeperationIpFlag = IpFlag.Split(' ');
                                string IpAddress = SeperationIpFlag[0];
                                string Flag = SeperationIpFlag[1];
                                IpCalling.ResolveIp(IpAddress, Flag);
                                Messages.PromptMessage("Would you like to search another IP (Y/N)", ConsoleColor.Green);
                                string goOn = Console.ReadLine().ToUpper();

                                while (String.IsNullOrEmpty(goOn))
                                {
                                    Messages.AlertMessage("Please choose either (Y)es or (N)o");
                                    goOn = Console.ReadLine().ToUpper();

                                }
                                if (goOn == "Y")
                                {
                                    continue;
                                }
                                if (goOn == "N")
                                {
                                    Console.Clear();
                                    repeat = false;
                                    BackToMenu = true;

                                }
                                break;
                            }
                        case 2:
                            {
                                break;        
                            }
                        case 3:
                            {
                                break;
                            }
                        case 4:
                            {
                                return;
                                break;
                            }  
                    }
                }
            }
        }   
    }
}
