using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 数据库
{
    class Program
    {
        static void Main(string[] args)
        {

            var list = GetIntersection(new List<int>()
            {
                1, 2,5,74
            }, new List<int>()
            {
                1,3,67,8,7
            });
          
            Console.ReadKey();

        }

        public static List<int> GetIntersection(List<int> n1, List<int> n2)
        {
            var list = new List<int>();

            QuickSort(n1, 0, n1.Count - 1);
            QuickSort(n2, 0, n2.Count - 1);

            int i = 0;
            int j = 0;
            while (i < n1.Count && j < n2.Count)
            {
                if (n1[i] == n2[j])
                {
                    list.Add(n1[i]);
                    i++;
                    j++;
                }
                else if (n1[i] < n2[j])
                {
                    i++;
                }
                else
                {
                    j++;
                }
            }

            return list;
        }

        public static void QuickSort(List<int> list, int begin, int end)
        {
            if (begin >= end)
            {
                return;
            }
            int index = Partitioning(list, begin, end);
            QuickSort(list, begin, index - 1);
            QuickSort(list, index + 1, end);
        }

        public static int Partitioning(List<int> list, int begin, int end)
        {
            int pivot = list[begin];
            int index = begin;
            while (begin < end)
            {
                while (begin < end)
                {
                    if (list[end] < pivot)
                    {
                        list[index] = list[end];
                        index = end;
                        begin++;
                        break;
                    }
                    end--;
                }

                while (begin < end)
                {
                    if (list[begin] > pivot)
                    {
                        list[index] = list[begin];
                        index = begin;
                        end--;
                        break;
                    }
                    begin++;
                }
            }
            list[end] = pivot;
            return index;
        }
    }
}
