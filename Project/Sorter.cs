using System;

namespace Project
{
    /// <summary>
    /// Предоставляет методы для сортировки списка студентов.
    /// </summary>
    internal static class Sorter
    {
        /// <summary>
        /// Сортирует список студентов по указанному параметру.
        /// </summary>
        /// <param name="students">Список студентов.</param>
        /// <param name="param">Параметр сортировки ("Studytime" или "Absences").</param>
        public static void SortStudents(List<Student> students, string param)
        {
            int n = students.Count;
            switch (param)
            {
                case "Absences":
                    QuiqSort(students, 0, n - 1, "Absences");
                    break;
                case "Studytime":
                    QuiqSort(students, 0, n - 1, "Studytime");
                    for (int i = 0; i < n / 2; i++)
                    {
                        (students[i], students[n - i - 1]) = (students[n - i - 1], students[i]);
                    }
                    FileUtils.SaveFile(students, "sort-students.csv");
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Выполняет быструю сортировку списка студентов по указанному параметру.
        /// </summary>
        /// <param name="copy">Список студентов.</param>
        /// <param name="leftIndex">Левая граница сортировки.</param>
        /// <param name="rightIndex">Правая граница сортировки.</param>
        /// <param name="param">Параметр сортировки ("Studytime" или "Absences").</param>
        private static void QuiqSort(List<Student> copy, int leftIndex, int rightIndex, string param = "Studytime")
        {
            int i = leftIndex;
            int j = rightIndex;
            Student pivot = copy[leftIndex];
            while (i <= j)
            {
                if (param == "Studytime")
                {
                    while (copy[i].Academic.Studytime < pivot.Academic.Studytime)
                    {
                        i++;
                    }

                    while (copy[j].Academic.Studytime > pivot.Academic.Studytime)
                    {
                        j--;
                    }
                }
                else {
                    while (copy[i].Healths.Absences < pivot.Healths.Absences)
                    {
                        i++;
                    }

                    while (copy[j].Healths.Absences > pivot.Healths.Absences)
                    {
                        j--;
                    }
                }   
                
                if (i <= j)
                {
                    (copy[j], copy[i]) = (copy[i], copy[j]);
                    i++;
                    j--;
                }
            }

            if (leftIndex < j)
            {
                QuiqSort(copy, leftIndex, j, param);
            }

            if (i < rightIndex)
            {
                QuiqSort(copy, i, rightIndex, param);
            }
        }

    }
}
