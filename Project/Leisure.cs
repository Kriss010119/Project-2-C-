using System;
using System.Net;

namespace Project
{
    /// <summary>
    /// Представляет данные о досуге студента.
    /// </summary>
    public class Leisure(
         string internet,
         string romantic,
         string famrel,
         int freetime,
         int gout
    )
    {
        /// <summary>
        /// Доступ к интернету дома.
        /// </summary>
        public string Internet { get; } = internet;

        /// <summary>
        /// Наличие романтических отношений.
        /// </summary>
        public string Romantic { get; } = romantic;

        /// <summary>
        /// Качество семейных отношений.
        /// </summary>
        public string Famrel { get; } = famrel;

        /// <summary>
        /// Свободное время после школы.
        /// </summary>
        public int Freetime { get; } = freetime;

        /// <summary>
        /// Частота прогулок с друзьями.
        /// </summary>
        public int Gout { get; } = gout;

        /// <summary>
        /// Создает клон текущего объекта Leisure.
        /// </summary>
        /// <returns>Клон объекта Leisure.</returns>
        public Leisure Clone()
        {
            return new Leisure(Internet, Romantic, Famrel, Freetime, Gout);
        }
        /// <summary>
        /// Возвращает строковое представление объекта Leisure.
        /// </summary>
        /// <returns>Строковое представление объекта Leisure.</returns>
        public override string ToString()
        {
            return $"{Internet},{Romantic},{Famrel},{Freetime},{Gout},";
        }
    }
}
