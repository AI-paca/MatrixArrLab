using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
    
namespace ЛР05
{
    class StepArray
    {
        static List<StepArray> s_arr; 
        public double[][] step_arr;
        public StepArray()
            // Конструктор без параметров
        {
        }
        public StepArray(int n)
            // Конструктор c параметром
        {
            step_arr = new double[n][];
        }
        public void InputStepArrey()
            //ввод значений массива с консоли
        {            
            Console.WriteLine("Укажите желаемое количество массивов содержащихся в данном ступенчатом массиве");
            int arrn = int.Parse(Console.ReadLine());
            while (arrn > 10 || arrn < 0){
                Console.WriteLine("Ошибка, введите число от 0 до 10");
                Console.WriteLine("Укажите желаемое количество массивов содержащихся в данном ступенчатом массиве");
                arrn = int.Parse(Console.ReadLine());}
            StepArray arr = new StepArray(arrn);
            int[] m = new int[arrn];
            Random random_num = new Random();
            for (int i = 0; i < arr.step_arr.GetLength(0); i++){
                Console.WriteLine("Укажите желаемое элементов {0}-го массива:",i);
                m[i] = int.Parse(Console.ReadLine());
                while (m[i] > 10 || (m[i] < 0)){
                    Console.WriteLine("Ошибка, введите число от 0 до 10");
                    Console.WriteLine("Укажите желаемое элементов {0}-го массива:", i);
                    m[i] = int.Parse(Console.ReadLine());}
                arr.step_arr[i] =new double[(m[i])];
                Console.WriteLine("Введите {0}-й массив из {1} элементов:\n",i,m[i]);
                for (int j = 0; j < arr.step_arr[i].Length; j++){
                    Console.SetCursorPosition(Console.CursorLeft+4*j, Console.CursorTop-1);
                    arr.step_arr[i][j] = double.Parse(Console.ReadLine());}}
            if (s_arr == null)
                s_arr = new List<StepArray>();
            s_arr.Add(arr);
        }
        public void SortUpOrDown()
            /*метод, формирующий из элементов массива одномерный массив, 
             * отсортировать его по убыванию или возрастанию и заполнить 
             * заново ступенчатый массив, сохранив его структуру*/
        {
            if (s_arr == null)
                InputStepArrey();
            StepArray arr = ChooseStepArrey();
            int lenght=0;
            for (int i = 0; i < arr.step_arr.GetLength(0); i++)
                lenght=lenght+arr.step_arr[i].Length;
            double[] temp_arr =new double[lenght];
            lenght=0;
            for (int i = 0; i < arr.step_arr.GetLength(0); i++){
                for (int j = 0; j < arr.step_arr[i].Length; j++)
                    temp_arr[lenght + j] = arr.step_arr[i][j];
                lenght += arr.step_arr[i].Length;}
            string[] menuItems = new string[] {"Выберите тип сортировки", "по возрастанию", "по убыванию"};
            switch ( Menu.Case(menuItems)){
                    case 1:
                        temp_arr=MassiveSorting.ShellSortUp(temp_arr);
                        break;
                    case 2:
                        temp_arr=MassiveSorting.ShellSortDown(temp_arr); 
                        break;}
            lenght = 0;         
            for (int i = 0; i < arr.step_arr.GetLength(0); i++){
                for (int j = 0; j <arr.step_arr[i].Length; j++)                
                    arr.step_arr[i][j]=temp_arr[lenght+j];                
                lenght += arr.step_arr[i].Length;}
            OutputStepArrey(arr);
        }
        public void OutputStepArrey(StepArray arr)
            //метод вывода значений массива с консоли;
        {            
            for (int i = 0; i < arr.step_arr.GetLength(0); i++){
                Console.WriteLine("Массив{0,3} из{1,3} элементов:", i, arr.step_arr[i].Length);
                for (int j = 0; j < arr.step_arr[i].Length; j++){
                    Console.SetCursorPosition(Console.CursorLeft + 5 * j+26, Console.CursorTop - 1);
                    Console.WriteLine("{0,4}", arr.step_arr[i][j]);}}
            Console.ReadKey();
        }
        public static StepArray ChooseStepArrey()
            //выбор матрицы;
        {
            string[] menuItems = new string[s_arr.Count+1];
            menuItems[0] = "Выберите массив массивов";
            for (int i = 1; i <= s_arr.Count; i++)            
                menuItems[i] = "Maссив массивов " + i;            
            int index = Menu.Case(menuItems);
            switch (index)
            {
                default:
                    return s_arr[index-1];
            }
        }        
        public void InfotStepArrey()
        {
            StepArray arr = new StepArray();
            if (s_arr == null){
                InputStepArrey();
                arr = s_arr[0];
                Console.WriteLine();}
            else            
                arr = ChooseStepArrey();           
            Console.WriteLine("В массиве {0} массива:", arr.step_arr.Length);
            for (int i = 0; i < arr.step_arr.Length; i++)            
                Console.WriteLine("Массив {0} из {1} элементов;", i, arr.step_arr[i].Length);
            Console.ReadKey();
        }
    }
}
