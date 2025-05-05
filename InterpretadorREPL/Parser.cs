using System;
using System.Collections.Generic;

public class Parser
{
    private readonly List<Token> tokens;
    private int pos = 0;
    private readonly Dictionary<string, double> simbolos;

    public Parser(List<Token> tokens, Dictionary<string, double> simbolos)
    {
        this.tokens = tokens;
        this.simbolos = simbolos;
    }

    private Token Atual => tokens[pos];

    private bool Aceitar(TokenType tipo)
    {
        if (Atual.Tipo == tipo)
        {
            pos++;
            return true;
        }
        return false;
    }

    private Token Consumir(TokenType tipo, string mensagem)
    {
        if (Atual.Tipo == tipo)
            return tokens[pos++];
        throw new Exception($"{mensagem}. Encontrado: {Atual.Tipo}");
    }

    public double Interpretar()
    {
        if (Atual.Tipo == TokenType.IDENTIFICADOR &&
            tokens[pos + 1].Tipo == TokenType.ATRIBUICAO)
        {
            string nomeVar = Atual.Lexema;
            pos += 2;
            double valor = Expressao();
            simbolos[nomeVar] = valor;
            return valor;
        }
        else
        {
            return Expressao();
        }
    }

    private double Expressao()
    {
        double valor = Termo();
        while (Atual.Tipo == TokenType.SOMA || Atual.Tipo == TokenType.SUBTRACAO)
        {
            if (Aceitar(TokenType.SOMA))
                valor += Termo();
            else if (Aceitar(TokenType.SUBTRACAO))
                valor -= Termo();
        }
        return valor;
    }

    private double Termo()
    {
        double valor = Fator();
        while (Atual.Tipo == TokenType.MULTIPLICACAO || Atual.Tipo == TokenType.DIVISAO)
        {
            if (Aceitar(TokenType.MULTIPLICACAO))
                valor *= Fator();
            else if (Aceitar(TokenType.DIVISAO))
                valor /= Fator();
        }
        return valor;
    }

    private double Fator()
    {
        Token token = Atual;
        if (Aceitar(TokenType.NUMERO))
            return double.Parse(token.Lexema);

        if (Aceitar(TokenType.IDENTIFICADOR))
        {
            if (!simbolos.ContainsKey(token.Lexema))
                throw new Exception("Variável não declarada: " + token.Lexema);
            return simbolos[token.Lexema];
        }

        if (Aceitar(TokenType.PARENTESE_ESQ))
        {
            double valor = Expressao();
            Consumir(TokenType.PARENTESE_DIR, "Esperado ')'");
            return valor;
        }

        throw new Exception("Fator inválido: " + token.Lexema);
    }
}