using System;

namespace Program
{
    /// <summary>
    /// Односвязный список с элементами обобщённого типа.
    /// 
    /// Параметр <typeparamref name="T"/> обозначает тип значений,
    /// которые будут храниться в списке.
    /// Например:
    /// - LinkedList<int>  — список целых чисел
    /// - LinkedList<string> — список строк
    /// - LinkedList<MyClass> — список объектов пользовательского класса
    /// </summary>
    public class LinkedList<T>
    {
        // Внутренний узел списка
        private class Node
        {
            public T Value { get; set; }
            public Node? Next { get; set; }

            public Node(T value)
            {
                Value = value;
                Next = null;
            }
        }

        private Node? head;

        /// <summary>
        /// Добавить элемент в конец списка.
        /// Если список пустой – новый узел становится head.
        /// Если не пустой – в цикле (или рекурсией) пройти по Next до конца и добавить там новый узел.
        /// </summary>
        public void Add(T item)
        {
            throw new NotImplementedException("implement me");
        }

        /// <summary>
        /// Удалить первый найденный элемент по значению.
        /// Если элемент найден – удалить и вернуть true.
        /// Если элемента нет – вернуть false.
        /// </summary>
        public bool Remove(T item)
        {
            throw new NotImplementedException("implement me");
        }

        /// <summary>
        /// Вернуть элемент по индексу (0-based).
        /// Пройти по цепочке Next, пока не дойдём до нужного индекса.
        /// Если индекс за пределами списка – выбросить ArgumentOutOfRangeException.
        /// </summary>
        public T Get(int index)
        {
            throw new NotImplementedException("implement me");
        }

        /// <summary>
        /// Подсчитать количество элементов в списке.
        /// Пройти по цепочке Next от head до конца, увеличивая счётчик.
        /// Вернуть количество.
        /// </summary>
        public int Count()
        {
            throw new NotImplementedException("implement me");
        }

        /// <summary>
        /// Очистить список.
        /// Достаточно обнулить head, тогда вся цепочка узлов будет недоступна и сборщик мусора освободит память.
        /// </summary>
        public void Clear()
        {
            throw new NotImplementedException("implement me");
        }
    }
}
