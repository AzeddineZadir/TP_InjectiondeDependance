using System;
using System.Collections.Generic;
using System.Text;

namespace TPInjectionDeDependance
{
    class SystemCentral
    {
        public static List<Client> clients = new List<Client>() 
        {
            new Client(1,new ParamsClient ("famille nombreuse")) ,new Client(2, new ParamsClient ("etudiant")) ,new Client(3, new ParamsClient ("blindé"))
        };
       
        public static Client GetClient(int id)
        {
            Client res = new Client(99,new ParamsClient( ""));
            foreach (var item in clients)
            {
                if (item.numero== id)
                {
                    res = item;
                    break;
                }
              

            }
            return res;
        }
       /* class Program
        {
            static void Main(string[] args)
            {
               

                foreach (var item in clients)
                {
                    Console.WriteLine(item.profil);
                }
                Console.WriteLine(SystemCentral.GetClient(1).profil);
            }
        }*/
    }
}
