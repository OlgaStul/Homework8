/*  Задача 56: Задайте прямоугольный двумерный массив. Напишите программу, которая будет 
находить строку с наименьшей суммой элементов.
Например, задан массив:
1 4 7 2
5 9 2 3
8 4 2 4
5 2 6 7
Программа считает сумму элементов в каждой строке и выдаёт номер строки с наименьшей суммой элементов: 1 строка   */

int GetNumber(string message)
{
    int result = 0;
    while (true)
    {
        Console.WriteLine(message);
        if (int.TryParse(Console.ReadLine(), out result) && result > 0)
        {
            break;
        }
        else
        {
            Console.WriteLine("Ввели не корректное число. Повторите ввод.");
        }
    }
    return result;
}

int[,] InitMatrix(int rows, int columns)
{
    int[,] matrix = new int[rows, columns];
    Random rnd = new Random();
    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < columns; j++)
        {
            matrix[i, j] = rnd.Next(1, 10);
        }
    }
    return matrix;
}

void PrintMatrix(int[,] matrix)
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            Console.Write($"{matrix[i, j]} ");
        }
        Console.WriteLine();
    }
    Console.WriteLine();
}

//считаем сумму элементов в каждой строке и сохраняем  в массив 
int[] SumOfLines(int[,] matrix)
{
    int[] sumOfLines = new int[matrix.GetLength(0)];
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        int sum = 0;
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            sum = sum + matrix[i, j];
        }
        sumOfLines[i] = sum;
    }
    return sumOfLines;
}

// находим строку с минимальной суммой
int MinIndex(int[] SumOfLines)
{
    int minI = 0;
    int minSum = SumOfLines[0];
    for (int i = 0; i < SumOfLines.Length; i++)
    {
        if (SumOfLines[i] < minSum)
        {
            minSum = SumOfLines[i];
            minI = i;
        }
    }
    return minI;
}

int countOfRows = GetNumber("Введите кол-во строк прямоугольной матрицы:");
int countOfColumns = GetNumber("Введите кол-во столбцов прямоугольной матрицы:");
int[,] matrix = InitMatrix(countOfRows, countOfColumns);
PrintMatrix(matrix);

if(countOfRows == countOfColumns)
    Console.WriteLine("Количество строк не должно равняться количеству столбцов!");
else
{
    int[] sumOfLines = SumOfLines(matrix);
    int minIndex = MinIndex(sumOfLines);
    Console.Write($"{minIndex} строка имеет наименьшую сумму элементов.");
}
