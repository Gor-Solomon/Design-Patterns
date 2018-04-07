using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompositePattern.Models;

namespace CompositePatternTest
{
    class Program
    {
        static void Main(string[] args)
        {
            IComposite html =  HtmlElement.GetInstance<IComposite>("Html");
            IComposite head =  HtmlElement.GetInstance<IComposite>("head");
            head.AddChilde(HtmlElement.GetInstance<ILeaf>("Title", "Test"));
            ILeaf link = HtmlElement.GetInstance<ILeaf>("link");
            link.AddAttribute("src", "www.link.com");
            link.AddAttribute("rel", "icon");
            head.AddChilde(link);
            html.AddChilde(head);
            IComposite body =  HtmlElement.GetInstance<IComposite>("Body");
            body.AddChilde(HtmlElement.GetInstance<IComposite>("div"));

            html.AddChilde(body);
            Console.WriteLine(html.GetHtml(0));

        }
    }
}
