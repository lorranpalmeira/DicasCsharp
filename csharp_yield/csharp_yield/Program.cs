using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace csharp_yield
{
    class Program
    {
        static void Main(string[] args)
        {
            void Execute()
            {
                
                
                var listToGer = new List<int>();
                for (int i = 0; i < 700; i++)
                {
                    listToGer.Add(i);
                }
                
                var stopwatch1 = new Stopwatch();
                stopwatch1.Start();

                foreach (var nry in GetNumbersGreaterThan3Yield(listToGer))  //(new List<int> {1,2,3,4,}))
                    Console.WriteLine(nry);
               
                
                var elapsedTicks1 = stopwatch1.Elapsed;
                
                var stopwatch2 = new Stopwatch();
                stopwatch2.Start();

                foreach(var nr in GetNumbersGreaterThan3(listToGer))   //(new List<int> {1,2,3,4}) )
                    Console.WriteLine(nr);
                
                
                var elapsedTicks2 = stopwatch2.Elapsed;
                
                Console.WriteLine($"Com Yield: {elapsedTicks1}");
                Console.WriteLine($"Sem Yield: {elapsedTicks2}");
            }

            Execute();


            /*
            foreach (var i in Potencia(2,81))
            {
                //Console.WriteLine("{0}",i);
            }

            Console.WriteLine($"Resultado: {PotenciaNormal(2,81)}");
            */
        }

        // 
        //Yield
        static IEnumerable<int> GetNumbersGreaterThan3Yield(List<int> numbers)
        {
            foreach (var nr in numbers)
            {
                if (nr > 3)
                    yield return nr;
            }
        }


        // Lista

        static IEnumerable<int> GetNumbersGreaterThan3(List<int> numbers)
        {
            var theNumbers = new List<int>();
            foreach (var nr in numbers)
            {
                if (nr > 3)
                    theNumbers.Add(nr);
            }

            return theNumbers;
        }
    

        //
        
       
        
        
        
        // Exemplo Potencia
        

        public static IEnumerable<int> Potencia(int numero, int expoente)
        {
            var sw = new Stopwatch();
            sw.Start();
            
            int resultado = 1;

            for (int i = 0; i < expoente; i++)
            {
                resultado = resultado * numero;
                yield return resultado;
            }
            
            Console.WriteLine($"time: {sw.Elapsed}");

        }

        static int PotenciaNormal(int numero, int expoente)
        {
            var sw = new Stopwatch();
            sw.Start();
            
            int resultado = 1;
            for (int i = 0; i < expoente; i++)
            {
                resultado = resultado * numero;
            }

            Console.WriteLine($"time: {sw.Elapsed}");

            return resultado;
        }
    }
}