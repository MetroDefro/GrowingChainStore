
using UnityEngine;

public struct EXP
{
    public Rank Rank;
    public Level Level;
    public int Star1;
    public int Star2;
    public int Star3;
    public int Star4;
    public int Star5;
    public int Star6;

    public EXP(Rank Rank, Level Level, int Star1, int Star2, int Star3, int Star4, int Star5, int Star6)
    {
        this.Rank = Rank;
        this.Level = Level;
        this.Star1 = Star1;
        this.Star2 = Star2;
        this.Star3 = Star3;
        this.Star4 = Star4;
        this.Star5 = Star5;
        this.Star6 = Star6;
    }
}

public struct InCome
{
    public Rank Rank;
    public Level Level;
    public float Star1;
    public float Star2;
    public float Star3;
    public float Star4;
    public float Star5;
    public float Star6;

    public InCome(Rank Rank, Level Level, float Star1, float Star2, float Star3, float Star4, float Star5, float Star6)
    {
        this.Rank = Rank;
        this.Level = Level;
        this.Star1 = Star1;
        this.Star2 = Star2;
        this.Star3 = Star3;
        this.Star4 = Star4;
        this.Star5 = Star5;
        this.Star6 = Star6;
    }
}
public struct RankUpMoney
{
    public Rank Rank;
    public Grade Grade;
    public int Money; 

    public RankUpMoney(Rank Rank, Grade Grade, int Money)
    {
        this.Rank = Rank;
        this.Grade = Grade;
        this.Money = Money;
    }
}

public struct Character
{
    public string Name;
    public Sprite ProfileSprite;
    public Sprite StandingSprite;
    public Grade Grade;
    public string Description;
    public int ID;

    public Character(string Name, Sprite ProfileSprite, Sprite StandingSprite, Grade Grade, string Description, int ID)
    {
        this.Name = Name;
        this.ProfileSprite = ProfileSprite;
        this.StandingSprite = StandingSprite;
        this.Grade = Grade;
        this.Description = Description;
        this.ID = ID;
    }
}