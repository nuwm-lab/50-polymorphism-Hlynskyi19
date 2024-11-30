using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LabWork
{
    class Celipsoid
    {
        public int a1, a2, a3, b1, b2, b3;
        public double v;

        virtual public void inita()
        {
            System.Console.WriteLine("Введiть пiвосi елiпсоїда a1, a2, a3:");
            a1 = Convert.ToInt32(Console.ReadLine());
            a2 = Convert.ToInt32(Console.ReadLine());
            a3 = Convert.ToInt32(Console.ReadLine());
            if (a1 <= 0 || a2 <= 0 || a3 <= 0)
            {
                throw new ArgumentException("Напівосі еліпсоїда повинні бути додатніми!");
            }
        }
        virtual public void initb()
        {
            System.Console.WriteLine("Введiть координати змiщення центру b1, b2, b3:");
            b1 = Convert.ToInt32(Console.ReadLine());
            b2 = Convert.ToInt32(Console.ReadLine());
            b3 = Convert.ToInt32(Console.ReadLine());
        }
        virtual public void show()
        {
            Console.WriteLine("a1 = " + a1);
            Console.WriteLine("a2 = " + a2);
            Console.WriteLine("a3 = " + a3);
            Console.WriteLine("b1 = " + b1);
            Console.WriteLine("b2 = " + b2);
            Console.WriteLine("b3 = " + b3);
        }
        virtual public double size()
        {
            v = 4.0 / 3.0 * Math.PI * a1 * a2 * a3;
            Console.Write("Об'єм елiпсоїда(V) = ");
            Console.WriteLine(v);
            return (v);
        }
        protected string FormatSign(double value)
        {
            return value > 0 ? $"+ {value}" : $"- {-value}";
        }
    }

    class Cball : Celipsoid
    {
        public int r;
        public override void inita()
        {
            System.Console.Write("Введiть радiус кулi: ");
            r = Convert.ToInt32(Console.ReadLine());
            base.initb();
            if (r <= 0)
            {
                throw new ArgumentException("Радіус кулі повинен бути додатнім!");
            }

        }
        public override void show()
        {
            Console.WriteLine("R = " + r);
            Console.WriteLine("b1 = " + b1);
            Console.WriteLine("b2 = " + b2);
            Console.WriteLine("b3 = " + b3);
        }
        public override double size()
        {
            v = 4.0 / 3.0 * Math.PI * Math.Pow(r, 3);
            Console.Write("Об'єм кулi(V) = ");
            Console.WriteLine(v);
            return (v);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            int userSelect;
            Celipsoid baseobj = new Celipsoid();

            do
            {
                try
                {
                    Console.WriteLine("Виберіть, що створити: 1 - Еліпсоїд, 2 - Куля");
                    userSelect = Convert.ToInt32(Console.ReadLine());
                    if (userSelect == 1)
                    {
                        baseobj = new Celipsoid();
                        baseobj.initb();
                    }
                    else if (userSelect == 2)
                    {
                        baseobj = new Cball();
                    }
                    else
                    {
                        return;
                    }
                    baseobj.inita();
                    baseobj.show();
                    baseobj.size();
                }
                catch (FormatException)
                {
                    Console.WriteLine("Помилка: Введено недійсні числові значення.");
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"Помилка: {ex.Message}");
                }
            } while (true);
        }
    }
}