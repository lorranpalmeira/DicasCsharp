using System;

namespace GenericTypesDicas
{
    class Program1
    {
        static void MainX(string[] args)
        {
            
            
            // TIPO NÃO GENÉRICA ONDE HÁ VÁRIOS PROBLEMAS
            
            var macho = new Cachorro();
            var femea = new Cachorro();

            var filhote = CruzarCachorro(macho, femea);
            
            
            Console.WriteLine($"Filhote: {filhote}");
        }

        public static Cachorro CruzarCachorro(Cachorro macho, Cachorro femea) 
        {
            //var filhote = Activator.CreateInstance<T>();
            var filhote = new Cachorro();
            filhote.Mae = femea;
            filhote.Pai = macho;

            return filhote;
        }
        
        public abstract class Mamifero
        {
            
            public Mamifero Pai { get; set; }
            public Mamifero Mae { get; set; }
            
            public decimal Peso { get; set; }
        }

        public class Cachorro : Mamifero
        {
            public string Raça{get; set;}
        }
        
        public class Gato : Mamifero
        {
            public string Raça { get; set; }
            public int Bigode { get; set; }
            
        }

        public class Elefante : Mamifero
        {
            public int Trompa { get; set; }
        }
        
        
        
    }
}