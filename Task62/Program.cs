// Заполните спирально массив 4 на 4

TextColorGreen();
int[,] matrix = GetMatrixInSpiral();
PrintMatrix(matrix);
Console.ResetColor();

//....................Specific method for this task......................//
int[,] GetMatrixInSpiral()
{
    Console.Write("To create matrix of size X*X, enter X: ");
    int N = EnterPositiveInteger();
    Console.WriteLine("Enter numbers to fill the matrix:");
    int[,] matrix = new int[N, N];
    for (int shift = 0; shift < N / 2 + N % 2; shift++)
    {
        //..........................................//
        for (int i = shift; i <= N - shift - 1; i++)
        {
            Console.Write($"--1st cycle-- ({shift}, {i}) = ");
            matrix[shift, i] = int.Parse(Console.ReadLine());
        }
        //..........................................//
        for (int i = shift + 1; i <= N - shift - 2; i++)
        {
            Console.Write($"--2nd cycle-- ({i}, {N - shift - 1}) = ");
            matrix[i, N - shift - 1] = int.Parse(Console.ReadLine());
        }
        //..........................................//
        if (!(N % 2 == 1 && shift == N / 2 + N % 2 - 1))
        {
            for (int i = N - shift - 1; i >= shift; i--)
            {
                Console.Write($"--3rd cycle-- ({N - shift - 1}, {i}) = ");
                matrix[N - shift - 1, i] = int.Parse(Console.ReadLine());
            }
        }
        //..........................................//
        for (int i = N - shift - 2; i >= shift + 1; i--)
        {
            Console.Write($"--4th cycle-- ({i}, {shift}) = ");
            matrix[i, shift] = int.Parse(Console.ReadLine());
        }
        //..........................................//
    }
    return matrix;
}


//....................Basic methods......................//
void PrintMatrix(int[,] matrix)
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            Console.Write($"{matrix[i, j],4}");
        }
        Console.WriteLine();
    }
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