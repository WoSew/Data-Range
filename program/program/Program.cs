using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using program.Infrastructure;

namespace program
{
    class Program
    {
        static void Main(string[] args)
        {
            DateLogic dl = new DateLogic();
            try
            {
                DateTime date1 = dl.DateValidator(args[0]);
                DateTime date2 = dl.DateValidator(args[1]);
                Console.WriteLine(dl.DateRange(date1, date2));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
