using System;
using System.Text;
using System.Text.RegularExpressions;

namespace Mops5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            Task1();
            Task2();
            Task3();

        }
        static void Task1()
        {
            int numberOfPhoneNumbers = 10;
            string[] phoneNumbers = GenerateRandomPhoneNumbers(numberOfPhoneNumbers);

            string phoneNumberPattern = @"^\(\+380\)\d{2}-\d{3}-\d{2}-\d{2}$";
            Regex regex = new Regex(phoneNumberPattern);

            foreach (var phoneNumber in phoneNumbers)
            {
                bool isValid = regex.IsMatch(phoneNumber);
                Console.WriteLine($"{phoneNumber}: {(isValid ? "Valid" : "Invalid")}");
            }
        }
        static void Task2()
        {
            string input = "Я хочу    бути     програмістом";
            string pattern = @"\s+";

            string result = Regex.Replace(input, pattern, " ");

            Console.WriteLine(result);
        }

        static void Task3()
        {
            string htmlText = "<div><p>Символи круглих дужок <code>'('</code> та <code>')'</code>. <br />Ці символи дозволяють отримати з рядка додаткову інформацію. <br/>Зазвичай, якщо парсер регулярних виразів шукає в тексті інформацію за заданим виразом і знаходить її - він просто повертає знайдений рядок.</p><p align=\"right\">А ось тут <a href=\"google.com\">посилання</a>, щоб життя медом не здавалося.</p></div>";

            string pattern = @"<[^>]+>";

            string result = Regex.Replace(htmlText, pattern, string.Empty);

            Console.WriteLine(result);
        }
        static string[] GenerateRandomPhoneNumbers(int count)
        {
            string[] phoneNumbers = new string[count];
            Random random = new Random();

            for (int i = 0; i < count; i++)
            {
                int operatorCode = random.Next(10, 100);
                int firstGroup = random.Next(100, 1000);
                int secondGroup = random.Next(10, 100);
                int thirdGroup = random.Next(10, 100);

                phoneNumbers[i] = $"(+380){operatorCode}-{firstGroup}-{secondGroup}-{thirdGroup}";
            }

            return phoneNumbers;
        }
    }
}
