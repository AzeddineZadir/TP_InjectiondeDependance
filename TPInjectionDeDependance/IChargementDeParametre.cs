using System;
using System.Collections.Generic;
using System.Text;

namespace TPInjectionDeDependance
{
    interface IChargementDeParametre
    {
        public void Connect();
        public Client GetCompteClient(int i);

        public ParamsClient GetParams(int i);
    }
}
