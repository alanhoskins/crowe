using System;

namespace CroweApi
{
    public class ConsoleWriter : MessageWriter
    {
        public override void WriteMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}
