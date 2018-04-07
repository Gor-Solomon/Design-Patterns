using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompositePattern.Models
{
    public abstract class HtmlElement : IHtmlElement
    {
        protected Dictionary<string, string> attributes;

        public readonly string Name;

        public HtmlElement(string name)
        {
            attributes = new Dictionary<string, string>();
            Name = name;
        }

        public void AddAttribute(string attribute, string value)
        {
            if (attributes.ContainsKey(attribute))
            {
                attributes[attribute] = value;
            }
            else
            {
                attributes.Add(attribute, value);
            }
        }

        public void RemoveAttribute(string attribute)
        {
            attributes.Remove(attribute);
        }

        public string GetAttribute(string attribute)
        {
            string result = null;
            attributes.TryGetValue(attribute, out result);

            return result;
        }

        public string GetHtml(int space)
        {
            string text = new string(' ', space) + "<" + Name;

            foreach (var item in attributes)
            {
                text += " " + item.Key + "=\"" + item.Value + "\"";
            }

            text += ">";

            text += ElementSpecificGetHtml(space);

            text += "</" + Name + ">\n";

            return text;
        }

        protected abstract string ElementSpecificGetHtml(int space);

        public static T GetInstance<T>(string name, string value = "") where T : IHtmlElement
        {
            IHtmlElement htmlElement = null;
            if ( typeof(T) == typeof(IComposite))
            {
                htmlElement = new CompositeElement(name);
            }
            else
            {
                htmlElement = new LeafElement(name, value);
            }

            return (T)htmlElement;
        }
    }

}
