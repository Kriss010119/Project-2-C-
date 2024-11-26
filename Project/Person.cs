using System;

namespace Project
{
    /// <summary>
    /// Представляет личные данные студента.
    /// </summary>
    public class Person (
         string school,
         string sex,
         int age,
         string address
    )
    {
        /// <summary>
        /// Школа, в которой учится студент.
        /// </summary>
        public string School { get; } = school;

        /// <summary>
        /// Пол студента.
        /// </summary>
        public string Sex { get; } = sex;

        /// <summary>
        /// Возраст студента.
        /// </summary>
        public int Age { get; } = age;

        /// <summary>
        /// Адрес проживания студента.
        /// </summary>
        public string Address { get; } = address;

        /// <summary>
        /// Создает клон текущего объекта Person.
        /// </summary>
        /// <returns>Клон объекта Person.</returns>
        public Person Clone()
        {
            return new Person(School, Sex, Age, Address);
        }

        /// <summary>
        /// Возвращает строковое представление объекта Person.
        /// </summary>
        /// <returns>Строковое представление объекта Person.</returns>
        public override string ToString()
        {
            return $"{School},{Sex},{Age},{Address},";
        }
    }
}
