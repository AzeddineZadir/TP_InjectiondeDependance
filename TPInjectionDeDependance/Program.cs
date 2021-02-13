using System;
using System.Collections.Generic;

namespace TPInjectionDeDependance
{

   

    
    class Program
    {
        static void Main(string[] args)
        {


            Client c1 = new Client (1 ,new ParamsClient("famille nombreuse"));
            Client c2 = new Client(2, new ParamsClient("etudiant"));
            Client c3 = new Client(3, new ParamsClient("blindé"));
            SystemCentral.clients.Add(c1);
            Console.WriteLine("Hello World!");
            foreach (var item in SystemCentral.clients)
            {
                Console.WriteLine(item.numero);
            }
            List<Produit> achete = new List<Produit>();
            Produit p1 = new Produit(100, 1);
            Produit p2 = new Produit(500, 2);
            Produit p3 = new Produit(10, 3);
            Produit p4 = new Produit(50, 4);
            achete.Add(p1);achete.Add(p2);achete.Add(p3);achete.Add(p4);
            
            
            
            TickeDeCaisse tk = new TickeDeCaisse(achete ,new ChargementDeParametres() );
            tk.PrintTicketCaisse(c1.numero);

        }
    }
}
