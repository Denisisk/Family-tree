using System;
using System.Globalization;
using System.Collections.Generic;

namespace Objects
{
    /*Класс "Отношение" определяет отношение между двумя людьми:
     * 1.Время совместной жизни
     * 2.ID Детей*/
    public class Relation
    {
        public int ID;
        public int YEAR1;
        public int YEAR2;
        public List<int> Childs;
        public static int MaxID;//Данная переменная ннеобходима для создания новой связи

        public Relation(int id, int year1, int year2)
        {
            ID = id;
            if (MaxID < ID)
                MaxID = ID;
            YEAR1 = year1;
            YEAR2 = year2;
            Childs = new List<int>();
        }

        public void AddChild(int CID)
        {
            Childs.Add(CID);
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
        public List<Relation> Relations;

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
            Relations = new List<Relation>();
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
            Relations = new List<Relation>();
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
            Relations = new List<Relation>();
            DateTime.TryParseExact(parts[5], "dd.MM.yyyy HHmmss", null, DateTimeStyles.AllowWhiteSpaces | DateTimeStyles.AdjustToUniversal, out Birthday);
            if (parts[6] != null)
            {
                DateTime.TryParseExact(parts[6], "dd.MM.yyyy HHmmss", null, DateTimeStyles.AllowWhiteSpaces | DateTimeStyles.AdjustToUniversal, out DeathDate);
                isDead = true;
            }
            else
                isDead = false;
        }

        //Добавление отношений из БД
        void AddRelation(int ID, int year1, int year2)
        {
            Relations.Add(new Relation(ID, year1, year2));
        }
        //Создание нового связи между людьми
        static public void AddNewRelation(Man Man1, Man Man2, int year1, int year2)
        {
            int ID = Man.MaxID + 1;
            Man1.AddRelation(ID, year1, year2);
            Man2.AddRelation(ID, year1, year2);
        }
    }
}