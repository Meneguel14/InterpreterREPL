public class Token
{
    public TokenType Tipo { get; }
    public string Lexema { get; }

    public Token(TokenType tipo, string lexema)
    {
        Tipo = tipo;
        Lexema = lexema;
    }

    public override string ToString()
    {
        return $"\"{Tipo}('{Lexema}')\"";
    }
}