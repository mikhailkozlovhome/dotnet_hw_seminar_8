// Задача 2:
// Задайте прямоугольный двумерный массив.
// Напишите программу, которая будет находить строку с наименьшей суммой элементов.


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

int getRowSum(int[,] array, int row)
{
    int sum = 0;
    for (int i = 0; i < array.GetLength(1); i++)
    {
        sum += array[row, i];
    }
    return sum;
}

int rowMinSumElements(int[,] array)
{
    int minRow = 0;
    int minSum = getRowSum(array, 0);
    int tmpSum = 0;

    for (int i = 1; i < array.GetLength(0); i++)
    {
        tmpSum = getRowSum(array, i);
        if (tmpSum < minSum)
        {
            minSum = tmpSum;
            minRow = i;
        }
    }
    return minRow;
}

int m = inputInt("Введите количество строк");
int n = inputInt("Введите количество столбцов");
int min = inputInt("Введите минимальный порог случайных чисел");
int max = inputInt("Введите максимальный порог случайных чисел");

int[,] matrix = GenerateArray(m, n, min, max);
printArray(matrix);
System.Console.WriteLine($"Индекс строки с наименьшей суммой равен {rowMinSumElements(matrix)}");