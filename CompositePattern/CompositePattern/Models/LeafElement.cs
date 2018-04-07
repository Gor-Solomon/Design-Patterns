using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompositePattern.Models
{
    internal class LeafElement : HtmlElement, ILeaf
    {
        string value;

        public string Value
        {
            get
            {
                return this.value;
            }

            set
            {
                this.value = value;
            }
        }

        public LeafElement(string name, string value = "" ) : base(name)
        {
            this.value = value;
        }

        protected override string ElementSpecificGetHtml(int space)
        {
            return  this.value;
        }
    }
}
