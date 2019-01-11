using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CTS_CLS_CLR
{
    static class Program
    {
        static void Main()
        {
            /*
             * CTS、CLS、CLR
              1、 .Net平台下不只有C#语言，还有VB.Net、F#等语言。IL是程序最终编译的可以执行的二进制代码（托管代码），不同的语言最终都编译成标准的IL(中间语言，MSIL)；这样C#可以调用VB.Net写的程序集（Assembly，dll、exe）。在.Net平台下：不同语言之间可以互联互通、互相调用 
              2、不同语言中的数据类型各不相同，比如整数类型在VB.Net中是Integer、C#中是int。.Net平台规定了通用数据类型(CTS，Common Type System)，各个语言编译器把自己语言的类型翻译成CTS中的类型。int是C#中的类型，Int32是CTS中的类型；int是C#的关键字，Int32不是。 
              面试题：
              string和String的区别是什么？答：string是C#语言的中的类型，String是CTS中的类型
              int和Int32的区别是什么？ 答：int是C#中的类型，Int32是CTS中的数据类型
              3、不同语言的语法不一样，比如定义一个类A继承自B的C#语法是class A:B{}，VB.Net的语法是Class A  Inherits B。.Net平台规定了通用语言规范（CLS， Common Language Specification ） 
              4、IL代码由公共语言运行时（CLR， Common Language Runtime ）驱动运行，CLR提供了垃圾回收（GC， Garbage Collection，没有任何引用的对象可以被自动回收，分析什么时候可以被回收）、JIT（即时编译器）； 
              5、值类型是放在“栈内存”中，引用类型放到“堆内存”，栈内存会方法结束后自动释放，“堆内存”则需要GC来回收。
              
             */
        }
    }
}
