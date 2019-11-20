using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace part2
{
    class Program
    {

        //purpose of main: manage a hotel booking system
        static void Main(string[] args)
        {
            //marks occupied days- false: available, true: occupied
            bool[,] calender = new bool[12, 31];

            //menu controller function
            Menu(calender);

            //do not close terminal immediately
            Console.ReadKey();
        }

        //controls menu actions
        static void Menu(bool[,] calender)
        {
            //continue
            bool cont = true;

            //continue until decided else
            while (cont)
            {
                //print options
                Print_menu();

                //user choise of event
                string choise = Console.ReadLine();

                //what should we do according to input
                switch (choise)
                {
                    //book a date
                    case "1":
                        //input book data 
                        Console.WriteLine("\nEnter the day:");
                        int date_day = Int32.Parse(Console.ReadLine()) - 1;
                        Console.WriteLine("Enter the month:");
                        int date_month = Int32.Parse(Console.ReadLine()) - 1;
                        Console.WriteLine("Enter the duration:");
                        int duration = Int32.Parse(Console.ReadLine());

                        //check for data exceptions
                        if (date_day < 0 || date_day > 30 || date_month < 0 || date_month > 11 || duration < 1 || duration > 372)
                        {
                            Console.WriteLine("ERROR\n\n");
                            break;
                        }

                        //help variable to check if room is empty
                        bool empty = true;
                        
                        //check for dates availabily
                        for (int i = 0; i < duration; i++)
                        {
                            //check that no days are already occupied
                            if (calender[(date_month + (date_day + i) / 31) % 12, (date_day + i) % 31]) empty = false;
                        }

                        //available dates
                        if (empty)
                        {
                            for (int i = 0; i < duration; calender[(date_month + (date_day + i) / 31) % 12, (date_day + i) % 31] = true, i++) ;
                            Console.WriteLine("Request accepted\n");
                        }

                        //not availabe
                        else
                            Console.WriteLine("Request denied\n");
                        break;

                    //print hotel occupation dates
                    case "2":
                        //first and last days of room usage
                        string first_day = "";
                        string last_day = "";

                        //help variable to check if a few days are in a row
                        bool in_strike = false;

                        //check every day in the year
                        for (int i = 0; i < 12; i++)
                        {
                            for (int j = 0; j < 31; j++)
                            {
                                //check for start of strike
                                if ((calender[i, j]) && (!in_strike))
                                {
                                    first_day = (j + 1).ToString() + '/' + (i + 1).ToString();
                                    in_strike = true;
                                }

                                //search for end of strike
                                if (((!calender[i, j]) && (in_strike)) || (i == 11 && j == 30))
                                {
                                    last_day = (j + 1).ToString() + '/' + (i + 1).ToString();
                                    in_strike = false;
                                    //print this period
                                    Console.WriteLine("{0} - {1}", first_day, last_day);
                                }
                            }
                        }
                        break;

                    //print hotel statistics
                    case "3":
                        int occupied = 0;
                        //count number of occupied days
                        for (int i = 0; i < 12; ++i)
                        {
                            for (int j = 0; j < 31; ++j)
                            {
                                if (calender[i, j]) ++occupied;
                            }
                        }
                        //print number of occupied days and usage statistics
                        Console.WriteLine("Number of occupied days: {0}", occupied);
                        Console.WriteLine("Percentage of occupation: {0:f2}", occupied / 372.0 * 100);
                        break;
                    
                    //quit
                    case "0":
                        cont = false;
                        break;

                }
            }
        }
        //print the selection menu
        static void Print_menu()
        {
            Console.WriteLine("Welcome to menu:");
            Console.WriteLine("Press 1 to enter new guest");
            Console.WriteLine("Press 2 to show yealy guest list");
            Console.WriteLine("Press 3 to show yearly statistic");
            Console.WriteLine("Press 0 to quit\n");
        }

    }
}
