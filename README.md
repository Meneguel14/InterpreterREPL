# Interpretador REPL em C#

Este projeto é um **interpretador REPL (Read-Eval-Print Loop)** simples, desenvolvido em C#, com o objetivo de interpretar expressões matemáticas e realizar atribuições de variáveis. Ele foi criado como parte da disciplina de **Compiladores**, ministrada pelo **Professor Wellington Della Mura**.

---

## 🧠 O que o interpretador faz?

Este REPL é capaz de:

- ✅ Avaliar expressões matemáticas com `+`, `-`, `*`, `/`
- ✅ Utilizar parênteses para agrupar expressões: `(2 + 3) * 4`
- ✅ Declarar variáveis: `x = 10`
- ✅ Reutilizar variáveis em expressões: `y = x * 2`
- ❌ Lançar exceções claras para variáveis não declaradas ou erros sintáticos

---

## 💡 Como funciona?

O interpretador funciona em 3 etapas principais:

1. **Análise Léxica (Lexer)**  
   Divide a entrada do usuário em "tokens" que representam números, operadores, identificadores (nomes de variáveis), etc.

2. **Análise Sintática e Avaliação (Parser)**  
   Usa uma gramática recursiva para entender a ordem e a estrutura da expressão, e já avalia os resultados.

3. **Tabela de Símbolos**  
   Armazena as variáveis definidas pelo usuário para permitir reuso nas próximas linhas.

Desenvolvido por João Henrique Meneguel de Oliveira
Para a disciplina de Compiladores – UENP
Professor: Wellington Della Mura
