using System.IO;
using System.Collections.Generic;
using System.Text;

namespace csv
{
    public class csv
    {
        public string path;
        public char div;
   
        public csv(string PATH)
        {
            div = ';';
            path = PATH;
            try
            {
                StreamReader sr = new StreamReader(path);
                sr.Close();
            }
            catch(FileNotFoundException)
            {
                UTF8Encoding utf8 = new UTF8Encoding();
                string line = "ID;Имя,Фамилия;Отчество;Пол;День рождения;День смерти";
                byte[] encodedBytes = utf8.GetBytes(line);
                File.WriteAllBytes(path, encodedBytes);
            }
        }

        public csv(string PATH, char DIV)
        {
            div = DIV;
            path = PATH;
        }
        
        public List<string> Reading()
        {
            List<string> result = new List<string>();
            using (StreamReader sr = new StreamReader(path))
            {
                string line;
                sr.ReadLine();
                while ((line =sr.ReadLine())!=null)
                {
                    result.Add(line);
                }
            }
            return result;
        }

        public void Writing (string line)
        {
            FileStream fs = File.OpenWrite(path);
            fs.Lock(1, 1);
            fs.Position=fs.Length;
            UTF8Encoding utf8 = new UTF8Encoding();
            byte[] encodedBytes = utf8.GetBytes(line);
            fs.Write(encodedBytes, 0, line.Length);
            fs.Close();
        }
    }
}

namespace Program
{
    public class Program
    {
        static public int Main()
        {
            csv.csv File = new csv.csv("C:/Users/admin/Documents/Family-tree/Family-tree/test.csv");
            File.Writing("1,2,3,4,5");
            return 1;
        }
    }
}