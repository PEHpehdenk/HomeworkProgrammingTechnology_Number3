using System.Text;
using System.Text.RegularExpressions;

public class Laboratory_Tumakov_Number4
{
    public enum Months
    {
        Высокосным,
        Обычным
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

    public static void homework_4(int year)
    {
        Console.WriteLine("Задача 4.1. Преобразовать номер дня в день конкретного месяца");
        Console.WriteLine("Задача 4.2. Условие задачи 1 и проверка корректности данных");
        Console.WriteLine("Домашнее задание 4.1. Условие задачи 4.2. Добавить ввод года. Для упражнений 4.1 и 4.2 номер года определён изначально как 1");
        Months monthType = year == 4 ? Months.Высокосным : Months.Обычным;
        Console.WriteLine($"Введённый год является {monthType}");
        ErrorHandling checker = new ErrorHandling();
        Console.WriteLine("Введите номер дня (от 1 до 365)");
        string userInputDate = Console.ReadLine();
        while (!checker.inIntRange(userInputDate, 1, 365))
        {
            userInputDate = Console.ReadLine();
        }
        int inputDate = Convert.ToInt32(userInputDate);
        DateTime dateToStart = new DateTime(year, 1, 1).AddDays(inputDate - 1);
        Console.WriteLine(dateToStart.ToString("d MMMM"));
    }
    public static void Main()
    {
        Console.WriteLine("Введите номер года. Чтобы запустить упражнения 4.1 и 4.2 введите пустую строку. В случае некорректных данных также будут запущены упражнения 4.1 и 4.2");
        int inputYear = 1;
        try
        {
            inputYear = Convert.ToInt32(Console.ReadLine());
            if (inputYear % 400 == 0 || (inputYear % 100 != 0 && inputYear % 4 == 0))
            {
                inputYear = 4;
            }
        }
        catch { }
        homework_4(inputYear);
    }
}