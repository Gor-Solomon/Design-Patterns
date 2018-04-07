using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompositePattern.Models
{
    public interface IHtmlElement
    {
        void AddAttribute(string attribute, string value);
        void RemoveAttribute(string attribute);
        string GetAttribute(string attribute);
        string GetHtml(int space);
    }
}
