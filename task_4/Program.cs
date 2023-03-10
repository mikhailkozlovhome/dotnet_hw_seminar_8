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

int[,] GenerateArray (int rowCol)
{
    int[,] result = new int[rowCol, rowCol];
    int element = 0;
    int row = 0;
    int col = 0;
    bool isRow = true;

  for (int i = 1; i <= result.GetLength(0)*result.GetLength(1); i++)
  {
        System.Console.WriteLine($"row={row}    col={col}   i={i}");
        result[row, col] = i;
        if ( col + 1 < result.GetLength(1) && result[row, col + 1] == 0 && row - 1 >=0 && result[row - 1, col] != 0)
        {
            col++;
            continue;
        }
        if (row + 1 < result.GetLength(0) && result[row+1, col] == 0)
        {
            row++;
            continue;
        }
        if (col - 1 >= 0 && result[row, col - 1] == 0)
        {
            col--;
            continue;
        }
        if (row - 1 >= 0 && result[row - 1, col] == 0)
        {
            row--;
            continue;
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


int m = inputInt("Введите количество строк и столбцов квадратного массива");

int[,] matrix = GenerateArray(m);
FillArray();
printArray(matrix);
