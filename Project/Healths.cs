using System;

namespace Project
{
    /// <summary>
    /// Представляет данные о здоровье студента.
    /// </summary>
    public class Healths(
        int dalc,
        int walk,
        int health,
        int absence
    )
    {
        /// <summary>
        /// Употребление алкоголя в рабочие дни.
        /// </summary>
        public int Dalc { get; } = dalc;

        /// <summary>
        /// Употребление алкоголя в выходные дни.
        /// </summary>
        public int Walc { get; } = walk;

        /// <summary>
        /// Общее состояние здоровья.
        /// </summary>
        public int Health { get; } = health;

        /// <summary>
        /// Количество пропусков занятий.
        /// </summary>
        public int Absences { get; } = absence;

        /// <summary>
        /// Создает клон текущего объекта Healths.
        /// </summary>
        /// <returns>Клон объекта Healths.</returns>
        public Healths Clone()
        {
            return new Healths(Dalc, Walc, Health, Absences);
        }

        /// <summary>
        /// Возвращает строковое представление объекта Healths.
        /// </summary>
        /// <returns>Строковое представление объекта Healths.</returns>
        public override string ToString()
        {
            return $"{Dalc},{Walc},{Health},{Absences},";
        }
    }
}
