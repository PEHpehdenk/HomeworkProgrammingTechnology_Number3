using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

public class Laboratory_Tumakov_Number4
{
    public enum DaysOfWeek
    {
        Понедельник = 1,
        Вторник = 2,
        Среда = 3,
        Четверг = 4,
        Пятница = 5,
        Суббота = 6,
        Воскресенье = 7
    }
    public class ErrorHandling
    {
        public bool isNumInt(dynamic checkElement)
        {
            try
            {
                int convertElement = Convert.ToInt32(checkElement);
                return true;
            }
            catch
            {
                Console.WriteLine("Ошибка: данные не являются целочисленным числом");
                return false;
            }
        }
        public bool isNumDouble(dynamic checkElement)
        {
            try
            {
                double convertElement = Convert.ToDouble(checkElement);
                return true;
            }
            catch
            {
                Console.WriteLine("Ошибка: данные не являются дробным числом");
                return false;
            }
        }

        public bool inIntRange(dynamic checkElement, dynamic x, dynamic y)
        {
            try
            {
                double convertElement = Convert.ToInt32(checkElement);
                double startPoint = Convert.ToInt32(x);
                double endPoint = Convert.ToInt32(y);
                if (double.IsNaN(endPoint))
                {
                    endPoint = convertElement + 1;
                }
                if (double.IsNaN(startPoint))
                {
                    endPoint = convertElement - 1;
                }
                if (startPoint <= convertElement && convertElement <= endPoint)
                {
                    return true;
                }
                Console.WriteLine($"Ошибка: значение {checkElement} не входят в диапазон от {x} до {y}");
                return false;
            }
            catch
            {
                Console.WriteLine("Ошибка: данные не являются целочисленными числами");
                return false;
            }
        }
        public bool inDoubleRange(dynamic checkElement, dynamic x, dynamic y)
        {
            try
            {
                double convertElement = Convert.ToDouble(checkElement);
                double startPoint = Convert.ToDouble(x);
                double endPoint = Convert.ToDouble(y);
                if (double.IsNaN(endPoint))
                {
                    endPoint = convertElement + 1;
                }
                if (double.IsNaN(startPoint))
                {
                    endPoint = convertElement - 1;
                }
                if (startPoint <= convertElement && convertElement <= endPoint)
                {
                    return true;
                }
                Console.WriteLine($"Ошибка: значение {checkElement} не входят в диапазон от {x} до {y}");
                return false;
            }
            catch
            {
                Console.WriteLine("Ошибка: данные не являются дробными числами");
                return false;
            }
        }
    }

    public static void task1()
    {
        Console.WriteLine("Задание 1. Проверить, является ли массив отсортированным по возрастанию");
        Random random = new Random();
        List<int> listToCheck = new List<int>();
        Console.WriteLine("Заданный массив:");
        for (int i = 0; i < 10; i++)
        {
            int x = random.Next() % 10;
            listToCheck.Add(x);
            Console.Write(i == 9 ? $"{x}\n" : $"{x} ");
        }
        int ind = 0;
        for (int i = 1; i < 10; i++)
        {
            if (listToCheck[i] <= listToCheck[i - 1])
            {
                ind = i;
                break;
            }
        }
        if (ind == 0)
        {
            Console.WriteLine("Массив отсортирован по возрастанию");
            return;
        }
        Console.WriteLine($"Массив не отсортирован по возрастанию. Элемент меньше предыдущего впервые встречается под индексом {ind}");
    }

    public static void task2()
    {
        ErrorHandling errorHandeler = new ErrorHandling();
        Console.WriteLine("Задание 2. Определить по достоинству карты его номер");
        Console.WriteLine("Введите номинал карты от 6 до 14");
        try
        {
            int inputPoints = Convert.ToInt32(Console.ReadLine());
            {
                switch (inputPoints)
                {
                    case 6:
                        Console.WriteLine("Шестёрка");
                        break;
                    case 7:
                        Console.WriteLine("Семёрка");
                        break;
                    case 8:
                        Console.WriteLine("Восьмёрка");
                        break;
                    case 9:
                        Console.WriteLine("Девятка");
                        break;
                    case 10:
                        Console.WriteLine("Десятка");
                        break;
                    case 11:
                        Console.WriteLine("Валет");
                        break;
                    case 12:
                        Console.WriteLine("Дама");
                        break;
                    case 13:
                        Console.WriteLine("Король");
                        break;
                    case 14:
                        Console.WriteLine("Туз");
                        break;
                    default:
                        Console.WriteLine("Ошибка: Введённый номинал не соответствует диапазону от 6 до 14");
                        break;
                }
            }
        }
        catch (FormatException)
        {
            Console.WriteLine("Ошибка: Введённые данные не являются числом");
        }
        finally
        {
            Console.WriteLine("Программа завершена");
        }
    }

    public static void task3()
    {
        ErrorHandling errorHandeler = new ErrorHandling();
        Console.WriteLine("Задание 3. Вывести строку сопоставимую с входными данными");
        Console.WriteLine("Введите одно из следующих словосочетаний: Jabroni, School counselor, Programmer," +
            "Bike gang member, politician, rapper");
        string inputString = Console.ReadLine().ToLower();
        switch (inputString)
        {
            case "jabroni":
                Console.WriteLine("Patron Tequila");
                break;
            case "school counselor":
                Console.WriteLine("Anything with Alcohol");
                break;
            case "programmer":
                Console.WriteLine("Hipster Craft Beer");
                break;
            case "bike gang member":
                Console.WriteLine("Moonshine");
                break;
            case "politician":
                Console.WriteLine("Your tax dollars");
                break;
            case "rapper":
                Console.WriteLine("Cristal");
                break;
            default:
                Console.WriteLine("Beer");
                break;
        }
    }

    public static void task4()
    {
        ErrorHandling errorHandling = new ErrorHandling();
        Console.WriteLine("Задание 4. Вывести день недели по заданному номеру");
        Console.WriteLine("Введите номер дня от (1 до 7)");
        string dayOfWeek = Console.ReadLine();
        while (!errorHandling.inIntRange(dayOfWeek, 1, 7))
        {
            dayOfWeek = Console.ReadLine();
        }
        Console.WriteLine($"День недели: {(DaysOfWeek)(Convert.ToInt32(dayOfWeek))}");
    }

    public static void task5()
    {
        Console.WriteLine("Задание 5. Составить массив строк и посчитать количество кукол в нём");
        Random random = new Random();
        List<string> words = new List<string>{"Apple", "Car", "Lion", "Plane", "Oil", "Hello Kitty", "Barbie doll"};
        List<string> listToCount = new List<string>();
        Console.WriteLine("Заданный массив:");
        int lenOfList = random.Next() % 10 + 5;
        for (int i = 0; i < lenOfList; i++)
        {
            listToCount.Add(words[random.Next() % 7]);
            Console.Write(i == lenOfList - 1 ? $"{listToCount[i]}\n" : $"{listToCount[i]}, ");
        }
        int countDolls = 0;
        foreach (string item in listToCount)
        {
            if (item.Equals("Hello Kitty") || item.Equals("Barbie doll"))
            {
                countDolls++;
            }
        }
        Console.WriteLine($"В массиве кукол: {countDolls}");
    }
    public static void Main()
    {
        task1();
        task2();
        task3();
        task4();
        task5();
    }
}
