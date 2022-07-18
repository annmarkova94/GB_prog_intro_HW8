// Задайте прямоугольный двумерный массив. Напишите программу, которая будет находить строку с наименьшей суммой элементов.

TextColorGreen();
double minNumber = 0;
double maxNumber = 9;
double[,] matrix = GetMatrix(minNumber, maxNumber);
PrintMatrix(matrix);
Console.WriteLine();
PrintRowNumberWithMinSum(matrix);
Console.ResetColor();

//.............Specific method for this task..............//
void PrintRowNumberWithMinSum(double[,] matrix)
{
    double sumNum;
    double[] arrayOfSums = new double[matrix.GetLength(0)];
    for (int i = 0; i < matrix.GetLength(0); i++)   // create an array of sums
    {
        sumNum = 0;
        for (int j = 0; j < matrix.GetLength(1); j++)
            sumNum += matrix[i, j];
        arrayOfSums[i] = sumNum;
    }
    PrintArray(arrayOfSums);

    int rowWithSmallestSum = 0;
    for (int i = 1; i < arrayOfSums.Length; i++)   // find the smallest element in the array
    {
        if (arrayOfSums[i] < arrayOfSums[rowWithSmallestSum])
            rowWithSmallestSum = i;
    }
    Console.WriteLine($"The row with the smallest sum is: {rowWithSmallestSum + 1}");
}


//....................Basic methods......................//
void PrintMatrix(double[,] matrix)
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            Console.Write($"{Math.Round(matrix[i, j], 2),6}");
        }
        Console.WriteLine();
    }
}

void PrintArray(double[] array)
{
    Console.Write("[");
    Console.Write(string.Join("; ", array.Select(x => Math.Round(x, 2))));
    Console.WriteLine("]");
}

double[,] GetMatrix(double minNumber, double maxNumber)
{
    Console.Write("Enter number of ROWS for a new array: ");
    int nRows = EnterPositiveInteger();
    Console.Write("Enter number of COLUMNS for a new array: ");
    int nCols = EnterPositiveInteger();
    double[,] matrix = new double[nRows, nCols];
    var rnd = new Random();
    for (int i = 0; i < nRows; i++)
    {
        for (int j = 0; j < nCols; j++)
        {
            matrix[i, j] = rnd.NextDouble() * (maxNumber - minNumber) + minNumber;
        }
    }
    return matrix;
}

int EnterPositiveInteger()
{
    int number;
    while (!int.TryParse(Console.ReadLine(), out number) || number < 1)
    {
        TextColorRed();
        Console.Write("This is not a positive integer, try again: ");
        TextColorGreen();
    }
    return number;
}

void TextColorGreen()
{
    Console.ForegroundColor = ConsoleColor.DarkGreen;
}
void TextColorRed()
{
    Console.ForegroundColor = ConsoleColor.Red;
}