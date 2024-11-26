using System;

namespace Project
{
    /// <summary>
    /// Предоставляет методы для выполнения задач меню.
    /// </summary>
    internal static class Tasks
    {
        /// <summary>
        /// Возвращает количество студентов, средняя оценка которых выше 11.
        /// </summary>
        /// <param name="students">Список студентов.</param>
        /// <returns>Количество студентов.</returns>
        public static int KolStudentMore11(List<Student> students)
        {
            List<Student> res = [];
            int kol = 0;
            foreach (Student student in students)
            {
                if ((student.Grades.G1 + student.Grades.G2 + student.Grades.G3) / 3 > 11)
                {
                    kol++;
                    res.Add(student);
                }
            }
            FileUtils.SaveFile(res, "Student-Grades.csv");
            FileUtils.PrintArr(res);
            return kol;
        }

        /// <summary>
        /// Возвращает количество студентов, у которых значение freetime превышает studytime и количество пропусков не более семи.
        /// </summary>
        /// <param name="students">Список студентов.</param>
        /// <returns>Количество студентов.</returns>
        public static int TimeAndAbsences(List<Student> students)
        {
            List<Student> res = [];
            int kol = 0;
            foreach (Student student in students)
            {
                if (student.Leisure.Freetime > student.Academic.Studytime && student.Healths.Absences <= 7)
                {
                    kol++;
                    res.Add(student);
                }
            }
            FileUtils.SaveFile(res, "Students-Time.csv");
            FileUtils.PrintArr(res);
            return kol;
        }

        /// <summary>
        /// Группирует студентов по причине поступления.
        /// </summary>
        /// <param name="students">Список студентов.</param>
        /// <returns>Словарь с группами студентов.</returns>
        public static Dictionary<string, List<Student>> GroupByReason(List<Student> students)
        {
            Dictionary<string, List<Student>> res = [];
            foreach (Student student in students)
            {
                _ = res.TryAdd(student.Family.Reason, []);
                res[student.Family.Reason].Add(student);
            }
            return res;
        }

        /// <summary>
        /// Группирует студентов по причине поступления и сортирует их по количеству пропусков.
        /// </summary>
        /// <param name="students">Список студентов.</param>
        /// <returns>Строка с результатами группировки.</returns>
        public static string GroupByAbsences(List<Student> students)
        {
            string result = "";
            List<string> resArr = [];
            Sorter.SortStudents(students, "Absences");

            Dictionary<string, List<Student>> groups = GroupByReason(students);
            foreach (KeyValuePair<string, List<Student>> pair in groups)
            {
                result += $"Группа: {pair.Key}{Environment.NewLine}{Environment.NewLine}";
                result += $"{string.Join(Environment.NewLine, pair.Value)}{Environment.NewLine}{Environment.NewLine}{Environment.NewLine}";
                resArr.Add($"{string.Join(Environment.NewLine, pair.Value)}");
            }

            Console.WriteLine("Введите имя файла для сохранения: ");
            string response = Console.ReadLine()!;
            if (string.IsNullOrEmpty(response))
            {
                throw new InvalidDataException();
            }

            FileUtils.SaveFile(resArr, response + ".csv");
            return $"{result}{Environment.NewLine}Результат записан в {response + ".csv"}{Environment.NewLine}";
        }

        /// <summary>
        /// Возвращает статистику по загруженным данным.
        /// </summary>
        /// <param name="students">Список студентов.</param>
        /// <returns>Строка с статистикой.</returns>
        public static string GetStatistic(List<Student> students)
        {
            Dictionary<string, List<Student>> reasonStatistic = GroupByReason(students);
            double mAge = 0;
            double fAge = 0;
            double mKol = 0;
            double fKol = 0;

            string res = $"Статистика по данным загруженного файла:{Environment.NewLine}";
            res += $"Общее количество данных: {students.Count}{Environment.NewLine}";
            res += "Статистика по reason: ";
            
            foreach (KeyValuePair<string, List<Student>> el in reasonStatistic)
            {
                res += $"{el.Key}={el.Value.Count}; ";
            }
            res += $"{Environment.NewLine}";

            foreach (Student student in students)
            {
                if (student.Person.Sex == "F")
                {
                    fAge += student.Person.Age;
                    fKol++;
                }
                else
                {
                    mAge += student.Person.Age;
                    mKol++;
                }
            }
            res += $"Средний возраст юношей: {(mKol != 0 ? mAge / mKol : 0):f3}{Environment.NewLine}";
            res += $"Средний возраст девушек: {(fKol != 0 ? fAge / fKol : 0):f3}{Environment.NewLine}{Environment.NewLine}";
            return res;
        }

    }
}
