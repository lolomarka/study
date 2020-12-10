using System;

namespace OOPlab10
{
    public interface IExecutable
    {
        /// <summary>
        /// Вывод строчки информации на консоль
        /// </summary>
        void ShowInfo();
        /// <summary>
        /// Строчка информации
        /// </summary>
        /// <returns>Строчку с информацией об экземпляре класса</returns>
        string Info();
    }
}