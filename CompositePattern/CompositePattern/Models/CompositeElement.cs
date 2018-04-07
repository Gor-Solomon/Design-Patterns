using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompositePattern.Models
{
    internal class CompositeElement : HtmlElement , IComposite
    {
        List<IHtmlElement> ChildeElements;

        public CompositeElement(string name) : base(name)
        {
            ChildeElements = new List<IHtmlElement>();
        }

        public void AddChilde(IHtmlElement childe)
        {
            ChildeElements.Add(childe);
        }

        public void AddChilde(int index, IHtmlElement childe)
        {
           if( index <= ChildeElements.Capacity - 1)
            {
                ChildeElements.Insert(index, childe);
            } 
        }

        public void RemoveChilde(IHtmlElement childe)
        {
            ChildeElements.Remove(childe);
        }

        protected override string ElementSpecificGetHtml(int space)
        {
            string text = "\n";

            foreach (var item in ChildeElements)
            {
                text +=  item.GetHtml(space + 1);
            }

            return text + new string(' ', space) ;

        }
    }
}
