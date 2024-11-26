using System;

namespace Project
{
    /// <summary>
    /// Представляет семейные данные студента.
    /// </summary>
    public class Family(
         string famsize,
         string pstatus,
         int medu,
         int fedu,
         string mjob,
         string fjob,
         string reasone,
         string guardian
    )
    {
        /// <summary>
        /// Размер семьи.
        /// </summary>
        public string Famsize { get; } = famsize;
        /// <summary>
        /// Статус родителей.
        /// </summary>
        public string Pstatus { get; } = pstatus;
        /// <summary>
        /// Образование матери.
        /// </summary>
        public int Medu { get; } = medu;
        /// <summary>
        /// Образование отца.
        /// </summary>
        public int Fedu { get; } = fedu;
        /// <summary>
        /// Работа матери.
        /// </summary>
        public string Mjob { get; } = mjob;
        /// <summary>
        /// Работа отца.
        /// </summary>
        public string Fjob { get; } = fjob;
        /// <summary>
        /// Причина выбора школы.
        /// </summary>
        public string Reason { get; } = reasone;
        /// <summary>
        /// Опекун.
        /// </summary>
        public string Guardian { get; } = guardian;

        /// <summary>
        /// Создает клон текущего объекта Family.
        /// </summary>
        /// <returns>Клон объекта Family.</returns>
        public Family Clone()
        {
            return new Family(Famsize, Pstatus, Medu, Fedu, Mjob, Fjob, Reason, Guardian);
        }
        /// <summary>
        /// Возвращает строковое представление объекта Family.
        /// </summary>
        /// <returns>Строковое представление объекта Family.</returns>
        public override string ToString()
        {
            return $"{Famsize},{Pstatus},{Medu},{Fedu},{Mjob},{Fjob},{Reason},{Guardian},";
        }
    }
}
