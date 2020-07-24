using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Super_Market
{
    
    class Program
    {
      static Record r = new Record();
       static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                int choice;
                Console.WriteLine("\n\t\t ***** Main Menu *****");
                Console.WriteLine("\n\t  1.  Add Records");
                Console.WriteLine("\n\t  2.  Show Records");
                Console.WriteLine("\n\t  3.  Modify Records");
                Console.WriteLine("\n\t  4.  Search Records");
                Console.WriteLine("\n\t  5.  DELETE Records");
                Console.WriteLine("\n\t  6.  Main Menu");
                Console.WriteLine("\n\t  7.  Exit");

                Console.WriteLine("\n\n\t  Enter Your Choice: ");

                choice = int.Parse(Console.ReadLine());



                switch (choice)
                {
                    case 1:
                        r.add();
                        break;
                    case 2:
                        r.show();
                        break;
                    case 3:
                        r.modify();
                        break;
                    case 4:
                        r.search();
                        break;
                    case 5:
                        r.del();
                        break;
                    case 6:

                        break;
                    case 7:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid Choice...!");
                        
                        break;
                }
                Console.ReadKey();
            }
        }
    }
}
