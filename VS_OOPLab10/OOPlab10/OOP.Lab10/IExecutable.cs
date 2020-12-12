using System;

namespace OOPlab10
{
    public interface IExecutable : IComparable, ICloneable
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
        /// <summary>
        /// Строчка информации (не виртуальная)
        /// </summary>
        /// <returns>Строчку с информацией об экземпляре</returns>
        string Info_No_Virt();
    }
}