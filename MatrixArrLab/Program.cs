using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ЛР05
{
class Program
{
    static void Main(string[] args)
    {
        string[] menuItems = new string[] { "Меню", "Задание 1. «Сортировка»", "Задание 2. «Массивы»", "Задание 3. «Ступенчатые массивы»", "Выход" };  
        while (true){                  
        switch (Menu.Case(menuItems)){               
        case 1://Сортировка массив
            string[] menuItemsMassiveSorting = new string[] { "Назад", "Ввод массива", "Сортировка массива", "Инфоормация о массиве" };
            while (true){           
            switch (Menu.Case(menuItemsMassiveSorting)){
                case 0:
                    break;
                case 1: //ввода значений массива с консоли                    
                    MassiveSorting a = new MassiveSorting();
                    a.ArrInput();
                    continue;
                case 2: //три метода сортировки
                    string[] menuItemsMassiveSort = new string[] { "Назад", "Методом пузырька", "Методом Шелла", "Простейшим методом" };
                    string[] chooseItems = new string[] { "Назад", "по возрастанию", "по убыванию" };
                    while (true) {
                        switch (Menu.Case(menuItemsMassiveSort)){
                    case 0:
                        break;
                    case 1:
                        switch (Menu.Case(chooseItems)){
                        case 1:
                        MassiveSorting.Output(MassiveSorting.BubbleSortUp(MassiveSorting.ChooseMassiveSorting()));
                        break;
                        case 2:
                        MassiveSorting.Output(MassiveSorting.BubbleSortDown(MassiveSorting.ChooseMassiveSorting()));
                        break;}
                        break;
                    case 2:
                        switch (Menu.Case(chooseItems)){
                        case 1:
                        MassiveSorting.Output(MassiveSorting.ShellSortUp(MassiveSorting.ChooseMassiveSorting()));
                        break;
                        case 2:
                        MassiveSorting.Output(MassiveSorting.ShellSortDown(MassiveSorting.ChooseMassiveSorting()));
                        break;}
                        break;
                    case 3:
                        switch (Menu.Case(chooseItems)){
                        case 1:
                        MassiveSorting.Output(MassiveSorting.LongSortUp(MassiveSorting.ChooseMassiveSorting()));
                        break;
                        case 2:
                        MassiveSorting.Output(MassiveSorting.LongSortDown(MassiveSorting.ChooseMassiveSorting()));
                        break;}
                        break;}
                        break;}
                    continue;
                case 3: //информации о массиве на консоль.
                    MassiveSorting.Info(MassiveSorting.ChooseMassiveSorting());
                    continue;}
                break;}
            break;
    case 2://Мой массив
            string[] menuItemsMyArr = new string[] { "Назад", "Сгенерировать случайный двумерный массив", "Отсортировать столбцы матрицы по сумме элементов столбца" };
            while (true){
            switch (Menu.Case(menuItemsMyArr)){
                case 0:
                    break;
                case 1:
                    MyArray.GenerateMyRandomArr();
                    continue;
                case 2:
                    MyArray.SortSumMyArrUpOrDown();
                    continue;}
            break;}
            break;
    case 3://Ступенчатый массив                    
            StepArray stepArr = new StepArray();
            string[] menuItemsStepArray = new string[] { "Назад", "Ввод массива массивов", "Сортировка массива массивов", "Инфоормация о массиве массивов" };
            while (true){
            switch (Menu.Case(menuItemsStepArray)){
                case 0:                                
                    break;
                case 1:
                    stepArr.InputStepArrey();
                    continue;
                case 2:
                    stepArr.SortUpOrDown();
                    continue;
                case 3:
                    stepArr.InfotStepArrey();
                    continue;}
            break;}
            break;
    case 4://выход                    
        return;
}
}        
}
}


class Menu
{
    private static void DrawMenu(string[] items, int index /*,int menu_width*/)
    //фронт
    {
        Console.Clear();
        Console.WriteLine("Lab-5");
        Console.ForegroundColor = ConsoleColor.Magenta;
        for (int i = 0; i < items.Length; i++)
        {
            if (i == index)
            {
                Console.BackgroundColor = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Black;
            }
            Console.SetCursorPosition(/*menu_width,*/Console.WindowLeft, Console.WindowHeight / 2 + i - 4);
            Console.WriteLine(items[i]);
            Console.ResetColor();
        }
    }
    public static int Case(string[] menuItems)
    {
        int index = 1;
        while (true)
        {
            DrawMenu(menuItems, index);
            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.DownArrow:
                    if (index < menuItems.Length - 1)
                        index++;
                    break;
                case ConsoleKey.UpArrow:
                    if (index > 0)
                        index--;
                    break;
                case ConsoleKey.Escape:
                    return 0;
                case ConsoleKey.Enter:
                    switch (index)
                    {
                        default:
                            Console.Clear();
                            return index;
                    }
            }
        }
    }
}
}
