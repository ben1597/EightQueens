using System;
int count = 0;
char[,] array = new char[8, 8];
startPlaceQueen(0);
Console.WriteLine($"Total Count:{count}");

bool startPlaceQueen(int row)
{
    if (row == 8)
    {
        count++;
        printArray();
        return true;
    }

    bool res = false;
    for (int col = 0; col < 8; col++)
    {
        if (checkTop(row, col) && checkLeftUp(row, col)
            && checkRightUp(row, col))
        {
            array[row, col] = 'Q';
            res = startPlaceQueen(row + 1) || res;
            array[row, col] = '.';
        }
    }
    return res;
}

bool checkTop(int row, int col)
{
    for (int i = 0; i < row; i++)
        if (array[i, col] == 'Q') return false;

    return true;
}

bool checkLeftUp(int row, int col)
{
    for (int i = row, j = col; i >= 0 && j >= 0; i--, j--)
        if (array[i, j] == 'Q') return false;

    return true;
}

bool checkRightUp(int row, int col)
{
    for (int i = row, j = col; i >= 0 && j < 8; i--, j++)
        if (array[i, j] == 'Q') return false;

    return true;
}

void printArray()
{
    Console.WriteLine("Solution:");
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            Console.Write(array[i, j]);
        }
        Console.WriteLine();
    }
    Console.WriteLine();
}


