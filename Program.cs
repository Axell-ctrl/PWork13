using System;
using System.Numerics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.CodeDom.Compiler;

namespace Практическая_работа__13
{
    internal class Program
    {
        static void HandleError(FormatException fex)//функция с сообщением об исключении FormatException (входная строка имела неправильный формат)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Что-то пошло не так! Ошибка: {fex.Message} Попробуйте ещё раз.");//Вывод текста с помощью интерполяции: Что-то пошло не так! Ошибка: Входная строка имела неправильный формат. 
            Console.ForegroundColor = ConsoleColor.White;
        }
        static void HandleError(OverflowException ofex)//функция с сообщением об исключении OverflowException (Значение было недопустимо малым или недопустимо большим для Int32)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Что-то пошло не так! Ошибка: {ofex.Message} Попробуйте ещё раз.");//Вывод текста с помощью интерполяции: Что-то пошло не так! Ошибка: Значение было недопустимо малым или недопустимо большим для Int32.
            Console.ForegroundColor = ConsoleColor.White;
        }
        static void HandleError(Exception ex)//функция с сообщением об исключении Exception (все ошибки в целом)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Что-то пошло не так! Ошибка: {ex.Message} Попробуйте ещё раз.");//Вывод текста с помощью интерполяции: Что-то пошло не так! Ошибка: Входная строка имела неправильный формат. 
            Console.ForegroundColor = ConsoleColor.White;
        }
        static string translationOnTwo(BigInteger value) 
        {
            if (value == 0)
            {
                return "0";
            }
            if (value < 0)
            {
                BigInteger plusValue = value * (-1);
                return "-" + translationOnTwo(plusValue);
            }
            else
            {
                return translationOnTwo(value / 2) + (value % 2).ToString();
            }
        }
        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();
            Console.Title = "Практическая работа №13";
            Console.WriteLine("Здравствуйте!");
            bool exitProgram = false;//флаг для выхода из программы
            while (true)
            {
                try
                {
                    BigInteger numberTen;
                    Console.Write("Введите число десятичной системы исчисления: ");
                    numberTen = BigInteger.Parse(Console.ReadLine());
                    string numberTwo = translationOnTwo(numberTen);
                    Console.WriteLine($"Введённое число десятичной системы: {numberTen}");
                    Console.WriteLine($"Результат перевода числа в двоичную систему: {numberTwo}");
                }
                catch (FormatException fex)//обработка исключения Exception (все ошибки в целом)
                {
                    HandleError(fex);
                    continue;
                }
                catch (Exception ex)//обработка исключения Exception (все ошибки в целом)
                {
                    HandleError(ex);
                    continue;
                }
                while (true)//повторное выполнение цикла с вопросом: Хотите продолжить выполнение? (1-Да/0-Нет).
                {
                    try
                    {
                        Console.Write("Хотите продолжить выполнение? (1-Да/0-Нет): ");
                        int answer = Int32.Parse(Console.ReadLine());
                        if (answer < 0 || answer > 1)//если ответ пользователя меньше 0 или больше 1
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Вы ввели некорректное число. Попробуйте ещё раз.");//некорректное число, просит пользователя попробовать ещё раз ввести значение
                            Console.ForegroundColor = ConsoleColor.White;
                            continue;//продолжает итерацию внутреннего цикла
                        }
                        else//иначе
                        {
                            if (answer == 0)//если ответ пользователя равен 0
                            {
                                exitProgram = true;//флаг выхода из программы становится истинным
                                Console.WriteLine("Завершение программы. Нажмите для продолжения...");//выводится сообщение: Завершение программы.
                            }
                            break;
                        }
                    }
                    catch (FormatException fex)//обработка исключения FormatException
                    {
                        HandleError(fex);//функция которая вызывает сообщение ошибки FormatException
                    }
                    catch (OverflowException ofex)//обработка исключения OverflowException
                    {
                        HandleError(ofex);//функция которая вызывает сообщение ошибки OverflowException
                    }
                    catch (Exception ex)
                    {
                        HandleError(ex);//функция которая вызывает сообщение ошибки Exception
                    }
                }
                if (exitProgram == true)//если выход из программы является истинным
                    break;//завершается внешний цикл
            }
            Console.ReadKey();
        }
    }
}
