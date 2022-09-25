/*
Урок 6. Двумерные массивы и рекурсия
*/

/*
Общие методы
*/
// Организация завершения работы с модулем
bool CheckExit(dynamic num)
{
    if (num == 0)
    {
        Console.WriteLine("\nРабота с программой завершена, До встречи!\n");
        return true;
    }
    return false;
}

// // Создание массива заполненных случайно сгенерированными целыми числами
// int[] GetArrowRandNumber(int size, int minRnd, int maxRnd)
// {
//     int[] randNumber = new int[size];
//     Random int_rnd = new Random();
//     int i;
//     for (i = 0; i < size; i++)
//         randNumber[i] = int_rnd.Next(minRnd, maxRnd + 1);
//     return randNumber;
// }

// // Вывод содержимого массива
// void ShowArr(int[] arr, string txt = "")
// {
//     if (txt.Length > 0) Console.WriteLine(txt);
//     bool one_item = true;
//     string sep;
//     foreach (var item in arr)
//     {
//         sep = one_item ? "[" : ", ";
//         one_item = false;
//         Console.Write($"{sep}{item}");
//     }
//     Console.Write("]\n");
// }


/*-----------------------------------------------------------------
Задача 41: Пользователь вводит с клавиатуры M чисел. 
Посчитайте, сколько чисел больше 0 ввёл пользователь.
0, 7, 8, -2, -2 -> 2
1, -7, 567, 89, 223-> 3
-------------------------------------------------------------------
*/
int CountNumbersPlus(int contNumbers)
{
    int countNumbersPlus = 0;
    string inputNumbers = string.Empty;
    Console.WriteLine($"Введите последовательно {contNumbers} чисел:");
    for (int i = 0; i < contNumbers; i++)
    {
        Console.Write($"{i + 1}) -> ");
        int inputNumber = Convert.ToInt32(Console.ReadLine());
        inputNumbers += $"{inputNumber.ToString()}, ";
        countNumbersPlus += (inputNumber > 0) ? 1 : 0;
    }
    Console.WriteLine($"Введены числа: ({inputNumbers}).");
    return countNumbersPlus;
}

// Основное тело программы.
Console.WriteLine(@"Задача-41. Считаем количество положительных чисел введенных с клавиатуры");
Console.WriteLine("---");
Console.WriteLine("'0' - для завершения:");

while (true)
{
    Console.Write("\nУкажите сколько чисел будет введено, или '0' - для завершения: ");
    int contNumbers = Convert.ToInt32(Console.ReadLine());

    if (CheckExit(contNumbers)) break;

    Console.WriteLine($"Чисел больше нуля = {CountNumbersPlus(contNumbers)}");
}
// *** Конец Задачи 41 ***


/* Задача 42 (из семинара): 
Не используя рекурсию, выведите первые N чисел Фибоначчи. 
Первые два числа Фибоначчи: a и b
*/
IEnumerable<int> Fibonacci(int a, int b)
{
    int temp;
    while (true)
    {
        yield return a;
        temp = a;
        a = b; b = temp + a;
    }
}

// Основное тело программы.
Console.WriteLine(@"Задача-42. Выведите первые N чисел Фибоначчи");
Console.WriteLine("---");
Console.WriteLine("'0' - для завершения:");

Console.Write("Введите первое число ряда Фибоначчи (a): ");
int fibo_a = Convert.ToInt32(Console.ReadLine());
Console.Write("Введите второе число ряда Фибоначчи (b): ");
int fibo_b = Convert.ToInt32(Console.ReadLine());

while (true)
{
    Console.Write("\nСколько вывести чисел ряда Фибоначчи, или '0' - для завершения: ");
    int fibo_N = Convert.ToInt32(Console.ReadLine());

    if (CheckExit(fibo_N)) break;

    Console.WriteLine();
    int ind = 1;
    foreach (int fibo_next in Fibonacci(fibo_a, fibo_b))
    {
        Console.Write($"{fibo_next}, ");
        if (ind > fibo_N) break;
        ++ind;
    }
}
// *** Конец Задачи 42 ***


/*-----------------------------------------------------------------
Задача 43: Напишите программу, которая найдёт точку пересечения двух прямых, 
заданных уравнениями y = k1 * x + b1, y = k2 * x + b2; 
значения b1, k1, b2 и k2 задаются пользователем.
b1 = 2, k1 = 5, b2 = 4, k2 = 9 -> (-0,5; -0,5)
-------------------------------------------------------------------
*/
string FindIntersecPoint(double b1, double k1, double b2, double k2)
// Формула для расчета координат пересечения:
// Xi = (b2-b1) / (k1-k2)
// Yi = (b2*k1 - b1*k2) / (k1-k2)
{
    if (k1 == k2) return $"прямые ({b1}, {k1}) и  ({b2}, {k2}) НЕ пересекаются";
    double xi = Math.Round((b2 - b1) / (k1 - k2), 2);
    double yi = Math.Round((b2 * k1 - b1 * k2) / (k1 - k2), 2);
    return $"({xi.ToString()}; {yi.ToString()})";
}

// Основное тело программы.
Console.WriteLine(@"Задача-43. Ищем точку пересечения 2-х прямых на координатной плоскости");
Console.WriteLine("---");
Console.WriteLine("'0' - для завершения:");

while (true)
{
    Console.WriteLine("\nКоординаты первой прямой (b1, k1): ");
    Console.Write("b1 -> ");
    double b1 = Convert.ToInt32(Console.ReadLine());
    Console.Write("k1 -> ");
    double k1 = Convert.ToInt32(Console.ReadLine());

    Console.Write("Координаты второй прямой (b1, k1): ");
    Console.Write("\nb2 -> ");
    double b2 = Convert.ToInt32(Console.ReadLine());
    Console.Write("k2 -> ");
    double k2 = Convert.ToInt32(Console.ReadLine());

    Console.WriteLine($"Точка пересечения => {FindIntersecPoint(b1, k1, b2, k2)}");

    Console.Write("\nЕще разок? 1 - ДА; 0 - для выхода\n=> ");
    int cont = Convert.ToInt32(Console.ReadLine());
    if (CheckExit(cont)) break;

}
// *** Конец Задачи 43 ***
