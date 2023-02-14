/*  Задача 58: Задайте две матрицы. Напишите программу, которая будет находить произведение двух матриц.
Например, даны 2 матрицы:
2 4 | 3 4
3 2 | 3 3
Результирующая матрица будет:
18 20
15 18  */

int GetNumber(string message)
{
    int result = 0;
    while(true)
    {
        Console.WriteLine(message);
        if(int.TryParse(Console.ReadLine(), out result) && result > 0)
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
            matrix[i,j] = rnd.Next(1, 10);
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
            Console.Write($"{matrix[i,j]} ");
        }
        Console.WriteLine();
    }
    Console.WriteLine();
}

int[,] MultiplicationMatrix(int[,] firstMatrix, int[,] secondMatrix)
{
    int[,] finalMatrix = new int[firstMatrix.GetLength(0), secondMatrix.GetLength(1)];
    for (int i = 0; i < firstMatrix.GetLength(0); i++)
    {
        for (int j = 0; j < secondMatrix.GetLength(1); j++)
        {
            int sumElement = 0;
            for (int n = 0; n < secondMatrix.GetLength(1); n++)
            {
                sumElement = sumElement + firstMatrix[i, n] * secondMatrix[n, j];
            }
            finalMatrix[i,j] = sumElement;
        }
    }
    return finalMatrix;
}

int firstcountOfRows = GetNumber("Введите кол-во строк первой матрицы:");
int firstcountOfColumns = GetNumber("Введите кол-во столбцов первой матрицы:");
int secondcountOfRows = GetNumber("Введите кол-во строк второй матрицы:");
int secondcountOfColumns = GetNumber("Введите кол-во столбцов второй матрицы:");
int[,] firstMatrix = InitMatrix(firstcountOfRows, firstcountOfColumns);
int[,] secondMatrix = InitMatrix(secondcountOfRows, secondcountOfColumns);
PrintMatrix(firstMatrix);
PrintMatrix(secondMatrix);

if(firstcountOfRows == secondcountOfColumns)
    {
        int[,] finalMatrix = MultiplicationMatrix(firstMatrix, secondMatrix);
        PrintMatrix(finalMatrix);
    }
else
{
    Console.WriteLine("Невозможно выполнить произведение матриц.");
    Console.WriteLine("Количество строк первой матрицы должно быть равным количеству столбцов второй матрицы.");
}