using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.VisualBasic;

namespace LazyCsharp
{
    class Program
    {
        static void Main(string[] args)
        {
            Criptografia criptografia = new Criptografia();

            var sw = new Stopwatch();
            sw.Start();
            
            Console.WriteLine(criptografia.Criptografar("Hello World"));

            Console.WriteLine($"Time: {sw.Elapsed} " );
            
            
        }
    }

    class Criptografia
    {
        
        public Lazy<OperacaoMatematica> Operador { get; set; }

        public Criptografia()
        {
            Operador = new Lazy<OperacaoMatematica>();
        }

        public string Criptografar(string texto)
        {

            char[] array = texto.ToCharArray();
            if (texto.Length < 20)
            {
                Array.Reverse(array);
            }
            else
            {
                for (int i = 0; i < array.Length; i++)
                {
                    if (Operador.Value.ConfereSePrimo(i))
                        array[i] = 'x';
                }
            }
            

            return new String(array);
        }
        
        
    }


    class OperacaoMatematica
    {
        private List<int> _numerosPrimos = new List<int>();

        public OperacaoMatematica()
        {
            for (int i = 0; i < 80_000; i++)
            {
                var ehPrimo = true;
                for (int j = 2; j < i; j++)
                {
                    if (i % j == 0)
                        ehPrimo = false;
                }

                if (ehPrimo)
                    _numerosPrimos.Add(i);
            }
        }

        public bool ConfereSePrimo(int i)
        {
            return true;
        }
    }
}