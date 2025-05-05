using System;
using System.Collections.Generic;

public class Lexer
{
    private readonly string input;
    private int pos = 0;

    public Lexer(string input)
    {
        this.input = input;
    }

    public List<Token> Tokenize()
    {
        List<Token> tokens = new List<Token>();

        while (pos < input.Length)
        {
            char c = input[pos];

            if (char.IsWhiteSpace(c))
            {
                pos++;
                continue;
            }

            if (char.IsDigit(c))
            {
                tokens.Add(LerNumero());
                continue;
            }

            if (char.IsLetter(c))
            {
                tokens.Add(LerIdentificador());
                continue;
            }

            switch (c)
            {
                case '+': tokens.Add(new Token(TokenType.SOMA, "+")); break;
                case '-': tokens.Add(new Token(TokenType.SUBTRACAO, "-")); break;
                case '*': tokens.Add(new Token(TokenType.MULTIPLICACAO, "*")); break;
                case '/': tokens.Add(new Token(TokenType.DIVISAO, "/")); break;
                case '=': tokens.Add(new Token(TokenType.ATRIBUICAO, "=")); break;
                case '(': tokens.Add(new Token(TokenType.PARENTESE_ESQ, "(")); break;
                case ')': tokens.Add(new Token(TokenType.PARENTESE_DIR, ")")); break;
                default: throw new Exception($"Caractere inválido: {c}");
            }

            pos++;
        }

        tokens.Add(new Token(TokenType.EOF, ""));
        return tokens;
    }

    private Token LerNumero()
    {
        int start = pos;
        while (pos < input.Length && char.IsDigit(input[pos]))
            pos++;
        return new Token(TokenType.NUMERO, input.Substring(start, pos - start));
    }

    private Token LerIdentificador()
    {
        int start = pos;
        while (pos < input.Length && char.IsLetterOrDigit(input[pos]))
            pos++;
        return new Token(TokenType.IDENTIFICADOR, input.Substring(start, pos - start));
    }
}