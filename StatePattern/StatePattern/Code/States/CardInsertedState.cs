using StatePattern.Code.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatePattern.Code.States
{
    class CardInsertedState : IState
    {
        int TryCount = 0;

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
            string hash = Cryptography.SHA256(pin.ToString());

            if(TryCount > 2)
            {
                return new NoCardState();
            }

            if(hash == "03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4")
            {
                return new HasPinState();
            }
            else
            {
                TryCount++;
                return this;
            }
            
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
