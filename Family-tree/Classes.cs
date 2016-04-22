using System;
using System.Globalization;
using System.Collections.Generic;

namespace Objects
{
    /*Класс "Отношение" определяет отношение между двумя людьми:
     * 1.Время совместной жизни*/
    public class Relation
    {
        public int ID;
        public int Man1ID;
        public int Man2ID;
        public int YEAR1;
        public int YEAR2;
        public static int MaxID;//Данная переменная ннеобходима для создания новой связи

        public Relation(string csvLine, char div)//int id, int man1ID, int man2ID, int year1, int year2)
        {
            string[] parts = csvLine.Split(div);
            ID = Int32.Parse(parts[0]);
            if (MaxID < ID)
                MaxID = ID;
            Man1ID = Int32.Parse(parts[1]);
            Man2ID = Int32.Parse(parts[2]);
            YEAR1 = Int32.Parse(parts[3]);
            YEAR2 = Int32.Parse(parts[4]);
        }

        public Relation(Man man1, Man man2, int year1, int year2)
        {
            Man1ID = man1.ID;
            Man2ID = man2.ID;
            ID = MaxID + 1;
            MaxID++;
            YEAR1 = year1;
            YEAR2 = year2;
        }

        public string ToLine()
        {
            string result= string.Concat(ID.ToString(),";",Man1ID.ToString(),";", Man2ID.ToString(),";", YEAR1.ToString(),";", YEAR2.ToString());
            return result;
        }
    }

    public class Childs
    {
        public int ID;
        public int ChildID;

        public Childs(string csvLine, char div)
        {
            string[] parts = csvLine.Split(div);
            ID = Int32.Parse(parts[0]);
            ChildID = Int32.Parse(parts[1]);
        }

        public Childs(int id, int childid)
        {
            ID = id;
            ChildID = childid;
        }
    }

    //Класс "Человек" содержит данные о человеке
    public class Man
    {
        public int ID;
        public string Name;
        public string Family;
        public string PatName;
        public string Sex;
        public DateTime Birthday;
        public DateTime DeathDate;

        private static int MaxID;//Данная переменная ннеобходима для создания нового человека
        private bool isDead;

        //Создание класса при загрузке из БД
        public Man(int id, string name, string family, string patname, string sex, string birthday, string deathdate)
        {
            ID = id;
            if (MaxID < ID)
                MaxID = ID;
            Name = name;
            Family = family;
            PatName = patname;
            Sex = sex;
            DateTime.TryParseExact(birthday, "dd.MM.yyyy HHmmss", null, DateTimeStyles.AllowWhiteSpaces | DateTimeStyles.AdjustToUniversal, out Birthday);
            if (deathdate != null)
            {
                DateTime.TryParseExact(deathdate, "dd.MM.yyyy HHmmss", null, DateTimeStyles.AllowWhiteSpaces | DateTimeStyles.AdjustToUniversal, out DeathDate);
                isDead = true;
            }
            else
                isDead = false;
        }

        //Создание нового человека
        public Man(string name, string family, string patname, string sex, string birthday, string deathdate)
        {
            ID = MaxID;
            MaxID++;
            Name = name;
            Family = family;
            PatName = patname;
            Sex = sex;
            DateTime.TryParseExact(birthday, "dd.MM.yyyy HHmmss", null, DateTimeStyles.AllowWhiteSpaces | DateTimeStyles.AdjustToUniversal, out Birthday);
            if (deathdate != null)
            {
                DateTime.TryParseExact(deathdate, "dd.MM.yyyy HHmmss", null, DateTimeStyles.AllowWhiteSpaces | DateTimeStyles.AdjustToUniversal, out DeathDate);
                isDead = true;
            }
            else
                isDead = false;
        }

        public Man(string csvLine, char div)
        {
            string[] parts = csvLine.Split(div);
            ID = Int32.Parse(parts[0]);
            if (MaxID < ID)
                MaxID = ID;
            Name = parts[1];
            Family = parts[2];
            PatName = parts[3];
            Sex = parts[4];
            DateTime.TryParseExact(parts[5], "dd.MM.yyyy HHmmss", null, DateTimeStyles.AllowWhiteSpaces | DateTimeStyles.AdjustToUniversal, out Birthday);
            if (parts[6] != null)
            {
                DateTime.TryParseExact(parts[6], "dd.MM.yyyy HHmmss", null, DateTimeStyles.AllowWhiteSpaces | DateTimeStyles.AdjustToUniversal, out DeathDate);
                isDead = true;
            }
            else
                isDead = false;
        }
    }
}