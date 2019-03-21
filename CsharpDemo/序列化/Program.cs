using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Web.Script.Serialization;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace 序列化
{
    class Program
    {
        static void Main(string[] args)
        {
            var LBJ = new Player();
            LBJ.Age = 34;
            LBJ.Position = "SF";

            //json序列化
            JavaScriptSerializer jsSer = new JavaScriptSerializer();
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(string));
            var msg = jsSer.Serialize(LBJ);
            //Console.WriteLine(msg);//{"Name":null,"Age":34,"Position":"SF"}     
            //1、序列化只序列化数据。（字段值=属性值，方法不会被序列化），
            //2、序列化后，只是把对象的存储格式改变了，内容不变
            //xml序列化
            XmlSerializer xml = new XmlSerializer(typeof(Player));
            using (FileStream fs = new FileStream("person.xml",FileMode.OpenOrCreate))
            {
               // xml.Serialize(fs,LBJ);
            }
            //二进制序列化
            BinaryFormatter bf = new BinaryFormatter();
            using (FileStream f = new FileStream("player",FileMode.OpenOrCreate)) 
            {
               // bf.Serialize(f,LBJ);
            }

            //反序列化
            //反序列化时，需要原类型所在的程序集
            BinaryFormatter b = new BinaryFormatter();
            using (FileStream s = new FileStream("player",FileMode.Open))
            {
                var player = b.Deserialize(s);
                Console.WriteLine(player);
            }
            Console.WriteLine("OK");
            Console.ReadKey();
        }
    }
    [Serializable]
     public class  Player:Person
    {
        [NonSerialized]
        private string _position;
        //被序列化类中的父类、子类，及其中属性字段类型都为可序列化
        //可序列化时建议用字段，自动属性每次生成的字段不一样，所以无法标记为可序列化
        public string Name { get; set; }
        public int  Age { get; set; }
       
        public string Position { get; set; }

        public void BreakThrough()
        {
            Console.WriteLine("突破对手上篮");
        }
        //方法中的类型不用序列化
        public Star GrowUp()    
        {
            return new Star();
        }
    }
    [Serializable]
    public class Person
    {
        public string Name { get; set; }
    }

    public class Star:Player
    {
        public Star()
        {
            Console.WriteLine("成长为球星");
        }
    }
}
