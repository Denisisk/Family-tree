using System;

/*Класс "Отношение" определяет отношение между двумя людьми:
 * 1.Время совместной жизни
 * 2.ID Детей*/
public class Relation
{
    public int ID { get; set; }
    public int YEAR1 { get; set; }
    public int YEAR2 { get; set; }
    public List<int> Childs { get; set; }
    public static int MaxID { get; set; }//Данная переменная ннеобходима для создания новой связи

    public Relation(int id, int year1, int year2)
	{
        ID = id;
        if (MaxID < ID)
            MaxID = ID;
        YEAR1 = year1;
        YEAR2 = year2;
        Childs = new List<int>();
    }

    void AddChild(int CID)
    {
        Childs.add(CID);
    }
}

//Класс "Человек" содержит данные о человеке
public class Man
{
    public int ID { get; set; }
    public string Name { get; set; }
    public string Family { get; set; }
    public string PatName { get; set; }
    public string Sex { get; set; }
    public DateTime Birthday { get; set; }
    public DateTime DeathDate { get; set; }
    public List<int> Relations { get; set; }
    private static int MaxID { get; set; }//Данная переменная ннеобходима для создания нового человека

    //Создание класса при загрузке из БД
    public Man(int id, string name, string family, string patname, string sex,string birthday, string deathdate)
    {
        ID = id;
        if (MaxID < ID)
            MaxID = ID;
        Name = name;
        Family = family;
        PatName = patname;
        Sex = sex;
        Relations = new List<int>();
        DateTime.TryParseExact(birthday, "dd.MM.yyyy HHmmss", null, DateTimeStyles.AllowWhiteSpaces | DateTimeStyles.AdjustToUniversal, out Birthday);
        if (deathdate != null)
            DateTime.TryParseExact(deathdate, "dd.MM.yyyy HHmmss", null, DateTimeStyles.AllowWhiteSpaces | DateTimeStyles.AdjustToUniversal, out DeathDate);
        else
            DeathDate = null;
    }

    //Создание нового человека
    public Man(string name, string family, string patname, string sex, string birthday)
    {
        ID = MaxID;
        MaxID++;
        Name = name;
        Family = family;
        PatName = patname;
        Sex = sex;
        Relations = new List<int>();
        DateTime.TryParseExact(birthday, "dd.MM.yyyy HHmmss", null, DateTimeStyles.AllowWhiteSpaces | DateTimeStyles.AdjustToUniversal, out Birthday);
        if (deathdate != null)
            DateTime.TryParseExact(deathdate, "dd.MM.yyyy HHmmss", null, DateTimeStyles.AllowWhiteSpaces | DateTimeStyles.AdjustToUniversal, out DeathDate);
        else
            DeathDate = null;
    }

    //Добавление отношений из БД
    void AddRelation(int ID, int year1, int year2)
    {
        Relations.add(new Relation(ID, year1, year2));
    }
}

//Создание нового связи между людьми
void AddNewRelation(Man Man1, Man Man2, int year1, int year2)
{
    int ID = Man.MaxID + 1;
    Man1.AddRelation(ID, year1, year2);
    Man2.AddRelation(ID, year1, year2);
}
