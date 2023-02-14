/*  Задача 60. ...Сформируйте трёхмерный массив из неповторяющихся двузначных чисел. 
Напишите программу, которая будет построчно выводить массив, добавляя индексы каждого элемента.
Массив размером 2 x 2 x 2
66(0,0,0) 25(0,1,0)
34(1,0,0) 41(1,1,0)
27(0,0,1) 90(0,1,1)
26(1,0,1) 55(1,1,1)   */

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

int[,,] InitMatrix(int rows, int columns, int cell)
{
    int[,,] matrix = new int[rows, columns, cell];
    Random rnd = new Random();
    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < columns; j++)
        {
            for (int z = 0; z < cell; z++)
            {
                matrix[i, j, z] = rnd.Next(10, 100);
            }

        }
    }
    return matrix;
}

/*
// проверяем уникальность элементов
void MatrixOfUniqueElements(int[,,] matrix)
{
    Dictionary<int, int> UniqueElements= new Dictionary<int, int>();
    int[,,] matrix = InitMatrix(countOfRows, countOfColumns, countOfCell);
    for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                for (int z = 0; z < matrix.GetLength(2); z++)
                {
                    if(MatrixOfUniqueElements.ContainsKey(matrix[i, j, z])) 
                        .......?
                }
            }
        }
}
*/

void PrintMatrix(int[,,] matrix)
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            for (int z = 0; z < matrix.GetLength(2); z++)
            {
                Console.Write($"{matrix[i, j, z]} ({i},{j},{z})  ");
            }
            Console.WriteLine();
        }
    }
}

int countOfRows = GetNumber("Введите кол-во строк:");
int countOfColumns = GetNumber("Введите кол-во столбцов:");
int countOfCell = GetNumber("Введите кол-во ячеек:");
int[,,] matrix = InitMatrix(countOfRows, countOfColumns, countOfCell);
PrintMatrix(matrix);
