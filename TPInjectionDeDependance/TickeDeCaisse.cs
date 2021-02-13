using System;
using System.Collections.Generic;
using System.Text;

namespace TPInjectionDeDependance
{
    class TickeDeCaisse
    {
        List<Produit> achats;

        public TickeDeCaisse(List<Produit> achats)
        {
            this.achats = achats;
        }
           
        public void  ScanneProduits(Produit p)
        {
            achats.Add(p);
        }
        public float GetPrixProduits(Produit p, int id)
        {

            ParamsClient profile = GetParmsClient(id);
            int prixCalculé= 0;
            switch (profile.param)
            {
                case "famille nombreuse":
                    prixCalculé = p.prix-(p.prix*10)/100;
                    break;

                case "etudiant":
                    prixCalculé = p.prix - (p.prix * 20) / 100;
                    break;
                case "blindé":
                    prixCalculé = p.prix + (p.prix * 10) / 100;
                    break;
                default:
                    prixCalculé = p.prix;
                    break;
            }
            return prixCalculé;
        }
        
        public ParamsClient GetParmsClient(int id )
        {
           
            ChargementDeParametres chargeur =new  ChargementDeParametres();
            chargeur.connect();
            
            return chargeur.GetParams(id); ;
        }

        public void PrintTicketCaisse( int id)
        {
            Console.WriteLine("votre ticket ");
            foreach (var item in achats)
            {
                Console.WriteLine("larticle {0}  : prix {1}",item.reff,GetPrixProduits(item,id));
            }
            Console.WriteLine("Merci pour avoir choisi nos magasins  ");
        }
    }
}
