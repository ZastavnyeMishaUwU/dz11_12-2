namespace dz11_12_2
{
    internal class Program
    {
        static void Main()
        {
            Console.Write("Введіть логічний вираз: ");
            string input = Console.ReadLine();

            try
            {
                bool result = EvaluateExpression(input);
                Console.WriteLine($"Результат: {result}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Помилка: {ex.Message}");
            }
        }

        static bool EvaluateExpression(string expression)
        {
           
            string[] operators = { "<=", ">=", "==", "!=", "<", ">" };

            foreach (var op in operators)
            {
                if (expression.Contains(op))
                {
                    // Розділяє на два числа
                    string[] parts = expression.Split(new[] { op }, StringSplitOptions.None);

                    if (parts.Length != 2)
                        throw new ArgumentException("Некоректний вираз.");


                    if (!int.TryParse(parts[0].Trim(), out int left))
                        throw new ArgumentException("Некоректне перше число.");
                    if (!int.TryParse(parts[1].Trim(), out int right))
                        throw new ArgumentException("Некоректне друге число.");

                    // обчислення
                    return op switch
                    {
                        "<" => left < right,
                        ">" => left > right,
                        "<=" => left <= right,
                        ">=" => left >= right,
                        "==" => left == right,
                        "!=" => left != right,
                        _ => throw new ArgumentException("Непідтримуваний")
                    };
                }
            }

            throw new ArgumentException("не знайдено.");
        }
    }
}
