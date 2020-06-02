using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projec03
{
    class Program
    {

        static void Main(string[] args)
        {
            int size;
            bool isInt = false;
            char userInput;
            int[] randomArray, ascendingArray, reversedArray, vShapedArray, aShapedArray;

            var stopwatch = new Stopwatch();

            do
            {
                Console.Clear();
                Console.WriteLine("Choose:\n'1' for Bubble Sort;\n'2' for Selection Sort;\n'3' for Heap Sort;\n'4' for Counting sort(array size = 1.000.000);");
                userInput = Console.ReadKey().KeyChar;

            } while (!(userInput == '1' || userInput == '2' || userInput == '3' || userInput == '4'));
            Console.Clear();

            switch (userInput)
            {
                case '1':
                case '2':
                case '3':
                    do
                    {
                        Console.Clear();
                        Console.WriteLine("What size of array should be?");
                        isInt = int.TryParse(Console.ReadLine(), out size);
                    } while (!isInt || !(size > 0) || !(size < int.MaxValue));
                    Console.Clear();

                    randomArray = ArrayGenerator.Generate(size);
                    ascendingArray = ArrayGenerator.GenerateSorted(size);
                    reversedArray = ArrayGenerator.GenerateReversed(size);
                    vShapedArray = ArrayGenerator.GenerateVShaped(size);
                    aShapedArray = ArrayGenerator.GenerateAShaped(size);

                    switch (userInput)
                    {
                        case '1':
                            stopwatch.Start();
                            ArrayGenerator.BubbleSort(randomArray);
                            stopwatch.Stop();
                            Console.WriteLine($"randomArray:      {stopwatch.Elapsed.TotalMilliseconds}ms");
                            stopwatch.Reset();

                            stopwatch.Start();
                            ArrayGenerator.BubbleSort(ascendingArray);
                            stopwatch.Stop();
                            Console.WriteLine($"ascendingArray:   {stopwatch.Elapsed.TotalMilliseconds}ms");
                            stopwatch.Reset();

                            stopwatch.Start();
                            ArrayGenerator.BubbleSort(reversedArray);
                            stopwatch.Stop();
                            Console.WriteLine($"reversedArray:    {stopwatch.Elapsed.TotalMilliseconds}ms");
                            stopwatch.Reset();

                            stopwatch.Start();
                            ArrayGenerator.BubbleSort(vShapedArray);
                            stopwatch.Stop();
                            Console.WriteLine($"vShapedArray:     {stopwatch.Elapsed.TotalMilliseconds}ms");
                            stopwatch.Reset();

                            stopwatch.Start();
                            ArrayGenerator.BubbleSort(aShapedArray);
                            stopwatch.Stop();
                            Console.WriteLine($"aShapedArray:     {stopwatch.Elapsed.TotalMilliseconds}ms");
                            stopwatch.Reset();

                            break;
                        case '2':
                            stopwatch.Start();
                            ArrayGenerator.SelectionSort(randomArray);
                            stopwatch.Stop();
                            Console.WriteLine($"randomArray:      {stopwatch.Elapsed.TotalMilliseconds}ms");
                            stopwatch.Reset();

                            stopwatch.Start();
                            ArrayGenerator.SelectionSort(ascendingArray);
                            stopwatch.Stop();
                            Console.WriteLine($"ascendingArray:   {stopwatch.Elapsed.TotalMilliseconds}ms");
                            stopwatch.Reset();

                            stopwatch.Start();
                            ArrayGenerator.SelectionSort(reversedArray);
                            stopwatch.Stop();
                            Console.WriteLine($"reversedArray:    {stopwatch.Elapsed.TotalMilliseconds}ms");
                            stopwatch.Reset();

                            stopwatch.Start();
                            ArrayGenerator.SelectionSort(vShapedArray);
                            stopwatch.Stop();
                            Console.WriteLine($"vShapedArray:     {stopwatch.Elapsed.TotalMilliseconds}ms");
                            stopwatch.Reset();

                            stopwatch.Start();
                            ArrayGenerator.SelectionSort(aShapedArray);
                            stopwatch.Stop();
                            Console.WriteLine($"aShapedArray:     {stopwatch.Elapsed.TotalMilliseconds}ms");
                            stopwatch.Reset();

                            break;
                        case '3':
                            stopwatch.Start();
                            ArrayGenerator.HeapSort(randomArray);
                            stopwatch.Stop();
                            Console.WriteLine($"randomArray:     {stopwatch.Elapsed.TotalMilliseconds}ms");
                            stopwatch.Reset();

                            stopwatch.Start();
                            ArrayGenerator.HeapSort(ascendingArray);
                            stopwatch.Stop();
                            Console.WriteLine($"ascendingArray:  {stopwatch.Elapsed.TotalMilliseconds}ms");
                            stopwatch.Reset();

                            stopwatch.Start();
                            ArrayGenerator.HeapSort(reversedArray);
                            stopwatch.Stop();
                            Console.WriteLine($"reversedArray:   {stopwatch.Elapsed.TotalMilliseconds}ms");
                            stopwatch.Reset();

                            stopwatch.Start();
                            ArrayGenerator.HeapSort(vShapedArray);
                            stopwatch.Stop();
                            Console.WriteLine($"vShapedArray:    {stopwatch.Elapsed.TotalMilliseconds}ms");
                            stopwatch.Reset();

                            stopwatch.Start();
                            ArrayGenerator.HeapSort(aShapedArray);
                            stopwatch.Stop();
                            Console.WriteLine($"aShapedArray:    {stopwatch.Elapsed.TotalMilliseconds}ms");
                            stopwatch.Reset();

                            break;
                    }
                    break;
                case '4':
                    int max;
                    do
                    {
                        Console.Clear();
                        Console.WriteLine("What maximum int value should be?(values: from 0 to max)");
                        isInt = int.TryParse(Console.ReadLine(), out max);
                    } while (!isInt || !(max > 0) || !(max < int.MaxValue - 1));
                    Console.Clear();

                    randomArray = ArrayGenerator.GenerateSpecific(max);
                    ascendingArray = ArrayGenerator.GenerateSortedSpecific(max);
                    reversedArray = ArrayGenerator.GenerateReversedSpecific(max);
                    vShapedArray = ArrayGenerator.GenerateVShapedSpecific(max);
                    aShapedArray = ArrayGenerator.GenerateAShapedSpecific(max);

                    stopwatch.Start();
                    ArrayGenerator.CountingSort(randomArray, max);
                    stopwatch.Stop();
                    Console.WriteLine($"randomArray:      {stopwatch.Elapsed.TotalMilliseconds}ms");
                    stopwatch.Reset();

                    stopwatch.Start();
                    ArrayGenerator.CountingSort(ascendingArray, max);
                    stopwatch.Stop();
                    Console.WriteLine($"ascendingArray:   {stopwatch.Elapsed.TotalMilliseconds}ms");
                    stopwatch.Reset();

                    stopwatch.Start();
                    ArrayGenerator.CountingSort(reversedArray, max);
                    stopwatch.Stop();
                    Console.WriteLine($"reversedArray:    {stopwatch.Elapsed.TotalMilliseconds}ms");
                    stopwatch.Reset();

                    stopwatch.Start();
                    ArrayGenerator.CountingSort(vShapedArray, max);
                    stopwatch.Stop();
                    Console.WriteLine($"vShapedArray:     {stopwatch.Elapsed.TotalMilliseconds}ms");
                    stopwatch.Reset();

                    stopwatch.Start();
                    ArrayGenerator.CountingSort(aShapedArray, max);
                    stopwatch.Stop();
                    Console.WriteLine($"aShapedArray:     {stopwatch.Elapsed.TotalMilliseconds}ms");
                    stopwatch.Reset();
                    break;
            }

            Console.ReadLine();
        }
    }
}
