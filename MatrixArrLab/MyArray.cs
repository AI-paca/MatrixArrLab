using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ЛР05
{
    class MyArray
    {
        static List<MyArray> s_arr; 
        public double[,] my_arr; //двумерный массив размерностью m x n
        public MyArray(int mInt, int nInt)
            // Конструктор с параметрами
        {
            my_arr = new double[mInt, nInt];
        }
        public MyArray()
            // Конструктор с параметрами
        {
        }
        public static MyArray GenerateMyRandomArr()
            //заполнение случайными числами в диапазоне от -100 до 100
        {
            if (s_arr == null)
                s_arr = new List<MyArray>();
            MyArray arr = new MyArray();
            Console.WriteLine("Укажите размерность массива:");
            Console.Write("[  x  ]"); Console.SetCursorPosition(1, Console.CursorTop);
            int m = int.Parse(Console.ReadLine()); Console.SetCursorPosition(4, Console.CursorTop - 1);
            int n = int.Parse(Console.ReadLine());
            arr.my_arr = new double[m, n];
            Random random_num = new Random();
            for (int i = 0; i < arr.my_arr.GetLength(0); i++)
                for (int j = 0; j < arr.my_arr.GetLength(1); j++)
                    arr.my_arr[i, j] = random_num.Next(-100, 101);
            s_arr.Add(arr);
            Outputmy_arrey(arr);
            return arr;
        }
        public static MyArray SortSumMyArrUpOrDown()
            //отсортировать столбцы матрицы по сумме элементов столбца по убыванию и возрастанию.
        {
            bool flagUp = true;
            string[] menuItems = new string[] { "Выберите тип сортировки", "по возрастанию", "по убыванию" };
            switch (Menu.Case(menuItems)){
                case 1:
                    flagUp = true; break;
                case 2:
                    flagUp = false; break;}
            MyArray arr = new MyArray(); arr = ChooseMyArrey();
            double[] summ = new double[arr.my_arr.GetLength(1)]; int[] temp_arr = new int[arr.my_arr.GetLength(1)];
            double[,] org_arr = new double[arr.my_arr.GetLength(0), arr.my_arr.GetLength(1)];            
            for (int j = 0; j < arr.my_arr.GetLength(1); j++){
                summ[j] = 0;//массив суммы столбцов для сортировки  
                temp_arr[j] = j;//индекс столбцов для возврата к исходному массиву
                for (int i = 0; i < arr.my_arr.GetLength(0); i++)                    
                    summ[j] = summ[j] + arr.my_arr[i, j];}
            int step = summ.GetLength(0) / 2;
            while (step > 0)/*сортировка*/{ 
                for (int i = step; i < summ.GetLength(0); i++){
                    int i_right = i; int i_left = i_right - step;
                    while (i_left >= 0 && (summ[i_left] > summ[i_right])){
                        double temp = summ[i_left]; int tempTemp = temp_arr[i_left];
                        summ[i_left] = summ[i_right]; temp_arr[i_left] = temp_arr[i_right];
                        summ[i_right] = temp; temp_arr[i_right] = tempTemp;                                                                      
                        i_right = i_left;
                        i_left = i_right - step;}
                } step = step / 2;}
            if (flagUp){
                for (int j = 0; j < arr.my_arr.GetLength(1); j++)
                    for (int i = 0; i < arr.my_arr.GetLength(0); i++)
                        org_arr[i, j] = arr.my_arr[i,temp_arr[j]];}
            else{
                for (int j = 0; j < arr.my_arr.GetLength(1); j++)
                    for (int i = 0; i < arr.my_arr.GetLength(0); i++)
                        org_arr[i, j] = arr.my_arr[i,arr.my_arr.GetLength(1) - temp_arr[j] - 1];}
            arr.my_arr=org_arr;
            Outputmy_arrey(arr);
            return arr;
        }
        public static void Outputmy_arrey(MyArray arr)
            //метод вывода значений массива с консоли;
        { 
            Console.WriteLine("Двумерный массив [{0,2}x{1,2}]\n", arr.my_arr.GetLength(0), arr.my_arr.GetLength(1));
            for (int i = 0; i < arr.my_arr.GetLength(0); i++){
                for (int j = 0; j < arr.my_arr.GetLength(1); j++){
                    Console.SetCursorPosition(Console.CursorLeft + 5 * j, Console.CursorTop - 1);
                    Console.WriteLine("{0,4}", arr.my_arr[i, j]);}
                Console.WriteLine();}
            Console.ReadKey(); 
        }
        public static MyArray ChooseMyArrey()
            //выбор матрицы;
        {
            MyArray arr = new MyArray();
            if (s_arr == null){
                s_arr = new List<MyArray>();
                return GenerateMyRandomArr();}
            else{
                string[] menuItems = new string[s_arr.Count + 1];
                menuItems[0] = "Выберите двумерный массив";
                for (int i = 1; i <= s_arr.Count; i++)
                {
                    menuItems[i] = "Maссив " + i;
                }
                int index = Menu.Case(menuItems);
                switch (index)
                {
                    default:
                        return s_arr[index - 1];
                }
            }
        }
    }
}
