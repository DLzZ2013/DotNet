using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RomanNumeralsConverter
{
    class RomanNumPrintArray
    {


        public int Size { get; set; }

        public string AcrossLine { get; set; }

        public string StandLine { get; set; }

        public RomanNumPrintArray(string acrossLine, string standLine, int size)
        {
            this.AcrossLine = acrossLine;
            this.StandLine = standLine;
            this.Size = size;
        }

        public string[,] this[char index]
        {
            get
            {
                string[,] array = new string[3 + 2 * Size, 2 + Size];
                if ("147".Contains(index))
                {
                    for (int i = 1; i < Size + 1; i++)
                    {
                        array[i, Size + 1] = StandLine;
                        array[i + Size + 1, Size + 1] = StandLine;

                        if (index == '7')
                        {
                            array[0, i] = AcrossLine;
                        }

                        if (index == '4')
                        {
                            array[i, 0] = StandLine;
                            array[Size + 1, i] = AcrossLine;
                        }
                    }
                }
                else if ("0235689E".Contains(index))
                {
                    //将数组值置为8的二维数组
                    for (int i = 1; i < Size + 1; i++)
                    {
                        array[0, i] = AcrossLine;
                        array[Size + 1, i] = AcrossLine;
                        array[Size * 2 + 2, i] = AcrossLine;
                        array[i, 0] = StandLine;
                        array[i + Size + 1, 0] = StandLine;
                        array[i, Size + 1] = StandLine;
                        array[i + Size + 1, Size + 1] = StandLine;
                        //删减
                        switch (index)
                        {
                            case '0':
                                array[Size + 1, i] = "";
                                break;
                            case '2':
                                array[i, 0] = "";
                                array[i + Size + 1, Size + 1] = "";
                                break;
                            case '3':
                                array[i, 0] = "";
                                array[i + Size + 1, 0] = "";
                                break;
                            case '5':
                                array[i, Size + 1] = "";
                                array[i + Size + 1, 0] = "";
                                break;
                            case '6':
                                array[i, Size + 1] = "";
                                break;
                            case '9':
                                array[i + Size + 1, 0] = "";
                                break;
                            case 'E':
                                array[i, Size + 1] = "";
                                array[i + Size + 1, Size + 1] = "";
                                break;
                        }
                    }
                }
                return array;
            }
        }
    }
}
