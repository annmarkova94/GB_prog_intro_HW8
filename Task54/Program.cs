// Задача 54: Задайте двумерный массив. Напишите программу, которая упорядочит по убыванию элементы каждой строки двумерного массива

TextColorGreen();
double minNumber = 0;
double maxNumber = 9;
double[,] matrix = GetMatrix(minNumber, maxNumber);
PrintMatrix(matrix);
Console.WriteLine();
SortDescendingInsideRows(matrix);
PrintMatrix(matrix);
Console.ResetColor();

//.............Specific method for this task..............//
// I am using Selection sort
void SortDescendingInsideRows(double[,] matrix)
{
    double help;
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1) - 1; j++)
        {
            int minColumn = j;
            for (int k = j + 1; k < matrix.GetLength(1); k++)
            {
                if (matrix[i, k] > matrix[i, minColumn])
                    minColumn = k;
            }
            help = matrix[i, j];
            matrix[i, j] = matrix[i, minColumn];
            matrix[i, minColumn] = help;
        }
    }
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


