namespace LearnAlgorithms
{
    /// <summary>
    /// Содержит реализации различных алгоритмов сортировки массивов целочисленного типа
    /// </summary>
    public static class ArraySorting
    {
        /// <summary>
        /// Алгоритм быстрой сортировки. Идея алгоритма следующая:
        /// 1. Выбирается опорный элемент (это может быть любой элемент, от этого не зависит правильность алгоритма, но для улучшения эффективности может выбираться средний или случайный элемент для больших массивов).
        /// 2. Массив разделяется на две части: первая часть - это элементы меньше опорного, вторая часть - это все элементы, которые больше опорного.
        /// 3. Рекурсивно выполняются вышеуказанные шаги для подмассивов.
        /// Имеет сложность O(n * logn), однако, может быть худший случай O(n^2) в том случае, если массив уже отсортирован.
        /// Является самым эффективным алгоритмом сортировки. Использует стратегию "Разделяй и властвуй" (рекурсивный метод решения задач).
        /// </summary>
        public static int[] QuickSort(int[] array)
        {
            return QuickSort(array, 0, array.Length - 1);
        }

        /// <summary>
        /// Рекурсивный метод реализации быстрой сортировки
        /// </summary>
        private static int[] QuickSort(int[] array, int minIndex, int maxIndex)
        {
            // Базовый случай: если в массиве всего один элемент, то сортировать его не нужно
            if (minIndex >= maxIndex)
            {
                return array;
            }

            // Получаем индекс опорного элемента и используем его для дальнейшей сортировки подмассивов
            var pivotIndex = Partition(array, minIndex, maxIndex);
            // Сортировка первой половины массива
            QuickSort(array, minIndex, pivotIndex - 1);
            // Сортировка второй половины массива
            QuickSort(array, pivotIndex + 1, maxIndex);

            return array;
        }
        
        /// <summary>
        /// Найти индекс опорного элемента
        /// </summary>
        private static int Partition(int[] array, int minIndex, int maxIndex)
        {
            var pivot = minIndex - 1;
            // Осуществляем проход по подмассиву (не включая последний элемент)
            for (var i = minIndex; i < maxIndex; i++)
            {
                // Если значение элемента на итерации меньше, чем значение последнего элемента подмассива,
                // то меняем местами их значения и инкрементируем значение индекса опорного элемента
                if (array[i] < array[maxIndex])
                {
                    pivot++;
                    Swap(ref array[pivot], ref array[i]);
                }
            }

            pivot++;
            Swap(ref array[pivot], ref array[maxIndex]);
            return pivot;
        }

        /// <summary>
        /// Поменять значения элементов местами
        /// </summary>
        private static void Swap(ref int a, ref int b)
        {
            var tmp = a;
            a = b;
            b = tmp;
        }
    }
}