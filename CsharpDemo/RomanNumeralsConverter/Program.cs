using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RomanNumeralsConverter
{
    class Program
    {
        //创建罗马数字字典
        static Dictionary<string, int> romanNumDict = new Dictionary<string, int>()
        {
            {"I",1}, {"V",5}, {"X",10}, {"L",50}, {"C",100}, {"D",500}, {"M",1000}
        };
        //设置显示样式
        static RomanNumPrintArray printArray = new RomanNumPrintArray("-", "|", 1);
        public static void Main(string[] args)
        {
            //控制台输入
            Console.WriteLine("请输入罗马数字符号：");
            while (true)
            {
                var nextStep = Console.ReadLine();

                switch (nextStep)
                {
                    case "set size 1":
                        printArray.Size = 1;
                        break;
                    case "set size 2":
                        printArray.Size = 2;
                        break;
                    case "exit":
                        return;
                    default:
                        if (!string.IsNullOrEmpty(nextStep))
                        {
                            var num = nextStep.ToUpper();
                            Print(num);
                        }
                        break;
                }
            }
            ;
        }
        /// <summary>
        /// 将罗马数字打印到控制台
        /// </summary>
        public static void Print(string num)
        {
            var nums = num.ToList();
            var arrayTemp = new string[printArray.Size * 2 + 3];
            if (nums.All(n => romanNumDict.ContainsKey(n.ToString())))
            {
                //获取罗马数字需减去的数值
                var dict = new Dictionary<char, int>();
                for (int i = 0; i < nums.Count-1; i++)
                {
                    if (romanNumDict[nums[i].ToString()] < romanNumDict[nums[i+1].ToString()]&&"IXC".Contains(nums[i]))
                    {
                        if (dict.ContainsKey(nums[i]))
                        {
                            dict[nums[i]]++;
                        }
                        dict.Add(nums[i],1);
                    }
                }
                //求出阿拉伯数字值
                var sum = nums.Sum(n => romanNumDict[n.ToString()]);
                if (dict.Any())
                {
                    sum = sum - dict.Sum(d => romanNumDict[d.Key.ToString()]*d.Value)*2;
                }
                nums = sum.ToString().ToList(); 
            }
            else
            {
                //设置默认索引返回输入有误信息
                nums = new List<char>()
                {
                    'E'
                };
            }
            //将二维数组拼接成字符串打印
            foreach (var c in nums)
            {
                var array = printArray[c];
                for (int i = 0; i < printArray.Size * 2 + 3; i++)
                {
                    var sbr = new StringBuilder();
                    for (int j = 0; j < printArray.Size + 2; j++)
                    {
                        if (string.IsNullOrEmpty(array[i, j]))
                        {
                            sbr.Append(" ");
                        }
                        sbr.Append(array[i, j]);
                    }

                    if (c == 'E')
                    {
                        arrayTemp[i] = (sbr.Append(" ")).ToString();
                    }
                    else
                    {
                        arrayTemp[i] += sbr.ToString();
                    }
                }
            }
            Console.WriteLine("输出结果：");
            foreach (var str in arrayTemp)
            {
                Console.WriteLine(str);
            }
        }
    }
}

