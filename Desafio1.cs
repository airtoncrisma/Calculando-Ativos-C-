using System;

class Program
{
    static void Main()
    {
        // Recebe a entrada do número de ativos
        int N = int.Parse(Console.ReadLine());
        
        // Receben e divide os valores de mercado em um array de strings
        string[] valoresMercadoStr = Console.ReadLine().Split(',');
        
        double[] valoresMercado = Array.ConvertAll(valoresMercadoStr, double.Parse);
        
        // Recebe o valor total investido
        double valorTotalInvestido = double.Parse(Console.ReadLine());
        
        // Recebe e divide as alocações mínimas em um array de strings
        string[] alocacoesMinimasStr = Console.ReadLine().Split(',');
        
        double[] alocacoesMinimas = Array.ConvertAll(alocacoesMinimasStr, double.Parse);
        
        // Recebendo e dividindo as alocações máximas em um array de strings
        string[] alocacoesMaximasStr = Console.ReadLine().Split(',');
        
        double[] alocacoesMaximas = Array.ConvertAll(alocacoesMaximasStr, double.Parse);
        
        // Calcula o total do mercado
        double totalMercado = 0;
        for (int i = 0; i < N; i++)
        {
            totalMercado += valoresMercado[i];
        }

        // Calcula as alocações proporcionais e ajustando aos limites mínimos e máximos
        double[] alocacoes = new double[N];
        for (int i = 0; i < N; i++)
        {
            double proporcao = valoresMercado[i] / totalMercado; // Proporção do ativo no total
            double alocacoesProporcional = proporcao * valorTotalInvestido;

            // Ajusta a alocação dentro dos limites
            alocacoes[i] = Math.Max(alocacoesMinimas[i], Math.Min(alocacoesMaximas[i], alocacoesProporcional)); // Ajusta dentro dos limites mínimos e máximos
        }

        // Imprime as alocações formatadas com duas casas decimais
        for (int i = 0; i < N; i++)
        {
            Console.WriteLine($"{alocacoes[i]:F2}"); // Mostra cada alocação formatada com duas casas decimais
        }
    }
}