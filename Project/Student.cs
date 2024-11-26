using System;

namespace Project
{
    /// <summary>
    /// Представляет данные о студенте.
    /// </summary>
    internal class Student(
        Person person,
        Family family,
        Academic academic,
        Leisure leisure,
        Healths helth,
        Grades grades
    )
    {
        /// <summary>
        /// Личные данные студента.
        /// </summary>
        public Person Person { get; } = person;

        /// <summary>
        /// Семейные данные студента.
        /// </summary>
        public Family Family { get; } = family;

        /// <summary>
        /// Академические данные студента.
        /// </summary>
        public Academic Academic { get; } = academic;

        /// <summary>
        /// Данные о досуге студента.
        /// </summary>
        public Leisure Leisure { get; } = leisure;

        /// <summary>
        /// Данные о здоровье студента.
        /// </summary>
        public Healths Healths { get; } = helth;

        /// <summary>
        /// Оценки студента.
        /// </summary>
        public Grades Grades { get; } = grades;

        /// <summary>
        /// Создает клон текущего объекта Student.
        /// </summary>
        /// <returns>Клон объекта Student.</returns>
        public Student Clone()
        {
            return new Student(Person.Clone(), Family.Clone(), Academic.Clone(), Leisure.Clone(), Healths.Clone(), Grades.Clone());
        }
        /// <summary>
        /// Возвращает строковое представление объекта Student.
        /// </summary>
        /// <returns>Строковое представление объекта Student.</returns>
        public override string ToString()
        {
            string str = string.Join("", Person, Family, Academic, Leisure, Healths, Grades);
            return str;
        }
    }
}
