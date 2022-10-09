// Задача 54: Задайте двумерный массив. Напишите программу, которая упорядочит по убыванию элементы каждой строки двумерного массива.
// Например, задан массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// В итоге получается вот такой массив:
// 7 4 2 1
// 9 5 3 2
// 8 4 4 2

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

void SortArrayDesc(int[] array)
{
    int temp;
    for (int i = 0; i < array.Length; i++)
    {
        for (int j = i + 1; j < array.Length; j++)
        {
            if (array[i] < array[j])
            {
                temp = array[i];
                array[i] = array[j];
                array[j] = temp;
            }                   
        }            
    }
}

void SortMatrixRowValues(int[,] matrix)
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        int[] rowArray = new int[matrix.GetLength(1)];
        for (int j = 0; j < matrix.GetLength(1); j++)   
            rowArray[j] = matrix[i,j];
        SortArrayDesc(rowArray);
        for (int j = 0; j < matrix.GetLength(1); j++)
            matrix[i,j] = rowArray[j];
    }
}

Console.Clear();
Console.Write("Введите количество строк массива: ");
int rows = int.Parse(Console.ReadLine());
Console.Write("Введите количество столбцов массива: ");
int columns = int.Parse(Console.ReadLine());
int[,] array = CreateIntMatrix(rows, columns, 0, 10);
Console.WriteLine("Входной массив:");
PrintIntMatrix(array);
SortMatrixRowValues(array);
Console.WriteLine("Массив после сортировки строк по убыванию:");
PrintIntMatrix(array);