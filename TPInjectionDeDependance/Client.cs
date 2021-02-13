using System;
using System.Collections.Generic;
using System.Text;

namespace TPInjectionDeDependance
{
    class Client
    {
        public int numero { get; set; }
        public ParamsClient profil { get; set; }
        public Client(int n , ParamsClient p)
        {
            this.numero = n;
            this.profil = p;
        }
    }
}
