using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library;
using System.ServiceModel;

namespace LibraryHost
{
    class Program
    {
        static void Main(string[] args)
        {

            var host = new ServiceHost(typeof(LibraryService));

            try
            {
                host.Open();
                Console.WriteLine("Service running like a charm");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine();
                Console.WriteLine(e.InnerException);
                host.Abort();
            }

            Console.Read();

            host.Close();
        }
    }
}
