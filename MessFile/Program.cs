using System;
using System.Threading.Tasks;

namespace MessFile
{
    class Program
    {
        static void Main(string[] args)
        {
            var text = new Worker("mess.txt", 10).GetCleanText();
            Console.WriteLine(text);
        }
    }
}
