using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatePattern.Code.States
{
    class HasPinState : IState
    {
        public IState CheckBalance()
        {
            throw new NotImplementedException();
        }

        public IState EjectCard()
        {
            throw new NotImplementedException();
        }

        public IState InputPin(int pin)
        {
            throw new NotImplementedException();
        }

        public IState InsertCard()
        {
            throw new NotImplementedException();
        }

        public IState WithdrawMoney(double amount)
        {
            throw new NotImplementedException();
        }
    }
}
