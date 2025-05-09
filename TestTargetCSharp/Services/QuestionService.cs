using TestTargetCSharp.Dtos;

namespace TestTargetCSharp.Services;

internal static class QuestionService
{
    /// Desafio: Calcular a soma dos números de 1 a 13.
    /// resultado: O valor total da soma 
    internal static int Question1()
    {
        int indice = 13;
        int soma = 0, K = 0;
    
        while (K < indice)
        {
            K++;
            soma = soma + K;
        }
    
        return soma;
  
    }

    // Desafio: Calcular a sequencia fibonacci de qualquer número e verificar se ele pertence a essa sequência.
    // resultado: O valor total da soma
    internal static bool Question2(int valorX)
    {
        int anterior = 0, atual = 1;
        
        while (atual <= valorX)
        {
            if (atual == valorX) return true;
            int proximo = anterior + atual;
            anterior = atual;
            atual = proximo;
        }
        
        return false; 
    }
    
    // Desafio: Analisar o faturamento diário de uma distribuidora
    // resultado: Retornar o menor valor de faturamento do mês, o maior valor de faturamento do mês e o número de dias do mês
    // em que o valor do faturamento diário foi superior à média mensal.
    internal static QuestionThreeDtoResult Question3()
    {
        var basePath = AppDomain.CurrentDomain.BaseDirectory;
        var pathProject = Directory.GetParent(basePath)!.Parent!.Parent!.Parent!.FullName;
        var jsonPath = Path.Combine(pathProject, "Assets", "dados.json");
        var jsonContent = File.ReadAllText(jsonPath);
        var faturamentoDiario = System.Text.Json.JsonSerializer.Deserialize<List<QuestionThreeDailyRevenueResponse>>(jsonContent);
        
        var faturamentosValidos = faturamentoDiario.Where(r => r.valor > 0).ToList();
        
        var min = faturamentosValidos.Min(r => r.valor);
        var max = faturamentosValidos.Max(r => r.valor);
        var average = faturamentosValidos.Average(r => r.valor);
        var daysAboveAverage = faturamentosValidos.Count(r => r.valor > average);
        
        return new QuestionThreeDtoResult
        {
            MinValue = min,
            MaxValue = max,
            DaysAboveAverage = daysAboveAverage
        };
    }
    
    //Desafio: Calcular a percentual de representação da distribuidora por estado
    // resultado: Retornar o percentual de representação da distribuidora por estado
    internal static Dictionary<string, decimal> Question4()
    {
        var faturamento = new Dictionary<string, decimal>
        {
            {"SP", 67836.43m},
            {"RJ", 36678.66m},
            {"MG", 29229.88m},
            {"ES", 27165.48m},
            {"Outros", 19849.53m}
        };
        
        decimal total = faturamento.Values.Sum();
        
        return faturamento.ToDictionary(
            r => r.Key,
            r => Math.Round(r.Value / total * 100, 2)
        );
    }
    
    // Desafio: Inverter uma string
    // resultado: Retornar a string invertida
    internal static string Question5(string str)
    {
        char[] chars = new char[str.Length];
        
        for (int i = 0; i < str.Length; i++)
        {
            chars[i] = str[str.Length - 1 - i];
        }
        
        return new string(chars);
    }
}