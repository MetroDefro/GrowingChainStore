using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using UnityEngine;

namespace manager
{
    public class DataManager : MonoBehaviour
    {
        public static DataManager instance;

        public List<EXP> EXPList;
        public List<InCome> InComeList;

        private void Awake()
        {
            if (instance != null)
                Destroy(gameObject);
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

        private void Start()
        {
            CSVparser csvparser = new CSVparser();
            EXPList = csvparser.ParseEXPTable(csvparser.CSVReader(Application.streamingAssetsPath + @"\exp_table.csv"));
            InComeList = csvparser.ParseInComeTable(csvparser.CSVReader(Application.streamingAssetsPath + @"\income_table.csv"));

            // test
            // Debug.Log(InComeList.Find(o => o.Rank == Rank.manager && o.Level == Level.expert).Star5);
        }
    }
}