using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using UnityEngine;

namespace manager
{
    public class DataManager : MonoBehaviour
    {
        #region Variable
        public static DataManager instance;

        public List<EXP> EXPList;
        public List<InCome> InComeList;
        public List<Character> CharacterList;
        public List<RankUpMoney> RankUpMoneyList;
        #endregion

        #region Life Cycle

        private void Awake()
        {
            if (instance != null)
                Destroy(gameObject);
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

        #endregion

        #region Public Method
        public void Initialize()
        {
            CSVparser csvparser = new CSVparser();
            EXPList = csvparser.ParseEXPTable(csvparser.CSVReader(Application.streamingAssetsPath + @"\exp_table.csv"));
            InComeList = csvparser.ParseInComeTable(csvparser.CSVReader(Application.streamingAssetsPath + @"\income_table.csv"));
            CharacterList = csvparser.ParseCharacterTable(csvparser.CSVReader(Application.streamingAssetsPath + @"\character_table.csv"));
            RankUpMoneyList = csvparser.ParseRankUpMoneyTable(csvparser.CSVReader(Application.streamingAssetsPath + @"\rankup_money_table.csv"));
        }

        public int FindEXP(Grade grade, Rank rank, Level level)
        {
            switch(grade)
            {
                case Grade.star1:
                    return EXPList.Find(o => o.Rank == rank && o.Level == level).Star1;
                case Grade.star2:
                    return EXPList.Find(o => o.Rank == rank && o.Level == level).Star2;
                case Grade.star3:
                    return EXPList.Find(o => o.Rank == rank && o.Level == level).Star3;
                case Grade.star4:
                    return EXPList.Find(o => o.Rank == rank && o.Level == level).Star4;
                case Grade.star5:
                    return EXPList.Find(o => o.Rank == rank && o.Level == level).Star5;
                case Grade.star6:
                    return EXPList.Find(o => o.Rank == rank && o.Level == level).Star6;
                default:
                    return 0;
            }
            
        }

        public float FindInCome(Grade grade, Rank rank, Level level)
        {
            switch (grade)
            {
                case Grade.star1:
                    return InComeList.Find(o => o.Rank == rank && o.Level == level).Star1;
                case Grade.star2:
                    return InComeList.Find(o => o.Rank == rank && o.Level == level).Star2;
                case Grade.star3:
                    return InComeList.Find(o => o.Rank == rank && o.Level == level).Star3;
                case Grade.star4:
                    return InComeList.Find(o => o.Rank == rank && o.Level == level).Star4;
                case Grade.star5:
                    return InComeList.Find(o => o.Rank == rank && o.Level == level).Star5;
                case Grade.star6:
                    return InComeList.Find(o => o.Rank == rank && o.Level == level).Star6;
                default:
                    return 0;
            }
        }
        public int FindRankUpMoney(Grade grade, Rank rank)
        {
            return RankUpMoneyList.Find(o => o.Grade == grade && o.Rank == rank).Money;
        }

        public Character FindCharacter(int id) 
        {
            return CharacterList.Find(o => o.ID == id);
        }

        public string RankToKorean(Rank rank)
        {
            switch (rank) 
            {
                case Rank.employee:
                    return "직원";
                case Rank.manager:
                    return "매니저";
                case Rank.owner:
                    return "점장";
                default:
                    return "정체불명";
            }
        }

        public string LevelToKorean(Level level)
        {
            switch (level)
            {
                case Level.newcomer:
                    return "신입";
                case Level.beginner:
                    return "초보";
                case Level.faithful:
                    return "성실한";
                case Level.expert:
                    return "숙련된";
                case Level.excellent:
                    return "우수한";
                case Level.elite:
                    return "엘리트";
                case Level.master:
                    return "마스터";
                default:
                    return "정체불명";
            }
        }
        #endregion
    }
}