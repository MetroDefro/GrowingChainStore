using manager;
using System.Collections.Generic;
using UnityEngine;

namespace Noru.Employee
{
    public class EmployeePresenter : PresenterBase
    {
        #region Property
        public List<Employee> Employees => employees;
        #endregion

        #region Variable
        private List<Employee> employees;

        #endregion

        #region Life Cycle
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
        #endregion

        #region Public Method
        public void Initialize(List<Employee> employees, EmployeeListUIPresenter employeeListUI)
        {
            this.employees = employees;
            (uIPresenter as EmployeeUIPresenter)
                .Initialize(employeeListUI, (Employee employee) => LevelUp(employee), (Employee employee) => RankUp(employee));
        }

        #endregion

        #region private Method

        private void LevelUp(Employee employee)
        {
            int needExp = DataManager.instance.FindEXP(employee.Character.Grade, employee.Rank, employee.Level);

            if(PropertyManager.instance.Property.Money >= needExp)
            {
                PropertyManager.instance.Property.Money -= needExp;
                employee.SetLevel(employee.Level + 1);
                (uIPresenter as EmployeeUIPresenter).ShowLevelUpResultPanel(true, employee);
            }
            else
            {
                (uIPresenter as EmployeeUIPresenter).ShowFailPanel(true);
            }
        }

        private void RankUp(Employee employee)
        {
            int needMoney = DataManager.instance.FindRankUpMoney(employee.Character.Grade, employee.Rank);

            if (PropertyManager.instance.Property.Money >= needMoney)
            {
                PropertyManager.instance.Property.Money -= needMoney;
                employee.SetRank(employee.Rank + 1);
                employee.SetLevel(Level.newcomer);
                (uIPresenter as EmployeeUIPresenter).ShowRankUpResultPanel(true, employee);
            }
            else
            {
                (uIPresenter as EmployeeUIPresenter).ShowFailPanel(true);
            }
        }

        private void LimitAdvance(Employee employee)
        {

            // uIPresenter.SetLimitAdvanceText();
        }

        private void AddEmployee(Employee employee)
        {

        }
        #endregion
    }

}
