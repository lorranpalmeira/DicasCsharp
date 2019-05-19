using System;

namespace GenericTypesDicas
{
    class Program
    {
        static void Main(string[] args)
        {
            
            var macho = new Cachorro();
            var femea = new Cachorro();

            var filhote = Cruzar<Cachorro>(macho, femea);
            
            
            Console.WriteLine($"Filhote: {filhote}");
        }

        public static T Cruzar<T>(T macho, T femea) where T : Mamifero<T>, new()
        {
            //var filhote = Activator.CreateInstance<T>();
            var filhote = new T();
            filhote.Mae = femea;
            filhote.Pai = macho;

            return filhote;
        }
        
        public abstract class Mamifero<T> where T : Mamifero<T>
        {
            
            public T Pai { get; set; }
            public T Mae { get; set; }
            
            public decimal Peso { get; set; }
        }

        public class Cachorro : Mamifero<Cachorro>
        {
            public string Raça
            {
                get; set;
                
            }
        }
        
        public class Gato : Mamifero<Gato>
        {
            public string Raça { get; set; }
            public int Bigode { get; set; }
            
        }

        public class Elefante : Mamifero<Elefante>
        {
            public int Trompa { get; set; }
        }
        
        
        
    }
}