using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CmsDesignPatterns1.UI
{
    class SelectionMenu
    {
        List<string> selections;
        string header;
        bool includeExit;
        public SelectionMenu(string header, string[] items, bool includeExit)
        {
            selections = items.ToList();
            this.header = header;
            this.includeExit = includeExit;
        }
        public int RenderAndSelect(bool clear)
        {
            while (true)
            {
                if (clear)
                    Console.Clear();
                Console.WriteLine(header);
                for (int i = 0; i < selections.Count(); i++)
                    Console.WriteLine($"{i + 1}. {selections[i]}");
                if (includeExit)
                    Console.WriteLine("0. Avsluta");

                int sel;
                if (int.TryParse(Console.ReadLine(), out sel))
                {
                    if (sel == 0 && includeExit == true) return 0;
                    if (sel > 0 && sel <= selections.Count()) return sel;
                }
                Console.WriteLine("Ogiltig inmatning...");
                System.Threading.Thread.Sleep(3000);
            }
        }


    }
}
