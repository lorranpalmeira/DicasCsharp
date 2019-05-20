using System;
using System.Collections.Generic;
using System.Linq;

namespace LambdaCSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            var lista = new List<int> { 1,2,3,4,5,6,7,8};
            
            bool FiltroX(int x)
            {
                return x > 4;
            }

            Func<int, bool> FiltroFunc = x => x > 4;

            var listaFiltrada = lista.Where(FiltroFunc);
            
            foreach (var i in listaFiltrada)
            {
                Console.WriteLine(i);
            }
        }

       
    }
}