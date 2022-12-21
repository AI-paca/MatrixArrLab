using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ЛР05
{
    class MassiveSorting
    {
        public double[] arr;
        static List<MassiveSorting> list_arr;
        public MassiveSorting()
        // Конструктор без параметров
        {
        }
        public MassiveSorting(int aLengthInt)
        // Конструктор с параметрами
        {
            arr = new double[aLengthInt];
        }
        public void ArrInput()
        //метод ввода значений массива с консоли
        {
            MassiveSorting a = new MassiveSorting();
            if (arr!=null)
            {
                Console.WriteLine("Ввведите {0} элемента(ов) массива", arr.Length);
                a.arr = new double[arr.Length];
                for (int i = 0; i < a.arr.GetLength(0); i++)
                    a.arr[i] = int.Parse(Console.ReadLine());
            }
            else
            {
                Console.WriteLine("Ввведите массив");
                a.arr = new double[0];
                int length = 0;
                string input = Console.ReadLine();
                while (input != "")
                {                   
                    double[] temp_arr = new double[length + 1];
                    for (int i = 0; i < temp_arr.GetLength(0) - 1; i++)
                        temp_arr[i] = a.arr[i];
                    a.arr = temp_arr;
                    a.arr[length] = double.Parse(input);
                    length = length + 1;
                    input = Console.ReadLine();
                }
            }
            if (list_arr == null)
                list_arr = new List<MassiveSorting>();
            list_arr.Add(a);
        }
        //три метода сортировки:
        public static double[] ShellSortUp(double[] arr)
        {
            int step = arr.GetLength(0) / 2;
            while (step > 0)
            {
                for (int i = step; i < arr.GetLength(0); i++)
                {
                    int i_right = i;
                    int i_left = i_right - step; ;
                    while (i_left >= 0 && (arr[i_left] > arr[i_right]))
                    {
                        double temp = arr[i_left];
                        arr[i_left] = arr[i_right];
                        arr[i_right] = temp;
                        i_right = i_left;
                        i_left = i_right - step;
                    }
                }
                step = step / 2;
            }
            return arr;
        }
        public static double[] BubbleSortUp(double[] arr)
        // методом пузырька
        {
            int len = arr.GetLength(0);
            while (len > 0)
            {
                for (int i = 1; i < arr.GetLength(0); i++)
                {
                    int i_right = i - 1;
                    int i_left = i;
                    if (arr[i_left] < arr[i_right])
                    {
                        double temp = arr[i_left];
                        arr[i_left] = arr[i_right];
                        arr[i_right] = temp;
                        i_right = i_left;
                        i_left = i_right - 1;
                    }
                }
                len -= 1;
            }
            return arr;
        }
        public static double[] LongSortUp(double[] arr)
        {
            int len = 0;
            while (len < arr.GetLength(0))
            {
                len = 1;
                for (int i = 1; i < arr.GetLength(0); i++)
                {
                    int i_right = len - 1;
                    int i_left = len;
                    if (arr[i_left] < arr[i_right])
                    {
                        double temp = arr[i_left];
                        arr[i_left] = arr[i_right];
                        arr[i_right] = temp;
                    }
                    else
                        len += 1;
                }
            }
            return arr;
        }
        public static double[] LongSortDown(double[] arr)
        {
            MassiveSorting.LongSortUp(arr);
            Array.Reverse(arr);
            return arr;
        }
        public static double[] BubbleSortDown(double[] arr)
        {
            MassiveSorting.BubbleSortUp(arr);
            Array.Reverse(arr);
            return arr;
        }
        public static double[] ShellSortDown(double[] arr)
        {
            MassiveSorting.ShellSortUp(arr);
            Array.Reverse(arr);
            return arr;
        }
        public static void Output(double[] arr)
        //метод вывода массива на консоль
        {
            Console.WriteLine("Массив {0} элементов:", arr.GetLength(0));
            for (int i = 0; i < arr.GetLength(0); i++)
                Console.WriteLine(arr[i]);
            Console.ReadKey();
        }
        public static double[] ChooseMassiveSorting()
        //выбор матрицы;
        {
            if (list_arr == null)
            {
                MassiveSorting a = new MassiveSorting();

                a.ArrInput();
                return list_arr[0].arr;
            }
            else
            {
                string[] menuItems = new string[list_arr.Count + 1];
                menuItems[0] = "Выберите массив";
                for (int i = 1; i <= list_arr.Count; i++)
                {
                    menuItems[i] = "Maссив " + i;
                }
                int index = Menu.Case(menuItems);
                switch (index)
                {
                    default:

                        return list_arr[index - 1].arr;
                }
            }
        }
        public static void Info(double[] arr)
        {
            Console.WriteLine("Длинна массива: {0}", arr.GetLength(0));
            Console.ReadKey();
        }
    }
}
