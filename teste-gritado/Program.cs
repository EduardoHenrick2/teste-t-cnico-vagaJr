using System;
using System.Text;

class Program
{
    public static string NormalizeString(string input)
    {
        StringBuilder resultado = new StringBuilder();
        int i = 0;

        while (i < input.Length)
        {
            char atual = input[i];

            if (atual == '!' || atual == '?')
            {
                int totalexclamacao = 0;
                int totalinterrogacao = 0;

                while (i < input.Length && (input[i] == '!' || input[i] == '?'))
                {
                    if (input[i] == '!')
                        totalexclamacao++;
                    else
                        totalinterrogacao++;
                    i++;
                }

                if (totalexclamacao > 0 && totalinterrogacao > 0)
                    resultado.Append("!?");
                else if (totalinterrogacao > 0)
                    resultado.Append("?");
                else
                    resultado.Append("!");
            }
            else
            {
                resultado.Append(atual);
                i++;
            }
        }
        return resultado.ToString();
    }

    public static void Main(string[] args)
    {
        Console.WriteLine(NormalizeString("Como é???????"));
        Console.WriteLine(NormalizeString("Não!!!!!!!!"));
        Console.WriteLine(NormalizeString("O que???!!!!! Não acredito!!!"));
    }

}