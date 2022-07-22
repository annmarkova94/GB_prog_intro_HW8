// Сформируйте трёхмерный массив из неповторяющихся двузначных чисел.
// Напишите программу, которая будет построчно выводить массив, добавляя индексы каждого элемента.

TextColorGreen();
int minNumber = 10;
int maxNumber = 100;
int[,,] matrix3D = Get3DMatrix(minNumber, maxNumber);
Print3DMatrix(matrix3D);
Console.ResetColor();

//.............Specific methods for this task..............//
void Print3DMatrix(int[,,] matrix)
{
    for (int x = 0; x < matrix.GetLength(0); x++)
    {
        Console.WriteLine();
        for (int y = 0; y < matrix.GetLength(1); y++)
            for (int z = 0; z < matrix.GetLength(2); z++)
                Console.WriteLine($"{matrix[x, y, z]} ({x},{y},{z})");
    }
}

int[,,] Get3DMatrix(int minNumber, int maxNumber)
{
    Console.Write("Enter number of ROWS (X axis) for a new array: ");
    int nXaxis = EnterPositiveInteger();
    Console.Write("Enter number of COLUMNS (Y axis) for a new array: ");
    int nYaxis = EnterPositiveInteger();
    Console.Write("Enter number of DEPTH ROWS (Z axis) for a new array: ");
    int nZaxis = EnterPositiveInteger();
    int[,,] matrix3D = new int[nXaxis, nYaxis, nZaxis];
    var rnd = new Random();
    int newNumber;
    for (int x = 0; x < nXaxis; x++)
        for (int y = 0; y < nYaxis; y++)
            for (int z = 0; z < nZaxis; z++)
            {
                newNumber = rnd.Next(minNumber, maxNumber);
                while (WhetherNumberIn3DMatrix(matrix3D, newNumber, x, y, z))
                    newNumber = rnd.Next(minNumber, maxNumber);
                matrix3D[x, y, z] = newNumber;
            }
    return matrix3D;
}

// Whether the number is in a 3D matrix, check only elemets on positions from [0,0,0] to [x,y,z]
bool WhetherNumberIn3DMatrix(int[,,] matrix3D, int number, int x, int y, int z)
{
    bool InMatrix = false;
    for (int a = 0; a < x; a++)
        for (int b = 0; b < y; b++)
            for (int c = 0; c < z; c++)
                if (matrix3D[a, b, c] == number)
                {
                    InMatrix = true;
                    return InMatrix;
                }
    return InMatrix;
}

//....................Basic methods......................//
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