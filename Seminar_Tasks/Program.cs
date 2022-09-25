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

// Создание массива заполненных случайно сгенерированными целыми числами
int[] GetArrowRandNumber(int size, int minRnd, int maxRnd)
{
    int[] randNumber = new int[size];
    Random int_rnd = new Random();
    int i;
    for (i = 0; i < size; i++)
        randNumber[i] = int_rnd.Next(minRnd, maxRnd + 1);
    return randNumber;
}

// Вывод содержимого массива
void ShowArr(int[] arr, string txt = "")
{
    if (txt.Length > 0) Console.WriteLine(txt);
    bool one_item = true;
    string sep;
    foreach (var item in arr)
    {
        sep = one_item ? "[" : ", ";
        one_item = false;
        Console.Write($"{sep}{item}");
    }
    Console.Write("]\n");
}


/* Задача 40: Напишите программу, которая перевернёт одномерный массив 
(последний элемент будет на первом месте, а первый - на последнем и т.д.)
- РЕВЕРС массива
*/

int[] ReverseArr(int[] arr)
{
    int temp;
    for (int i = 0, j = arr.Length - 1; i < j; i++, j--)
    {
        temp = arr[i];
        arr[i] = arr[j];
        arr[j] = temp;
    }
    return arr;
}

// Основное тело программы.
Console.WriteLine(@"Задача-40. Реверс массива");
Console.WriteLine("---");
Console.WriteLine("'0' - для завершения:");

while (true)
{
    Console.Write("\nУкажите размер массива или '0' - для завершения: ");
    int dim = Convert.ToInt32(Console.ReadLine());

    if (CheckExit(dim)) break;

    Console.Write("\nВведите границы массива: ");
    int maxRnd = Convert.ToInt32(Console.ReadLine());

    int[] arr = GetArrowRandNumber(dim, -maxRnd, maxRnd + 1);
    ShowArr(arr, "Исходный массив: ");
    ShowArr(ReverseArr(arr), "Рагзвернутый массив: ");
}
// *** Конец Задачи 40 ***


/* Задача 41: Напишите программу, которая будет преобразовывать десятичное число в двоичное.
Посмотреть курс Информатика, математика для программиста (выразить двоичное число в виде строки)
Остатки при делении нацело записать наоборот (прибавлять в начало по конкатенации)
*/
string DecimalToBinary(int number, int numberSystem)
{
    string numberBinary = string.Empty;
    while (number > 0)
    {
        numberBinary = (number % numberSystem).ToString() + numberBinary;
        number /= numberSystem;
    }
    return numberBinary;
}

// Основное тело программы.
Console.WriteLine(@"Задача-41. Перевод числа в двоичную систему");
Console.WriteLine("---");
Console.WriteLine("'0' - для завершения:");

Console.Write(@"Введите систему исчисления (10 - десятичная; 2 - двоичная; 16 - шестнацатиричная и т.д.): ");
int numberSystem = Convert.ToInt32(Console.ReadLine());

while (true)
{
    Console.Write("\nВведите число для перевода, или '0' - для завершения: ");
    int number10 = Convert.ToInt32(Console.ReadLine());

    if (CheckExit(number10)) break;

    Console.WriteLine($"Число {number10} в {numberSystem}-й системе счисления = {DecimalToBinary(number10, numberSystem)} ");
}
// *** Конец Задачи 41 ***


/* Задача 42: Не используя рекурсию, выведите первые N чисел Фибоначчи. 
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
Console.Write("\nВведите второе число ряда Фибоначчи (b): ");
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


/* Задача 43: Напишите программу, которая принимает на вход три числа и проверяет, 
может ли существовать треугольник сo сторонами такой длины
Подсказка "Каждая сторона треугольника не может быть больше суммы 2-х других сторон"
*/

bool CheckTriangle(int side1, int side2, int side3)
{
    return side1 < (side2 + side3) & side2 < (side1 + side3) & side3 < (side1 + side2);
}

// Основное тело программы.
Console.WriteLine(@"Задача-43. Проверка существования треугольника");
Console.WriteLine("---");
Console.WriteLine("'0' - для завершения:");

while (true)
{
    Console.Write("\nВведите длину 1-й стороны, '0' - для завершения: ");
    int side_1 = Convert.ToInt32(Console.ReadLine());

    if (CheckExit(side_1)) break;

    Console.Write("Введите длину 2-й стороны: ");
    int side_2 = Convert.ToInt32(Console.ReadLine());
    Console.Write("Введите длину 3-й стороны: ");
    int side_3 = Convert.ToInt32(Console.ReadLine());
    string sidesTriangle = $"Треуголник со сторонами ({side_1}, {side_2}, {side_3})";

    if (CheckTriangle(side_1, side_2, side_3)) Console.WriteLine($"{sidesTriangle} существует");
    else Console.WriteLine($"{sidesTriangle} НЕ существует");
}
// *** Конец Задачи 43 ***