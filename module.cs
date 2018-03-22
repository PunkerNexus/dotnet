using System;
using System.Collections.Generic;


using System.Linq;
// he he he he
// he he he he
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace module
{
    class Program
    {
        //Ñäåëàòü òåëåôîííóþ êíèãó ñ èíòåðôåéñîì
        //äîáàâèòü íîâóþ çàïèñü(òåëåôîíû íå ìîãóò ñîäåðæàòü áóêâû è áûòü ìåíüøå 8 ñèìâîëîâ, èìåíà íå ìîãóò ñîäåðæàòü öèôðû è áûòü ìåíüøå 4 ñèìâîëîâ)
        //îòîáðàçèòü âñå çàïèñè
        //âûéòè
        static string[,] phoneList = new string[10, 10];

        static void Main()
        {
            while (true)
            {
                Console.WriteLine("1.Ñîçäàòü êîíòàêò.\n2.Âûâåñòè âñå êîíòàêòû.\n3.Óäàëèòü êîíòàêò.\n4.Âûõîä.");
                Console.Write("Âåäèòå êîìàíäó: ");

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
                        Console.WriteLine("Íå âåðíàÿ êîìàíäà. Ïîïðîáóéòå åùå ðàç.\n");
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
                    Console.Write("Ââåäèòå èìÿ: ");
                    name = Console.ReadLine();

                    if (name.Length < 4 || Regex.IsMatch(name, withoutnumb))
                    {
                        Console.WriteLine("Èìÿ äîëæíû áûòü íå ìåíåå 4õ ñèìâîëîâ è íå äîëæíî ñîäåðæàòü öèôðû.");
                    }
                    else
                    {
                        break;
                    }
                }

                while (true)
                {
                    Console.Write("Ââåäèòå íîìåð: ");
                    number = Console.ReadLine();

                    if (number.Length < 8 || Regex.IsMatch(number, withoutletters))

                    {
                        Console.WriteLine("Íîìåð äîëæåí áûòü íå ìåíåå 8è ñèìâîëîâ è íå äîëæåí ñîäåðæàòü áóêâû.");
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
                            Console.WriteLine("Êîíòàêò äîáàâëåí.");
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
            Console.WriteLine("Âàøà òåëåôîííàÿ êíèãà: ");
            for (int i = 0; i < 10; i++)
                for (int j = 0; j < 10; j++)
                    if (phoneList[i, j] != null)
                        Console.WriteLine("{0}. {1}", a++, phoneList[i, j]);
            Console.WriteLine();
        }

        static void DeleteCont()
        {
            Console.WriteLine("Ñïèñîê");

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
                Console.Write("Âåäèòå íîìåð óäàëÿåìîãî êîíòàêòà: ");
                int index = Convert.ToInt32(Console.ReadLine()) - 1;
                int index1 = index / 4;
                int index2 = index;

                while (index2 > 4)
                {
                    index2 = index2 - 5;
                }

                phoneList[index1, index2] = null;
                Console.WriteLine("Óäàëåíî!");

                Console.WriteLine();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

    }
}
