// Задача 62. Напишите программу, которая заполнит спирально массив 4 на 4.
// Например, на выходе получается вот такой массив:
// 01 02 03 04
// 12 13 14 05
// 11 16 15 06
// 10 09 08 07

void PrintIntMatrix(int[,] matrix)
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
            Console.Write($"{matrix[i, j]}\t");
        Console.WriteLine();
    }
}

void FillMatrixRightSpiral(int[,] matrix)
{
    int row = 0,                            //позиция курсора
        col = 0,    
        stepX = 1,                          //шаг - наращиваем по числу витков, при смене направления - скидываем в 0
        stepY = 0,                          // скинут в ноль - т.к. начинаем по горизонтали
        turnCount = 0,                      // считаем сколько раз повернули
        turnFlag =  matrix.GetLength(1);    // счетчик пройденных шагов - уменьшаем с каждым шагом. Как только достигаем нуля - вычисляем сколько идти до следующей грани

    for (int i = 0; i < matrix.Length; i++)
    {
        matrix[row, col] = i + 1;
        if (--turnFlag == 0)                //если кусор дошел до заполненного края - поворачиваем. 
        {
            turnFlag = matrix.GetLength(1) * (turnCount % 2)                 // вычисляем сколько идти до следующей грани
                     + matrix.GetLength(0) * ((turnCount + 1) % 2)
                     - (turnCount / 2 - 1) - 2; 
            int tmp = stepX;
            stepX = -stepY;                                                 // меняем направление шага                
            stepY = tmp;
            turnCount++;                                                    //увеличиваем счетчик поворотов
        }
        col += stepX;
        row += stepY;
    }
}
Console.Clear();
Console.Write("Введите количество строк массива: ");
int x = int.Parse(Console.ReadLine());
Console.Write("Введите количество столбцов массива: ");
int y = int.Parse(Console.ReadLine());
int[,] array = new int[x, y];
FillMatrixRightSpiral(array);
PrintIntMatrix(array);