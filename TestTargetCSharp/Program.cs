// See https://aka.ms/new-console-template for more information

using TestTargetCSharp.Dtos;

namespace TestTargetCSharp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Questão 1
            int soma = Services.QuestionService.Question1();
            
            Console.WriteLine("Questão 1: ");
            Console.WriteLine("Soma dos números de 1 a 13: " + soma);
            Console.WriteLine("\n");
            
            // Questão 2
            bool IsInsideFibonacci = Services.QuestionService.Question2(13);
            Console.WriteLine("Questão 2: ");
            Console.WriteLine("O número 13 pertence à sequência de Fibonacci: " + (IsInsideFibonacci ? "Sim" : "Não"));
            Console.WriteLine("\n");
            
            // Questão 3
            QuestionThreeDtoResult result = Services.QuestionService.Question3();
            Console.WriteLine("Questão 3: ");
            Console.WriteLine("Menor valor de faturamento do mês: " + result.MinValue);
            Console.WriteLine("Maior valor de faturamento do mês: " + result.MaxValue);
            Console.WriteLine("Número de dias do mês em que o valor do faturamento diário foi superior à média mensal: " + result.DaysAboveAverage);
            Console.WriteLine("\n");
            
            // Questão 4
            var percentual = Services.QuestionService.Question4();
            Console.WriteLine("Questão 4: ");
            Console.WriteLine("O percentual por estado é: ");
            foreach (var item in percentual)
            {
                Console.WriteLine($"Estado: {item.Key}, Percentual: {item.Value}%");
            }
            Console.WriteLine("\n");
            
            // Questão 5
            string inverterString = Services.QuestionService.Question5("Teste");
            Console.WriteLine("Questão 5: ");
            Console.WriteLine("String invertida: " + inverterString);
        }
    }
}

