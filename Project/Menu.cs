using System;

namespace Project
{
    /// <summary>
    /// Предоставляет методы для работы с меню и вводом данных.
    /// </summary>
    public static class Menu
    {
        /// <summary>
        /// Флаг, указывающий, были ли загружены данные.
        /// </summary>
        private static bool _loaded = false;

        /// <summary>
        ///  Список студентов.
        /// </summary>
        private static readonly List<Student> Students = [];

        /// <summary>
        /// Отображает меню в консоли.
        /// </summary>
        public static void ShowMenu()
        {
            Console.WriteLine("Выберите действие:");
            if (_loaded == false)
            {
                Console.WriteLine("1: Ввод адреса файла.");
            }
            else
            {
                Console.WriteLine("1: Сменить набор данных."); 
            } 
            Console.WriteLine("2: Выборка по оценкам.");
            Console.WriteLine("3: Выборка по freetime и studytime.");
            Console.WriteLine("4: Вывод сводной статистики.");
            Console.WriteLine("5: Завершить работу программы.");
            Console.WriteLine("6: Упорядочить данные по по убыванию studytime.");
            Console.WriteLine("7: Выборка по столбцу reasone, отсортированная по absences.");
        }

        /// <summary>
        /// Анализирует ввод пользователя и выполняет соответствующее действие.
        /// </summary>
        /// <param name="input">Ввод пользователя.</param>
        /// <param name="exit">Флаг для завершения работы программы.</param>
        public static void AnaliseInput(string input, ref bool exit)
        {
            if (input != "1" && input != "5" && _loaded == false)
            {
                Console.WriteLine("Список студентов пуст. Загрузите данные из файла.");
                return;
            }
            try
            {
                switch (input)
                {
                    case "1":
                        Console.WriteLine("Введите имя файла: ");
                        string? file = Console.ReadLine();
                        Students.Clear();
                        string mistakes = FileUtils.LoadFile(Students, file);
                        Console.WriteLine($"{Environment.NewLine}Данные загружены. Количество студентов: {FileUtils.ListSize(Students)}.");
                        Console.WriteLine(mistakes);
                        _loaded = true;
                        break;

                    case "2":
                        Console.WriteLine($"{Environment.NewLine}Cредняя оценка за три периода выше одиннадцати у {Tasks.KolStudentMore11(Students)} студентов.");
                        break;

                    case "3":
                        Console.WriteLine($"У {Tasks.TimeAndAbsences(Students)} студентов  значение freetime превышает studytime и при этом количество пропусков не более семи.");
                        break;

                    case "4":
                        Console.WriteLine("Общая статистика по загруженному файлу: ");
                        Console.WriteLine(Tasks.GetStatistic(Students));
                        break;

                    case "5":
                        exit = true;
                        Environment.Exit(0);
                        break;

                    case "6":
                        Console.WriteLine("Упорядоченные данные по по убыванию studytime: ");
                        Sorter.SortStudents(Students, "Studytime");
                        FileUtils.PrintArr(Students);
                        break;

                    case "7":
                        Console.WriteLine("Выборка по reasone и absences: ");
                        Console.WriteLine(Tasks.GroupByAbsences(Students));
                        break;

                    default:
                        Console.WriteLine("Некорреткный ввод!\n");
                        break;
                }
            }
            catch (InvalidDataException)
            {
                throw new Exception("");
            }
            catch (Exception e)
            {
                throw new Exception("Ошибка при анализе ввода данных в консоль." + e.Message);
            }
        }
    }
    }

