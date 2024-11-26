using System.Text;

namespace Project
{
    /// <summary>
    /// Предоставляет методы для работы с файлами и данными студентов.
    /// </summary>
    internal static class FileUtils
    {
        /// <summary>
        /// Первая строка в CSV файле.
        /// </summary>
        private const string FirstLine= "school,sex,age,address,famsize,Pstatus,Medu,Fedu,Mjob,Fjob,reason,guardian,traveltime,studytime,failures,schoolsup,famsup,paid,activities,nursery,higher,internet,romantic,famrel,freetime,goout,Dalc,Walc,health,absences,G1,G2,G3";
        
        /// <summary>
        /// Читает данные из файла и возвращает массив строк, исключая первую строку.
        /// </summary>
        /// <param name="file">Имя файла (по умолчанию "student_data.csv").</param>
        /// <returns>Массив строк с данными студентов.</returns>
        private static string[] ReadFile(string file = "student_data.csv")
        {
            return File.ReadAllLines(GetFilePath(string.IsNullOrEmpty(file) ? "student_data.csv" : file))[1..];
        }

        /// <summary>
        /// Возвращает полный путь к файлу.
        /// </summary>
        /// <param name="file">Имя файла.</param>
        /// <returns>Полный путь к файлу.</returns>
        private static string GetFilePath(string file)
        {   
            return Path.Combine(Directory.GetParent(Environment.CurrentDirectory)!.Parent!.Parent!.Parent!.FullName, file);
        }

        /// <summary>
        /// Загружает данные из файла и парсит их в список студентов.
        /// </summary>
        /// <param name="students">Список студентов для заполнения.</param>
        /// <param name="fileName">Имя файла.</param>
        /// <returns>Строка с ошибками парсинга.</returns>
        public static string LoadFile(List<Student> students, string fileName)
        {
            string mistakes = Parse(ReadFile(fileName), students);
            return mistakes;
        }

        /// <summary>
        /// Преобразует список студентов в список строк с первой строкой CSV.
        /// </summary>
        /// <param name="students">Список студентов.</param>
        /// <returns>Список строк для записи в файл.</returns>
        private static List<string> ContToListStringWithFirstName(List<Student> students)
        {
            List<string> res = [FirstLine];
            foreach (Student t in students)
            {
                res.Add(t.ToString());
            }
            return res;
        }

        /// <summary>
        /// Преобразует список строк в список строк с первой строкой CSV.
        /// </summary>
        /// <param name="students">Список строк.</param>
        /// <returns>Список строк для записи в файл.</returns>
        private static List<string> ContToListStringWithFirstName(List<string> students)
        {
            List<string> res = [FirstLine];
            foreach (string t in students)
            {
                res.Add(t);
            }
            return res;

        }

        /// <summary>
        /// Сохраняет список студентов в файл.
        /// </summary>
        /// <param name="students">Список студентов.</param>
        /// <param name="fileName">Имя файла (по умолчанию "output.csv").</param>
        public static void SaveFile(List<Student> students, string fileName = "output.csv")
        {
            foreach(char el in "/\\:*?><|")
            {
                if (fileName.Contains(el))
                {
                    throw new Exception("Введено некорректное имя файла для сохранения.");
                }
            }
            List<string> res = ContToListStringWithFirstName(students);
            File.WriteAllLines($"../../../../{fileName}", res, Encoding.UTF8);
            Console.WriteLine($"Ваши значения корректно сохранены в файл {fileName}");
        }

        /// <summary>
        /// Сохраняет список строк в файл.
        /// </summary>
        /// <param name="students">Список строк.</param>
        /// <param name="fileName">Имя файла (по умолчанию "output.csv").</param>
        public static void SaveFile(List<string> students, string fileName = "output.csv")
        {
            foreach (char el in "/\\:*?><|")
            {
                if (fileName.Contains(el))
                {
                    throw new Exception("Введено некорректное имя файла для сохранения.");
                }
            }
            List<string> res = ContToListStringWithFirstName(students);
            File.WriteAllLines($"../../../../{fileName}", res, Encoding.UTF8);
            Console.WriteLine($"Ваши значения корректно сохранены в файл {fileName}");
        }

        /// <summary>
        /// Создает глубокую копию списка студентов.
        /// </summary>
        /// <param name="students">Исходный список студентов.</param>
        /// <returns>Копия списка студентов.</returns>
        public static List<Student> Copy(List<Student> students)
        {
            List<Student> copy = [];
            foreach (Student student in students)
            {
                copy.Add(student.Clone());
            }
            return copy;
        }

        /// <summary>
        /// Выводит список студентов в консоль.
        /// </summary>
        /// <param name="students">Список студентов.</param>
        public static void PrintArr(List<Student> students)
        {
            foreach (Student t in students)
            {
                Console.WriteLine(t.ToString());
            }
        }

        /// <summary>
        /// Возвращает количество студентов в списке.
        /// </summary>
        /// <param name="students">Список студентов.</param>
        /// <returns>Количество студентов.</returns>
        public static int ListSize(List<Student> students)
        {
            int size = 0;
            foreach (Student _ in students)
            {
                size++;
            }
            return size;
        }

        /// <summary>
        /// Парсит данные из массива строк в список студентов.
        /// </summary>
        /// <param name="file">Массив строк с данными.</param>
        /// <param name="students">Список студентов для заполнения.</param>
        /// <returns>Строка с ошибками парсинга.</returns>
        private static string Parse (string[] file, List<Student> students)
        {
            string mistakes = $"{Environment.NewLine}";
            for (int i = 0; i < file.Length; i++)
            {
                try { 
                    string[] arr = file[i].Replace("\"", "").Split(",");
                    students.Add(
                        new Student(
                            new Person(
                                arr[0],
                                arr[1],
                                int.Parse(arr[2]),
                                arr[3]
                            ),
                            new Family(
                                arr[4],
                                arr[5],
                                int.Parse(arr[6]),
                                int.Parse(arr[7]),
                                arr[8],
                                arr[9],
                                arr[10],
                                arr[11]
                            ),
                            new Academic(
                                int.Parse(arr[12]),
                                int.Parse(arr[13]),
                                int.Parse(arr[14]),
                                arr[15],
                                arr[16],
                                arr[17],
                                arr[18],
                                arr[19],
                                arr[20]
                            ),
                            new Leisure(
                                arr[21],
                                arr[22],
                                arr[23],
                                int.Parse(arr[24]),
                                int.Parse(arr[25])
                            ),
                            new Healths(
                                int.Parse(arr[26]),
                                int.Parse(arr[27]),
                                int.Parse(arr[28]),
                                int.Parse(arr[29])
                            ),
                            new Grades(
                                int.Parse(arr[30]),
                                int.Parse(arr[31]),
                                int.Parse(arr[32])
                            )
                        )
                    );
                }
                catch {
                    mistakes += $" - Некорректные ввод в строке {i + 1} из файла; Мы пропустили эту строку. {Environment.NewLine}";
                }
            }
            return mistakes;
        }
    }
}
