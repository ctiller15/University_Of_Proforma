using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin
{
    class Program
    {
        static void Main(string[] args)
        {
            UIOperations.IntroduceUser();

            bool IsRunning = true;

            while(IsRunning)
            {
                UIOperations.DisplayOptions();
                UIOperations.HandleUserChoice();
            }

            Console.ReadLine();
        }
    }
}
