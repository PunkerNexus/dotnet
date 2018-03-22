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
        //������� ���������� ����� � �����������
        //�������� ����� ������(�������� �� ����� ��������� ����� � ���� ������ 8 ��������, ����� �� ����� ��������� ����� � ���� ������ 4 ��������)
        //���������� ��� ������
        //�����
        static string[,] phoneList = new string[10, 10];

        static void Main()
        {
            while (true)
            {
                Console.WriteLine("1.������� �������.\n2.������� ��� ��������.\n3.������� �������.\n4.�����.");
                Console.Write("������ �������: ");

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
                        Console.WriteLine("�� ������ �������. ���������� ��� ���.\n");
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
                    Console.Write("������� ���: ");
                    name = Console.ReadLine();

                    if (name.Length < 4 || Regex.IsMatch(name, withoutnumb))
                    {
                        Console.WriteLine("��� ������ ���� �� ����� 4� �������� � �� ������ ��������� �����.");
                    }
                    else
                    {
                        break;
                    }
                }

                while (true)
                {
                    Console.Write("������� �����: ");
                    number = Console.ReadLine();

                    if (number.Length < 8 || Regex.IsMatch(number, withoutletters))

                    {
                        Console.WriteLine("����� ������ ���� �� ����� 8� �������� � �� ������ ��������� �����.");
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
                            Console.WriteLine("������� ��������.");
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
            Console.WriteLine("���� ���������� �����: ");
            for (int i = 0; i < 10; i++)
                for (int j = 0; j < 10; j++)
                    if (phoneList[i, j] != null)
                        Console.WriteLine("{0}. {1}", a++, phoneList[i, j]);
            Console.WriteLine();
        }

        static void DeleteCont()
        {
            Console.WriteLine("������");

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
                Console.Write("������ ����� ���������� ��������: ");
                int index = Convert.ToInt32(Console.ReadLine()) - 1;
                int index1 = index / 4;
                int index2 = index;

                while (index2 > 4)
                {
                    index2 = index2 - 5;
                }

                phoneList[index1, index2] = null;
                Console.WriteLine("�������!");

                Console.WriteLine();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

    }
}