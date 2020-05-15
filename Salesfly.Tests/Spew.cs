using System;
using Newtonsoft.Json;

namespace Salesfly.Tests
{
    public class Spew
    {
        public static void Dump(object obj)
        {
            Console.WriteLine(JsonConvert.SerializeObject(obj));
        }
    }
}