using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace module
{
    class Program
    {
        //Сделать телефонную книгу с интерфейсом
        //добавить новую запись(телефоны не могут содержать буквы и быть меньше 8 символов, имена не могут содержать цифры и быть меньше 4 символов)
        //отобразить все записи
        //выйти
        static string[,] phoneList = new string[10, 10];

        static void Main()
        {
            while (true)
            {
                Console.WriteLine("1.Создать контакт.\n2.Вывести все контакты.\n3.Удалить контакт.\n4.Выход.");
                Console.Write("Ведите команду: ");

                string press = Console.ReadLine();

                switch (press)
                {
                    case "1":
                        NewCont();
                        break;
                    case "2":
                        ViewCont();
                        break;
                    case "3":
                        DeleteCont();
                        break;
                    case "4":
                        return;
                    default:
                        Console.WriteLine("Не верная команда. Попробуйте еще раз.\n");
                        Console.WriteLine();
                        break;
                }
            }
        }
        static void NewCont()
        {
            try
            {
                string name, number;
                string withoutnumb = "[0-9]";
                string withoutletters = "[a-zA-Z]";
                while (true)
                {
                    Console.Write("Введите имя: ");
                    name = Console.ReadLine();

                    if (name.Length < 4 || Regex.IsMatch(name, withoutnumb))
                    {
                        Console.WriteLine("Имя должны быть не менее 4х символов и не должно содержать цифры.");
                    }
                    else
                    {
                        break;
                    }
                }

                while (true)
                {
                    Console.Write("Введите номер: ");
                    number = Console.ReadLine();

                    if (number.Length < 8 || Regex.IsMatch(number, withoutletters))

                    {
                        Console.WriteLine("Номер должен быть не менее 8и символов и не должен содержать буквы.");
                    }
                    else
                    {
                        break;
                    }
                }

                for (int i = 0; i < 10; i++)
                    for (int j = 0; j < 10; j++)
                        if (phoneList[i, j] == null)
                        {
                            phoneList[i, j] = string.Format("{0} {1}", name, number);
                            Console.WriteLine("Контакт добавлен.");
                            Console.WriteLine();
                            return;
                        }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

        }
        static void ViewCont()
        {
            int a = 1;
            Console.WriteLine();
            Console.WriteLine("Ваша телефонная книга: ");
            for (int i = 0; i < 10; i++)
                for (int j = 0; j < 10; j++)
                    if (phoneList[i, j] != null)
                        Console.WriteLine("{0}. {1}", a++, phoneList[i, j]);
            Console.WriteLine();
        }

        static void DeleteCont()
        {
            Console.WriteLine("Список");

            for (int i = 0; i < 10; i++)
                for (int j = 0; j < 10; j++)
                    if (phoneList[i, j] != null)
                    {
                        int a = 1;
                        switch (i)
                        {
                            case 0:
                                a = j + a;
                                break;
                            case 1:
                                a = a + 10 + j;
                                break;
                            case 2:
                                a = a + (10 * 2) + j;
                                break;
                            case 3:
                                a = a + (10 * 3) + j;
                                break;
                        }
                        Console.WriteLine("{0}. {1}", a, phoneList[i, j]);
                    }

            try
            {
                Console.Write("Ведите номер удаляемого контакта: ");
                int index = Convert.ToInt32(Console.ReadLine()) - 1;
                int index1 = index / 4;
                int index2 = index;

                while (index2 > 4)
                {
                    index2 = index2 - 5;
                }

                phoneList[index1, index2] = null;
                Console.WriteLine("Удалено!");

                Console.WriteLine();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

    }
}