using System;
using System.Net.NetworkInformation;

namespace Project
{
    /// <summary>
    ///     Представляет академическую информацию о студенте.
    /// </summary>
    public class Academic(
        int traveltime,
        int studytime,
        int failures,
        string schoolsup,
        string famsup,
        string paid,
        string activities,
        string nursery,
        string higher
    )
    {
        /// <summary>
        ///     Время, затрачиваемое на поездки до школы.
        /// </summary>
        public int Traveltime { get; } = traveltime;
        /// <summary>
        ///     Время, затрачиваемое на учебу.
        /// </summary>
        public int Studytime { get; } = studytime;
        /// <summary>
        /// Количество неудачных попыток (failures).
        /// </summary>
        public int Faikures { get; } = failures;
        /// <summary>
        /// Дополнительная поддержка от школы (yes/no).
        /// </summary>
        public string Schoolsup { get; } = schoolsup;
        /// <summary>
        /// Дополнительная семейная поддержка (yes/no).
        /// </summary>
        public string Famsup { get; } = famsup;
        /// <summary>
        /// Оплата дополнительных занятий (yes/no).
        /// </summary>
        public string Paid { get; } = paid;
        /// <summary>
        /// Участие в дополнительных внеучебных занятиях (yes/no).
        /// </summary>
        public string Activities { get; } = activities;
        /// <summary>
        /// Посещение детского сада (yes/no).
        /// </summary>
        public string Nursery { get; } = nursery;
        /// <summary>
        /// Желание получить высшее образование (yes/no).
        /// </summary>
        public string Higher { get; } = higher;

        /// <summary>
        /// Создает клон текущего объекта Academic.
        /// </summary>
        /// <returns>Клон объекта Academic.</returns>
        public Academic Clone()
        {
            return new Academic(Traveltime, Studytime, Faikures, Schoolsup, Famsup, Paid, Activities, Nursery, Higher);
        }
        /// <summary>
        /// Возвращает строковое представление объекта Academic.
        /// </summary>
        /// <returns>Строковое представление объекта Academic.</returns>
        public override string ToString()
        {
            return $"{Traveltime},{Studytime},{Faikures},{Schoolsup},{Famsup},{Paid},{Activities},{Nursery},{Higher},";
        }
    }
}
