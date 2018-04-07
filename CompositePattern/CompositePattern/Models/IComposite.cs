using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompositePattern.Models
{
    public interface IComposite : IHtmlElement
    {
        void AddChilde(IHtmlElement childe);

        void AddChilde(int index, IHtmlElement childe);

        void RemoveChilde(IHtmlElement childe);
    }
}
