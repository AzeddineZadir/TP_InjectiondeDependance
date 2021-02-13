using System;
using System.Collections.Generic;
using System.Text;

namespace TPInjectionDeDependance
{
    class ChargementDeParametres :IChargementDeParametre
    {


        private SystemCentral System { get; set; }
        

        public void Connect()
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
