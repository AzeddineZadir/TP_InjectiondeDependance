using System;
using System.Collections.Generic;
using System.Text;

namespace TPInjectionDeDependance
{
    class ChargementDeParametres
    {


        private SystemCentral System { get; set; }
        

        public void connect()
        {
            System = new SystemCentral();

        }

        public Client GetCompteClient(int i )
        {
            return SystemCentral.GetClient(i);
        }

        public ParamsClient GetParams(int i)
        {
            return SystemCentral.GetClient(i).profil;
        }
    }
}
