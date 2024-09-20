using System;
using System.Linq;

public class Program
{
    public static void Main(string[] args)
    {
        // Lê a string de entrada contendo os preços de fechamento
        string input = Console.ReadLine();
        
        // Separa os preços de fechamento em um array de strings
        string[] precosStr = input.Split(',');
        
        // Converte os preços de fechamento para um array de doubles
        double[] precos = Array.ConvertAll(precosStr, Double.Parse);
        
        // Calcula a volatilidade histórica (desvio padrão)
        double volatilidade = CalcularVolatilidade(precos);
        
        // Exibe o resultado formatado com três casas decimais
        Console.WriteLine($"{volatilidade:F3}");
    }
    
    public static double CalcularVolatilidade(double[] precos)
    {
        // Calcula a média dos preços de fechamento
        double media = CalcularMedia(precos);
        
        // Calcula as diferenças quadráticas em relação à média e soma
        double somaDiferencasQuadraticas = precos.Sum(preco => Math.Pow(preco - media, 2));
        
        // Calcula a variância dividindo a soma das diferenças quadráticas pelo número de dias
        double variancia = somaDiferencasQuadraticas / precos.Length;
        
        // Calcula o desvio padrão (raiz quadrada da variância)
        double desvioPadrao = Math.Sqrt(variancia);
        
        return desvioPadrao; // Retorna o desvio padrão (volatilidade)
    }
    
    public static double CalcularMedia(double[] precos)
    {
        // Calcula a soma de todos os preços
        double soma = precos.Sum();
        
        // Retorna a média dos preços
        return soma / precos.Length;
    }
}
