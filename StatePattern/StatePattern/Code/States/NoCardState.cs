using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatePattern.Code.States
{
    class NoCardState : IState
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
            return new CardInsertedState();
        }

        public IState WithdrawMoney(double amount)
        {
            throw new NotImplementedException();
        }
    }
}
