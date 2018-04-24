using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatePattern.Code
{
    interface IState
    {
        IState InsertCard();
        IState InputPin(int pin);
        IState WithdrawMoney(double amount);
        IState CheckBalance();
        IState EjectCard();
    }
}
