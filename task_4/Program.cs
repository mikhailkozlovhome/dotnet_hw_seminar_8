// Задача 4 * :
// Напишите программу, которая заполнит спирально квадратный массив.

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

int[,] GenerateArray(int rowCol)
{
    int[,] result = new int[rowCol, rowCol];
    int element = 0;
    int row = 0;
    int col = -1;
    int n = result.GetLength(1); //Размер витка
    while (element < result.Length)
    {
        for (int i = 0; i < n; i++)
        {
            element++;
            col ++;
            result[row, col] = element;     
        }
        for (int i = 1; i < n; i++)
        {
            element++;
            row ++;
            result[row, col] = element;
        }
        for (int i = 1; i < n; i++)
        {
            element++;
            col --;
            result[row, col] = element;
        }
        for (int i = 2; i < n; i++)
        {
            element++;
            row --;
            result[row, col] = element;
        }
        n -= 2;
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


int m = inputInt("Введите количество строк и столбцов квадратного массива");

int[,] matrix = GenerateArray(m);
printArray(matrix);
