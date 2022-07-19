// Задайте две матрицы. Напишите программу, которая будет находить произведение двух матриц.

TextColorGreen();
double minNumber = 0;
double maxNumber = 9;
double[,] matrix1 = GetMatrix(minNumber, maxNumber);
double[,] matrix2 = GetMatrix(minNumber, maxNumber);
PrintMatrix(matrix1);
Console.WriteLine();
PrintMatrix(matrix2);
Console.WriteLine();
PrintMatricesProduct(matrix1, matrix2);
Console.ResetColor();

//.............Specific methods for this task..............//
void PrintMatricesProduct(double[,] matrix1, double[,] matrix2)
{
    if (WhetherMatricesCanBeMiltiplied(matrix1, matrix2))
        PrintMatrix(MatricesProductIfTheyCanBeMultiplied(matrix1, matrix2));
    else
    {
        TextColorRed();
        Console.WriteLine("These matrices can't be multiplied because\nthe number of columns in matrix1 is not equal\nto the number of rows in matrix2.");
    }
}

bool WhetherMatricesCanBeMiltiplied(double[,] matrix1, double[,] matrix2)
{
    bool theyCanBeMiltiplied = false;
    if (matrix1.GetLength(1) == matrix2.GetLength(0))
        theyCanBeMiltiplied = true;
    return theyCanBeMiltiplied;
}

double[,] MatricesProductIfTheyCanBeMultiplied(double[,] matrix1, double[,] matrix2)
{
    double[,] matrix3Product = new double[matrix1.GetLength(0), matrix2.GetLength(1)];
    for (int i = 0; i < matrix1.GetLength(0); i++) // every row in matrix-1
        for (int j = 0; j < matrix2.GetLength(1); j++) // every column in matrix-2
            for (int k = 0; k < matrix1.GetLength(1); k++) // every column in matrix-1 and every row in matrix-2
                matrix3Product[i, j] += matrix1[i, k] * matrix2[k, j];
    return matrix3Product;
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
        for (int j = 0; j < nCols; j++)
            matrix[i, j] = rnd.NextDouble() * (maxNumber - minNumber) + minNumber;
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