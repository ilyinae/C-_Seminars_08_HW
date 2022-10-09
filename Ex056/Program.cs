// Задача 56: Задайте прямоугольный двумерный массив. Напишите программу, которая будет находить строку с наименьшей суммой элементов.
// Например, задан массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// 5 2 6 7
// Программа считает сумму элементов в каждой строке и выдаёт номер строки с наименьшей суммой элементов: 1 строка

int[,] CreateIntMatrix(int rowsCount, int colsCount, int minValue, int maxValue)
{
    int[,] result = new int[rowsCount, colsCount];
    for (int i = 0; i < rowsCount; i++)
    {
        for (int j = 0; j < colsCount; j++)
            result[i, j] = new Random().Next(minValue, maxValue + 1);
    }
    return result;
}

void PrintIntMatrix(int[,] matrix)
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
            Console.Write($"{matrix[i, j]}\t");
        Console.WriteLine();
    }
}

int CalculateRowSumm(int[] array)
{
    int summ = 0;
    for (int i = 0; i < array.Length; i++)
        summ += array[i];
    return summ;    
}

int FindRowWithMinSumm(int[,] matrix)
{
    int minRowSumm = int.MaxValue;
    int result = -1;
    for (int i = 0; i < matrix.GetLength(0); i++)
    {       
        int[] rowArray = new int[matrix.GetLength(1)];
        for (int j = 0; j < matrix.GetLength(1); j++)   
            rowArray[j] = matrix[i,j];
        int rowSumm = CalculateRowSumm(rowArray);
        if (rowSumm < minRowSumm)
        {
            minRowSumm = rowSumm;
            result = i+1;
        }    
    }
    return result;
}

Console.Clear();
Console.Write("Введите количество строк массива: ");
int rows = int.Parse(Console.ReadLine());
Console.Write("Введите количество столбцов массива: ");
int columns = int.Parse(Console.ReadLine());
int[,] array = CreateIntMatrix(rows, columns, 0, 9);
Console.WriteLine("Входной массив:");
PrintIntMatrix(array);
Console.WriteLine($"Строка с наименьшей сумой элементов: {FindRowWithMinSumm(array)}");

