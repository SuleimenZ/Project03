using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace Projec03
{
    class ArrayGenerator
    {

        public static int[] Generate(int size)
        {
            var rnd = new Random();
            var array = new int[size];

            for (int i = 0; i < size; i++)
            {
                array[i] = rnd.Next(int.MinValue, int.MaxValue);
            }

            return array;
        }

        public static int[] GenerateSpecific(int max) // values from 0 to max, size 1.000.000
        {
            var rnd = new Random();
            var array = new int[1000000];

            for (int i = 0; i < 1000000; i++)
            {
                array[i] = rnd.Next(max + 1);
            }

            return array;
        }

        public static int[] GenerateSorted(int size)
        {
            var array = Generate(size);
            Array.Sort(array);

            return array;
        }

        public static int[] GenerateSortedSpecific(int max) // values from 0 to max, size 1.000.000
        {
            var array = GenerateSpecific(max);
            Array.Sort(array);

            return array;
        }


        public static int[] GenerateReversed(int size)
        {
            var array = GenerateSorted(size);
            Array.Reverse(array);

            return array;
        }

        public static int[] GenerateReversedSpecific(int max) // values from 0 to max, size 1.000.000
        {
            var array = GenerateSortedSpecific(max);
            Array.Reverse(array);

            return array;
        }

        public static int[] GenerateConstant(int size)
        {
            var rnd = new Random();
            var array = new int[size];

            var value = rnd.Next(int.MinValue, int.MaxValue);

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = value;
            }

            return array;
        }

        public static int[] GenerateConstantSpecific(int max) // values from 0 to max, size 1.000.000
        {
            var rnd = new Random();
            var array = new int[1000000];

            var value = rnd.Next(max + 1);

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = value;
            }

            return array;
        }

        public static int[] GenerateAShaped(int size)
        {
            int index = 1;
            int first = 1; // index 0 is always at 0 so we start from 1;
            int last = size - 1;

            var array = GenerateSorted(size);
            var temparray = new int[size];

            array.CopyTo(temparray, 0);

            while (first <= last)
            {
                if (index % 2 == 1)
                {
                    array[last--] = temparray[index++];
                }
                else
                {
                    array[first++] = temparray[index++];
                }
            }

            return array;
        }

        public static int[] GenerateAShapedSpecific(int max) // values from 0 to max, size 1.000.000
        {
            int index = 1;
            int first = 1; // index 0 is always at 0 so we start from 1;
            int last = 1000000 - 1;

            var array = GenerateSortedSpecific(max);
            var temparray = new int[1000000];

            array.CopyTo(temparray, 0);

            while (first <= last)
            {
                if (index % 2 == 1)
                {
                    array[last--] = temparray[index++];
                }
                else
                {
                    array[first++] = temparray[index++];
                }
            }

            return array;
        }

        public static int[] GenerateVShaped(int size)
        {
            int index = (size - 1) / 2; // center
            int tempindex = 0;

            var array = GenerateSorted(size);
            var temparray = new int[size];

            array.CopyTo(temparray, 0);

            for (int i = 1; tempindex != size; i++)
            {
                if (i % 2 == 1)
                {
                    array[index] = temparray[tempindex++];
                    index += i;
                }
                else
                {
                    array[index] = temparray[tempindex++];
                    index -= i;
                }
            }

            return array;
        }

        public static int[] GenerateVShapedSpecific(int max) // values from 0 to max, size 1.000.000
        {
            int index = (1000000 - 1) / 2; // center
            int tempindex = 0;

            var array = GenerateSortedSpecific(max);
            var temparray = new int[1000000];

            array.CopyTo(temparray, 0);

            for (int i = 1; tempindex != 1000000; i++)
            {
                if (i % 2 == 1)
                {
                    array[index] = temparray[tempindex++];
                    index += i;
                }
                else
                {
                    array[index] = temparray[tempindex++];
                    index -= i;
                }
            }

            return array;
        }

        public static void SelectionSort(int[] array)
        {
            int length = array.Length;

            for (int i = 0; i < length - 1; i++)
            {
                int index = i;

                for (int j = i + 1; j < length; j++) // from unsorted to the end
                {
                    if (array[j] < array[index])
                    {
                        index = j;
                    }
                }

                int temp = array[index];
                array[index] = array[i];
                array[i] = temp;
            }
        }

        public static void BubbleSort(int[] array)
        {
            int tempvalue;
            bool swapped;

            for (int i = 0; i < array.Length - 1; i++)
            {
                swapped = false;
                for (int j = 0; j < array.Length - i - 1; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        tempvalue = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = tempvalue;
                        swapped = true;
                    }
                }

                if (swapped == false)
                {
                    break;
                }
            }
        }

        public static void HeapSort(int[] array)
        {
            int length = array.Length;

            for (int i = length / 2 - 1; i >= 0; i--)
            {
                MakeHeap(array, length, i);
            }

            for (int i = length - 1; i > 0; i--)
            {
                int temp = array[0];
                array[0] = array[i];
                array[i] = temp;

                MakeHeap(array, i, 0);
            }
        }

        private static void MakeHeap(int[] array, int length, int i)
        {
            int largest = i;
            int left = 2 * i + 1; // left child
            int right = 2 * i + 2; // right child
            int temp;

            if (left < length && array[left] > array[largest])
            {
                largest = left;
            }

            if (right < length && array[right] > array[largest])
            {
                largest = right;
            }

            if (largest != i)
            {
                temp = array[i];
                array[i] = array[largest];
                array[largest] = temp;

                MakeHeap(array, length, largest);
            }
        }


        public static void CountingSort(int[] array, int max)
        {
            var count = new int[max + 1];

            for (int i = 0; i < array.Length; i++)
            {
                ++count[array[i]];
            }

            int index = 0;

            for (int i = 0; i < count.Length; i++)
            {
                for (int j = 0; j < count[i]; j++)
                {
                    array[index++] = i;
                }
            }
        }

        private static int FindPivot(int[] array, int start, int end)
        {
            int pivot = array[start];
            while (true)
            {

                while (array[start] < pivot)
                {
                    start++;
                }

                while (array[end] > pivot)
                {
                    end--;
                }

                if (start < end)
                {
                    if (array[start] == array[end])
                    {
                        return end;
                    }

                    int temp = array[start];
                    array[start] = array[end];
                    array[end] = temp;

                }
                else
                {
                    return end;
                }
            }
        }
    }
}
