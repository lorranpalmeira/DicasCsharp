using System;
using System.Collections.Generic;
using System.Linq;

namespace ListaVsIEnumerable
{
    class Program
    {
        static void Main(string[] args)
        {
            // Exemplo com Lista
            var caderno = new List<Folha>();
            for (int i = 0; i < 51; i++)
            {
                caderno.Add(new Folha {Pagina = i});
            }


            // Exemplo com array
//            var cadernoArray = new Folha[51];
//            for (int i = 0; i < cadernoArray.Length; i++)
//            {
//                cadernoArray[i] = new Folha{Pagina = i};
//            }

            //var folhasComRabiscos = caderno.Where(x => x.AnalisaSeContemRabisco());


            // ARRAY
            // Semelhate ao comportamento da lista, porém mais leve pra converter.

            /*
            var folhasComRabiscos = caderno.Where(x => x.AnalisaSeContemRabisco()).ToArray();
            
            if (folhasComRabiscos.Count() > 5)
            {
                // Faz alguma coisa
            }

            if (folhasComRabiscos.Count() > 10)
            {
                // Faz alguma coisa.
            }

            if (folhasComRabiscos != null)
            {
                // Do Something
            }
            */


            // FIM ARRAY

            // LIST
            // Carrega a lista em memória se necessitar computar várias vezes.

            //var folhasComRabiscos = caderno.Where(x => x.AnalisaSeContemRabisco()).ToList();


            // Nos dois If abaixo só é computado uma vez que a lista está em memória.
            // Diferentemente do IEnumerable que não contém os indices e computa todo o tempo.
            /*
            if (folhasComRabiscos.Count() > 5)
            {
                // Faz alguma coisa
            }

            if (folhasComRabiscos.Count() > 10)
            {
                // Faz alguma coisa.
            }
            */
            //

            // Operação abaixo não são eficiente já que é carregado toda a lista em memória para verificar apenas um elemento.
            //var primeiraRabiscada = folhasComRabiscos.FirstOrDefault();

            //var temRabiscada = folhasComRabiscos.Any();
            //

            // FIM LISTA


            // Enumeravel

            // O Enumeravel não sabe quantos indices que tem ou se tem indice,
            // então ele enumera duas vezes como no exemplo abaixo.
            // Não da pra fazer isso folhasComRabiscos[5] 

            var folhasComRabiscos = caderno.Where(x => x.AnalisaSeContemRabisco());


            if (folhasComRabiscos.Count() > 5)
            {
                // Faz alguma coisa
            }

            if (folhasComRabiscos.Count() > 10)
            {
                // Faz alguma coisa.
            }

            // Onde é útil? Nos exemplos abaixo.
            // Só computa uma vez O(1)
            if (folhasComRabiscos.Any())
            {
                Console.WriteLine("Any EXPRESSION");
                //Faz algo
            }

            if (folhasComRabiscos.FirstOrDefault() != null)
            {
                Console.WriteLine("First EXPRESSION");
            }

            var primeiraRabiscada = folhasComRabiscos.FirstOrDefault();


            //
        }
    }

    internal class Folha
    {
        private bool _isLimpa;
        private bool _isRabisco;

        public Folha()
        {
            var seed = Guid.NewGuid().GetHashCode();
            var aleatorio = new Random(seed).Next(1, 4);
            _isLimpa = aleatorio == 1;
            _isRabisco = aleatorio == 2;
            var _is_Texto = aleatorio == 3;
        }

        public int Pagina { get; set; }

        public bool AnalisaSeContemRabisco()
        {
            Console.WriteLine($"Executando análise complexa de página:{Pagina}");

            return _isRabisco;
        }
    }
}