
using System.Text;

public class Character
{
    public int Strength { get; set; }     //хар-ки
    public int Agility { get; set; }
    public int Intelligence { get; set; }

    public override string ToString()
    {
        return $"Персонаж: Сила={Strength},Спритність={Agility}, Інтелект={Intelligence}";
    }
}

public class CharacterBuilder
{
    private Character _character = new Character(); //створюємо перса покроково

    public CharacterBuilder SetStrength(int strength)
    {
        _character.Strength = strength;
        return this;
    }

    public CharacterBuilder SetAgility(int agility)
    {
        _character.Agility = agility;
        return this;
    }

    public CharacterBuilder SetIntelligence(int intelligence)
    {
        _character.Intelligence = intelligence;
        return this;
    }

    public Character Build()         //повертаємо готовий результат
    {
        return _character;
    }
}

public class SqlQuery
{
    private StringBuilder _query = new StringBuilder();

    public SqlQuery Select(string columns)          //створюємо запит покроково
    {
        _query.Append($"SELECT {columns} ");
        return this;
    }

    public SqlQuery From(string table)
    {
        _query.Append($"FROM {table} ");
        return this;
    }

    public SqlQuery Where(string condition)
    {
        _query.Append($"WHERE {condition} ");
        return this;
    }

    public SqlQuery OrderBy(string order)
    {
        _query.Append($"ORDER BY {order} ");
        return this;
    }

    public string Build()                       //результат запиту
    {
        return _query.ToString().Trim();
    }
}
public class Program
{
    static void Main(string[] args)
    {
        Character character = new CharacterBuilder() //створюємо перса через білдер
            .SetStrength(15)
            .SetAgility(10)
            .SetIntelligence(20)
            .Build();
        Console.WriteLine(character);

        string sqlQuery = new SqlQuery()               //створюємо запит
            .Select("id, name")
            .From("users")
            .Where("age > 18")
            .OrderBy("name ASC")
            .Build();
        Console.WriteLine(sqlQuery);

        Console.ReadLine();
    }
}