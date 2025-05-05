using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;

class Program
{
    static void Main()
    {
        var simbolos = new Dictionary<string, double>();

        Console.WriteLine("Interpretador REPL (C#). Digite 'sair' para encerrar.");

        while (true)
        {
            Console.Write(">>> ");
            string linha = Console.ReadLine();
            if (linha.Trim().ToLower() == "sair") break;

            try
            {
                var lexer = new Lexer(linha);
                var tokens = lexer.Tokenize();
                var parser = new Parser(tokens, simbolos);
                double resultado = parser.Interpretar();
                Console.WriteLine(resultado);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro: " + ex.Message);
            }
        }
    }
}