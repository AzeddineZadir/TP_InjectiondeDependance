using System;
using System.Collections.Generic;
using System.Text;

namespace TPInjectionDeDependance
{
    class ParamsClient
    {
        public string param { get; set; }

        public ParamsClient(string s )
        {
            this.param = s;
        }
    }
}
