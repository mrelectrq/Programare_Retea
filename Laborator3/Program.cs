using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laborator3
{
    class Program
    {
        static void Main(string[] args)
        {


            RVT_ApiRequest resp = new RVT_ApiRequest();
        Start:
            Console.WriteLine("Choose HTTP method request : \n\n 1.GET METHOD \n\n 2. POST METHOD \n\n 3. HEAD METHOD \n\n 4. OPTIONS METHOD \n\n 5. Exit...");
            string input = Console.ReadLine();
            int option;

           
            if (int.TryParse(input, out option))
               
            switch (option)
                {
                    case 1:


                        Console.WriteLine(resp.GetMeth());
                        break;
                    case 2:
                        Console.WriteLine(resp.POSTMeth());
                        break;
                    case 3:
                        Console.WriteLine(resp.HeadMeth());
                        break;

                    case 4:
                        Console.WriteLine(resp.OptionMeth());
                        break;

                    default:
                        Console.WriteLine("Invalid");
                        break;
                }
            else
            {
                Console.WriteLine("Invalid input");
            }

            goto Start;

        }
    }
}
