
// Доп Задача 61: Показать треугольник Паскаля.
// Сделать вывод в виде равнобедренного треугольника.На вход дается колличетсво строк в треугольнике.

double Factorial(int n)
{
    double result = 1;
    for (int i = 1; i <= n; i++)
        result *= i;
    return result;
}
void PrintPascalTriangle(int n)
{
    for (int i = 0; i < n; i++)
    {   
        for (int c = 0; c <= (n - i); c++)                                      // создаём после каждой строки n-i отступов от левой стороны консоли, чем ниже строка, тем меньше отступ
        {
            Console.Write("  ");
        }
        for (int c = 0; c <= i; c++)
        {
            Console.Write("   ");                                               // создаём пробелы между элементами треугольника
            Console.Write(Factorial(i) / (Factorial(c) * Factorial(i - c)));    //формула вычисления элементов треугольника
        }
        Console.WriteLine();                                                    // после каждой строки с числами  - новая строка
    }
}

Console.Clear();
Console.Write("Введите число строк треугольника Паскаля: ");
int rows = int.Parse(Console.ReadLine());
PrintPascalTriangle(rows);

