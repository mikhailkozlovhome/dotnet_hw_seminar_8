// Задача 3 * :
// Задайте две матрицы.
// Напишите программу, которая будет находить произведение двух матриц.

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

bool validate(int[,] firstArr, int[,] secondArr)
{
    return (firstArr.GetLength(1) == secondArr.GetLength(0));
}

int getElement(int [,] firstArr, int[,] secondArr, int row, int col)
{
    int element = 0;
    for (int i = 0; i < firstArr.GetLength(1); i++)
    {
        element += firstArr[row, i]*secondArr[i, col];
    }
    return element;
}

int[,] getMatrixProduct(int[,] firstArr, int[,] secondArr)
{
    int [,] productMatrix = new int[firstArr.GetLength(0), secondArr.GetLength(1)];
    for (int i = 0; i < productMatrix.GetLength(0); i++)
    {
        for (int j = 0; j < productMatrix.GetLength(1); j++)
        {
            productMatrix[i,j] = getElement(firstArr, secondArr, i, j);
        }
    }
    return productMatrix;
}


int m = inputInt("Введите количество строк 1-й матрицы");
int n = inputInt("Введите количество столбцов 1-й матрицы");
int min = inputInt("Введите минимальный порог случайных чисел");
int max = inputInt("Введите максимальный порог случайных чисел");
int[,] firstMatrix = GenerateArray(m, n, min, max);

m = inputInt("Введите количество строк 2-й матрицы");
n = inputInt("Введите количество столбцов 2-й матрицы");
int[,] secondMatrix = GenerateArray(m, n, min, max);

System.Console.WriteLine("Матрица А:");
printArray(firstMatrix);
System.Console.WriteLine("Матрица B:");
printArray(secondMatrix);

if (validate(firstMatrix, secondMatrix))
{
    System.Console.WriteLine("Матрица A*B:");
    printArray(getMatrixProduct(firstMatrix, secondMatrix));
}
else
{
    System.Console.WriteLine("Такие матрицы нельзя перемножить, так как количество столбцов матрицы А не равно количеству строк матрицы В.");
}