// Задача 58: Задайте две матрицы. Напишите программу, которая будет находить произведение двух матриц.
// Например, даны 2 матрицы:
// 2 4 | 3 4
// 3 2 | 3 3
// Результирующая матрица будет:
// 18 20
// 15 18


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
int ScalarProduct(int[] array1, int[] array2)
{
    int result = 0;
    for (int i = 0; i < array1.Length; i++)
        result += array1[i]*array2[i];
    return result;    
}
int[,] MatrixProd(int[,] matrix1, int[,] matrix2)
{
    int[,] result = new int[matrix1.GetLength(0),matrix2.GetLength(1)];
    for (int j = 0; j < result.GetLength(1); j++)
    {
        for (int i = 0; i <  result.GetLength(0); i++)
        {
            int[] row = new int [result.GetLength(0)];
            int[] col = new int [result.GetLength(1)];

            for (int k = 0; k < result.GetLength(0); k++)
              row[k] = matrix1[j,k];

            for (int k = 0; k < result.GetLength(1); k++)
                col[k] = matrix2[k,i];

            result[j,i] = ScalarProduct(row, col);
        }             
    } 
    return result;
}


Console.Clear();

// Интерфейс закомментируем для простоты проверки

// Console.Write("Введите количество строк первой матрицы : ");
// int rows1 = int.Parse(Console.ReadLine());
// Console.Write("Введите количество столбцов первой матрицы: ");
// int columns1 = int.Parse(Console.ReadLine());
// Console.Write("Введите количество строк второй матрицы : ");
// int rows2 = int.Parse(Console.ReadLine());
// Console.Write("Введите количество столбцов второй матрицы: ");
// int columns2 = int.Parse(Console.ReadLine());
// if (columns1 != rows2)
// {
//     Console.WriteLine("Число столбцов первой матрицы должно равняться числу строк второй матрицы");
//     return;
// }

// int[,] matrix1 = CreateIntMatrix(rows1, columns1, 0, 9);
// int[,] matrix2 = CreateIntMatrix(rows2, columns2, 0, 9);

// Для отладки сделаем константами
int[,] matrix1 = new int[,]
                {{2, 4},
                 {3, 2}};

int[,] matrix2 = new int[,]
                {{3, 4},
                 {3, 3}};

Console.WriteLine("Матрица 1 :");
PrintIntMatrix(matrix1);
Console.WriteLine("Матрица 2 :");
PrintIntMatrix(matrix2);
Console.WriteLine("Произведение матриц:");
PrintIntMatrix(MatrixProd(matrix1, matrix2));