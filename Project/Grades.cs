using System;

namespace Project
{
    /// <summary>
    /// Представляет оценки студента за три периода.
    /// </summary>
    public class Grades(
        int g1,
        int g2,
        int g3
    )
    {
        /// <summary>
        /// Оценка за первый период.
        /// </summary>
        public int G1 { get; } = g1;
        /// <summary>
        /// Оценка за второй период.
        /// </summary>
        public int G2 { get; } = g2;
        /// <summary>
        /// Оценка за третий период.
        /// </summary>
        public int G3 { get; } = g3;

        /// <summary>
        /// Создает клон текущего объекта Grades.
        /// </summary>
        /// <returns>Клон объекта Grades.</returns>
        public Grades Clone()
        {
            return new Grades(G1, G2, G3);
        }

        /// <summary>
        /// Возвращает строковое представление объекта Grades.
        /// </summary>
        /// <returns>Строковое представление объекта Grades.</returns>
        public override string ToString()
        {
            return $"{G1},{G2},{G3}";
        }
    }
}
