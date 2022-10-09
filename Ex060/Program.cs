// Задача 60. ...Сформируйте трёхмерный массив из неповторяющихся двузначных чисел. 
// Напишите программу, которая будет построчно выводить массив, добавляя индексы каждого элемента.
// Массив размером 2 x 2 x 2
// 66(0,0,0) 25(0,1,0)
// 34(1,0,0) 41(1,1,0)
// 27(0,0,1) 90(0,1,1)
// 26(1,0,1) 55(1,1,1)


bool AllreadyContains(int[,,] array, int value)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            for (int k = 0; k < array.GetLength(2); k++)
            {
                if (array[i, j, k] == value)
                    return true;
            }
        }
    }
    return false;
}

int[,,] CreateInt3DMatrix(int xCount, int yCount, int zCount, int minValue, int maxValue)
{
    int[,,] result = new int[xCount, yCount, zCount];
    for (int i = 0; i < xCount; i++)
    {
        for (int j = 0; j < yCount; j++)
        {
            for (int k = 0; k < zCount; k++)
            {
                int tmp = new Random().Next(minValue, maxValue + 1);
                while (AllreadyContains(result, tmp))  //число не должно повторяться - ищем его в массиве, если уже есть - генерируем новое
                    tmp = new Random().Next(minValue, maxValue + 1);
                result[i, j, k] = tmp;
            }
        }
    }
    return result;
}

void PrintInt3DMatrix(int[,,] matrix)
{
    for (int k = 0; k < matrix.GetLength(2); k++)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
                Console.Write($"{matrix[i, j, k]}({i},{j},{k})\t");
            Console.WriteLine();
        }
        Console.WriteLine("==========");
    }
}


Console.Clear();
Console.Write("Введите количество строк массива: ");
int x = int.Parse(Console.ReadLine());
Console.Write("Введите количество столбцов массива: ");
int y = int.Parse(Console.ReadLine());
Console.Write("Введите количество этажей массива: ");
int z = int.Parse(Console.ReadLine());
Console.Write("Число знаков в элементе массива: ");
int n = int.Parse(Console.ReadLine());

if (Math.Pow(10, n) < x * y * z)
{ // Проверка от зацикливания в поиске уникальных значений
    Console.WriteLine($"Невозможно генерировать {x * y * z} уникальных значений в диапазоне {Math.Pow(10, n) / 10} - {Math.Pow(10, n) - 1}");
    return;
}

int[,,] array = CreateInt3DMatrix(x, y, z, Convert.ToInt32(Math.Pow(10, n) / 10), Convert.ToInt32(Math.Pow(10, n)) - 1);
Console.WriteLine("Сформирован массив: ");
Console.WriteLine("==========");
PrintInt3DMatrix(array);
