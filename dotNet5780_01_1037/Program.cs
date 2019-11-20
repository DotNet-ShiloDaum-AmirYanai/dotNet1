using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNet5780_01_1037
{
    class Program
    {
        
        static void Main(string[] args)
        {
            bool[,] calender = new bool[12, 31];
            menu(calender);
            Console.ReadKey();
        }
       
        static void menu(bool[,] calender)
        {
            //shift one day index starts at 0
            bool cont = true;
            while (cont)
            {
                Print_menu();

                string choise = Console.ReadLine();
                switch (choise)
                {
                    case "1":
                        Console.WriteLine("\nEnter the day:");
                        int date_day = Int32.Parse(Console.ReadLine())-1;
                        Console.WriteLine("Enter the month:");
                        int date_month = Int32.Parse(Console.ReadLine())-1;
                        Console.WriteLine("Enter the duration:");
                        int duration = Int32.Parse(Console.ReadLine());
                        if(date_day<0 || date_day>30 || date_month < 0 || date_month > 11 || duration < 1 || duration > 372)
                        {
                            Console.WriteLine("ERROR\n\n");
                            break;
                        }
                        bool empty = true;
                        for (int i = 0; i < duration; i++)
                        {
                            if (calender[(date_month+ (date_day + i) / 31)%12, (date_day + i)%31]) empty = false;
                        }
                        if (empty)
                        {
                            for (int i = 0; i < duration; calender[(date_month + (date_day + i) / 31) % 12, (date_day + i) % 31] = true, i++) ;
                            Console.WriteLine("Request accepted\n");
                        }
                        else
                            Console.WriteLine("Request denied\n");
                        break;
                    
                    case "2":
                        string first_day = "";
                        string last_day = "";
                        bool in_strike = false;
                        for (int i = 0; i < 12; i++)
                        {
                            for (int j = 0; j < 31; j++)
                            {
                                if ((calender[i,j])&&(!in_strike))
                                {
                                    first_day = (j+1).ToString() + '/' + (i+1).ToString();
                                    in_strike = true;


                                }
                                if (((!calender[i, j]) && (in_strike))|| (i == 11 && j == 30))
                                {
                                    last_day = (j + 1).ToString() + '/' + (i + 1).ToString();
                                    in_strike = false;
                                    Console.WriteLine("{0} - {1}",first_day,last_day);
                                }
                            }
                        }
                        break;

                    case "3":
                        int occupied = 0;
                        for (int i = 0; i < 12; ++i)
                        {
                            for (int j = 0; j < 31; ++j)
                            {
                                if (calender[i, j]) ++occupied;
                            }
                        }
                        Console.WriteLine("Number of occupied days: {0}",occupied);
                        Console.WriteLine("Percentage of occupation: {0:f2}",occupied/372.0*100);
                        break;

                    case "0":
                        cont = false;
                        break;

                }
            }
        }
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
