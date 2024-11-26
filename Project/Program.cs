/*
 * Осина Дарья Евгеньевна
 * БПИ-245
 * Проект модуль 2
 * Тема 4
 */

using System;
using System.Security;

namespace Project
{
    /// <summary>
    /// Главный класс программы.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Точка входа в программу.
        /// </summary>
        private static void Main()
        {
            bool exit = false;
            do
            {
                try
                {
                    Console.Clear();
                    Menu.ShowMenu();
                    string input = Console.ReadLine()!;
                    Menu.AnaliseInput(input, ref exit);
                    Console.WriteLine("Нажмите клавишу для продолжения.");   
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.ParamName + '\n');
                }
                catch (IOException ex)
                {
                    Console.WriteLine(ex.Message + '\n');
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message + '\n');
                }
                catch (SecurityException ex)
                {
                    Console.WriteLine(ex.Message + '\n');
                }
                catch (OutOfMemoryException ex)
                {
                    Console.WriteLine(ex.Message + '\n');
                }
                catch (IndexOutOfRangeException ex)
                {
                    Console.WriteLine(ex.Message + '\n');
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка: {ex.Message}");
                }

                _ = Console.ReadLine();
            } while (!exit);
        }
    }
}