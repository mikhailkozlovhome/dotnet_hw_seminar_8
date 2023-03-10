// Задача 1:
// Задайте двумерный массив.
// Напишите программу, которая упорядочивает по убыванию элементы каждой строки двумерного массива.

int inputInt(string msg)
{
    int value;
    System.Console.Write($"{msg} -> ");
    if (int.TryParse(Console.ReadLine(), out value))
    {
        return value;
    }
    System.Console.WriteLine("Введенно неверное значение!");
    Environment.Exit(999);
    return 0;
}

int[,] GenerateArray (int row, int col, int minValue, int maxValue)
{
    int[,] result = new int[row, col];
    Random rnd = new Random();

    for (int i = 0; i < result.GetLength(0); i++)
    {
        for (int j = 0; j < result.GetLength(1); j++)
        {
            result[i, j] = rnd.Next(minValue, maxValue + 1);
        }
    }

    return result;
}

void printArray(int[,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            System.Console.Write($"{array[i, j]}\t");   
        }
        System.Console.WriteLine();
    }
    System.Console.WriteLine();
}


int[,] sortMatrixRows(int[,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            for (int k = 0; k < array.GetLength(1) - j - 1; k++)
            {
                if (array[i, k] < array[i,k+1])
                {
                    (array[i, k], array[i, k + 1]) = (array[i, k + 1], array[i, k]);
                }
            }
        }
    }
    return array;
}

int m = inputInt("Введите количество строк");
int n = inputInt("Введите количество столбцов");
int min = inputInt("Введите минимальный порог случайных чисел");
int max = inputInt("Введите максимальный порог случайных чисел");

int[,] matrix = GenerateArray(m, n, min, max);
printArray(matrix);

matrix = sortMatrixRows(matrix);

printArray(matrix);

