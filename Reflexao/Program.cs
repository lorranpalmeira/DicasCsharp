using System;
using System.Collections;
using System.Text;

namespace Reflexao
{
    class Program
    {
        static void Main(string[] args)
        {
            var pessoa = new Pessoa {Nome = "Joao", Idade = 20};
            var equipamento = new Equipamento { Descricao = "Cahve de Fenda", Modelo = "F20", Marca = "Tramontina"};
            var livro = new Livro {Titulo = "Harry Potter", Lancamento = new DateTime(1997, 6, 26)};

            Log(pessoa);
            Log(equipamento);
            Log(livro);
            
            Log<Pessoa>(pessoa);

        }


        static void Log(object obj)
        {
            var tipo = obj.GetType();

            var builder = new StringBuilder();

            builder.AppendLine("Data do Log:" + DateTime.Now);

            foreach (var property in tipo.GetProperties())
            {
                builder.AppendLine(property.Name + ": " + property.GetValue(obj));
            }

            Console.WriteLine(builder.ToString());

        }
        
        static void Log<T>(T obj) 
        {
            //var tipo = new T();
            var tipo = Activator.CreateInstance<T>();

            var builder = new StringBuilder();

            builder.AppendLine("Data do Log:" + DateTime.Now);
            foreach (var property in tipo.GetType().GetProperties())
            {
                builder.AppendLine("Nome: " + property.GetValue(obj));
            }

            Console.WriteLine(builder.ToString());

        }

        class Pessoa
        {
            public string Nome { get; set; }

            public int Idade { get; set; }
        }

        class Equipamento
        {
            public string  Descricao { get; set; }
            public string Modelo { get; set; }
            public string Marca { get; set; }        
        }

        class Livro
        {
            public string Titulo { get; set; }
            public DateTime Lancamento { get; set; }
        }
    }
}