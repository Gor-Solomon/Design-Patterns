using StatePattern.Code.States;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatePattern.Code
{
    public class ATM
    {
        IState state;

        public ATM()
        {
            state = new NoCardState();
        }
    }
}
