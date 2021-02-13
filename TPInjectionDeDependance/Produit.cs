using System;
using System.Collections.Generic;
using System.Text;

namespace TPInjectionDeDependance
{
    class Produit
    {
        public  int prix { get; set; }
        public int reff { get; set; }
        public Produit(int prix,int reff)
        {
            this.prix = prix;
            this.reff = reff;
        }

    }
}
