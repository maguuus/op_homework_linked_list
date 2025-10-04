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

        private Node? _head;

        /// <summary>
        /// Добавить элемент в конец списка.
        /// Если список пустой – новый узел становится head.
        /// Если не пустой – в цикле (или рекурсией) пройти по Next до конца и добавить там новый узел.
        /// </summary>
        public void Add(T item)
        {
            Node newNode = new Node(item);
            if (_head == null)
            {
                _head = newNode;
            }
            else
            {
                Node current = _head;
                while (current.Next != null)
                {
                    current = current.Next;
                }
                current.Next = newNode;
            }
        }

        /// <summary>
        /// Удалить первый найденный элемент по значению.
        /// Если элемент найден – удалить и вернуть true.
        /// Если элемента нет – вернуть false.
        /// </summary>
        public bool Remove(T item)
        {
            if (_head == null)
            {
                return false;
            }
            
            if (Equals(_head.Value, item))
            {
                _head = _head.Next;
                return true;
            }
            
            Node? current =  _head;
            while (current.Next != null)
            {
                if (Equals(current.Next.Value, item))
                {
                    current.Next = current.Next.Next;
                    return true;
                }
                current = current.Next;
            }

            return false;
        }

        /// <summary>
        /// Вернуть элемент по индексу (0-based).
        /// Пройти по цепочке Next, пока не дойдём до нужного индекса.
        /// Если индекс за пределами списка – выбросить ArgumentOutOfRangeException.
        /// </summary>
        public T Get(int index)
        {
            if (index < 0) 
                throw new ArgumentOutOfRangeException();
            Node? current = _head;
            int currentIndex = 0;
            while (current != null)
            {
                if (currentIndex == index)
                    return current.Value;
                
                current = current.Next;
                currentIndex++;
            }
            throw new ArgumentOutOfRangeException();
        }

        /// <summary>
        /// Подсчитать количество элементов в списке.
        /// Пройти по цепочке Next от head до конца, увеличивая счётчик.
        /// Вернуть количество.
        /// </summary>
        public int Count()
        {
            int count = 0;
            Node? current = _head;
            while (current != null)
            {
                count++;
                current = current.Next;
            }
            return count;
        }

        /// <summary>
        /// Очистить список.
        /// Достаточно обнулить head, тогда вся цепочка узлов будет недоступна и сборщик мусора освободит память.
        /// </summary>
        public void Clear()
        {
            _head = null;
        }

        private static bool Equals(T x, T y)
        {
            return EqualityComparer<T>.Default.Equals(x, y);
        }
    }
}