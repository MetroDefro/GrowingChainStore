using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using UnityEngine;

public class CSVparser
{
    public DataTable CSVReader(string path)
    {
        DataTable table = new DataTable();

        StreamReader sr = new StreamReader(path);
        string[] headers = sr.ReadLine().Split(',');
        foreach (string line in headers)
        {
            table.Columns.Add(line);
        }

        while (!sr.EndOfStream)
        {
            string line = sr.ReadLine();
            string[] data = line.Split(',');

            DataRow row = table.NewRow();
            for (int i = 0; i < headers.Length; i++)
            {
                row[i] = data[i];
            }

            table.Rows.Add(row);
        }

        return table;
    }

    public List<EXP> ParseEXPTable(DataTable table)
    {
        List<EXP> result = new List<EXP>();

        foreach(DataRow row in table.Rows) 
        {
            Rank rank = (Rank)Enum.Parse(typeof(Rank), row["Rank"].ToString());
            Level level = (Level)Enum.Parse(typeof(Level), row["Level"].ToString());

            int star1 = int.Parse(row["Star1"].ToString());
            int star2 = int.Parse(row["Star2"].ToString());
            int star3 = int.Parse(row["Star3"].ToString());
            int star4 = int.Parse(row["Star4"].ToString());
            int star5 = int.Parse(row["Star5"].ToString());
            int star6 = int.Parse(row["Star6"].ToString());

            EXP exp = new EXP(rank, level, star1, star2, star3, star4, star5, star6);
            result.Add(exp);
        }

        return result;
    }

    public List<InCome> ParseInComeTable(DataTable table)
    {
        List<InCome> result = new List<InCome>();

        foreach (DataRow row in table.Rows)
        {
            Rank rank = (Rank)Enum.Parse(typeof(Rank), row["Rank"].ToString());
            Level level = (Level)Enum.Parse(typeof(Level), row["Level"].ToString());

            float star1 = float.Parse(row["Star1"].ToString());
            float star2 = float.Parse(row["Star2"].ToString());
            float star3 = float.Parse(row["Star3"].ToString());
            float star4 = float.Parse(row["Star4"].ToString());
            float star5 = float.Parse(row["Star5"].ToString());
            float star6 = float.Parse(row["Star6"].ToString());

            InCome inCome = new InCome(rank, level, star1, star2, star3, star4, star5, star6);
            result.Add(inCome);
        }

        return result;
    }
    public List<RankUpMoney> ParseRankUpMoneyTable(DataTable table)
    {
        List<RankUpMoney> result = new List<RankUpMoney>();

        foreach (DataRow row in table.Rows)
        {
            Rank rank = (Rank)Enum.Parse(typeof(Rank), row["Rank"].ToString());
            Grade grade = (Grade)Enum.Parse(typeof(Grade), row["Grade"].ToString());
            int money = int.Parse(row["Money"].ToString());
            
            RankUpMoney rankupMoney = new RankUpMoney(rank, grade, money);
            result.Add(rankupMoney);
        }

        return result;
    }

    public List<Character> ParseCharacterTable(DataTable table)
    {
        List<Character> result = new List<Character>();

        foreach (DataRow row in table.Rows)
        {
            string name = row["Name"].ToString();
            Sprite profileSprite = Resources.Load<Sprite>(row["ProfileSprite"].ToString());
            Sprite standingSprite = Resources.Load<Sprite>(row["StandingSprite"].ToString());
            Grade grade = (Grade)Enum.Parse(typeof(Grade), row["Grade"].ToString());
            string description = row["Description"].ToString();
            int id = int.Parse(row["ID"].ToString());

            Character character = new Character(name, profileSprite, standingSprite, grade, description, id);
            result.Add(character);
        }

        return result;
    }
}
