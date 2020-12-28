using System;
using System.Threading.Tasks;

namespace Bot
{
    class Program
    {
        public static async Task Main(string[] args) 
            => await Startup.RunAsync(args);
        
    }
}
