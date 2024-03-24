using manager;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Noru.Employee
{
    public class EmployeeUIPresenter : MonoBehaviour
    {
        #region Variable
        private EmployeeUIView view;

        [SerializeField] private EmployeeButton employeeButton;

        private Action<Employee> onClickSararyButton;
        private Action<Employee> onClickRankUpButton;

        private List<EmployeeButton> employeeButtons;
        #endregion

        #region Life Cycle
        private void Awake()
        {
            view = GetComponent<EmployeeUIView>();
        }

        #endregion

        #region public Method
        public void Initialize(List<Employee> employees, Action<Employee> onClickSararyButton, Action<Employee> onClickRankUpButton)
        {
            view.Initialize();

            this.onClickSararyButton = onClickSararyButton;
            this.onClickRankUpButton = onClickRankUpButton;
            CreateEmployeeButtons(employees);

            AddListeners();
        }

        public void ResetEmployeeButtons(List<Employee> employees)
        {
            CreateEmployeeButtons(employees);
        }

        public void AddEmployeeButton(Employee employee)
        {
            CreateEmployeeButton(employee);
        }

        public void ShowLevelUpResultPanel(bool isShow, Employee employee)
        {
            view.SetLevelUpResultPanel(DataManager.instance.LevelToKorean(employee.Level) + " " + DataManager.instance.RankToKorean(employee.Rank)
                , employee.Character.Name, employee.Character.StandingSprite);
            view.ShowLevelUpResultPanel(isShow);

            SetSelectedEmployeePanel(employee);
        }
        public void ShowRankUpResultPanel(bool isShow, Employee employee)
        {
            view.SetLevelUpResultPanel(DataManager.instance.RankToKorean(employee.Rank).ToString(), employee.Character.Name, employee.Character.StandingSprite);
            view.ShowRankUpResultPanel(isShow);

            SetSelectedEmployeePanel(employee);
        }
        public void ShowFailPanel(bool isShow) => view.ShowFailPanel(isShow);

        #endregion

        #region private Method
        
        private void AddListeners()
        {
            view.BackButton.onClick.AddListener(() => view.ShowEmployeeUI(false));
        }

        private void AddSelectedEmployeePanelListeners(Employee employee)
        {
            view.SalaryButton.onClick.AddListener(() => onClickSararyButton(employee));
            view.RankUpButton.onClick.AddListener(() => onClickRankUpButton(employee));
            view.SelectedEmployeePanelBackButton.onClick.AddListener(() =>
            {
                RemoveSelectedEmployeePanelListeners();
                view.ShowSelectedEmployeePanel(false);
            });

            view.LevelUpResultPanelButton.onClick.AddListener(() => view.ShowLevelUpResultPanel(false));
            view.RankUpResultPanelButton.onClick.AddListener(() => view.ShowRankUpResultPanel(false));
        }

        private void RemoveSelectedEmployeePanelListeners()
        {
            view.SalaryButton.onClick.RemoveAllListeners();
            view.SelectedEmployeePanelBackButton.onClick.RemoveAllListeners();
        }

        private void CreateEmployeeButtons(List<Employee> employees)
        {
            employeeButtons = new List<EmployeeButton>();
            foreach (Employee employee in employees) 
            {
                CreateEmployeeButton(employee);
            }
        }

        private void CreateEmployeeButton(Employee employee)
        {
            employeeButtons.Add(Instantiate(employeeButton, view.EmployeeListParent)
                .SetEmployeeButton(employee, view.StarSprites[(int)employee.Character.Grade], (Employee employee) => 
                {
                    SetSelectedEmployeePanel(employee);
                    AddSelectedEmployeePanelListeners(employee);
                    view.ShowSelectedEmployeePanel(true);
                }));
        }

        private void SetSelectedEmployeePanel(Employee employee)
        {
            view.SetSelectedEmployeePanel(view.StarSprites[(int)employee.Character.Grade], employee.Character.ProfileSprite
                , DataManager.instance.LevelToKorean(employee.Level) + " " + DataManager.instance.RankToKorean(employee.Rank)
                , employee.Character.Name, ((int)employee.Limit).ToString(), employee.Character.Description
                , DataManager.instance.FindEXP(employee.Character.Grade, employee.Rank, employee.Level)
                );

            view.RankUpButton.gameObject.SetActive(false);
            view.SalaryButton.gameObject.SetActive(true);

            if (employee.Level == Level.master)
            {
                view.SalaryButton.gameObject.SetActive(false);
                switch (employee.Character.Grade)
                {
                    case Grade.star1:
                    case Grade.star2:
                        break;
                    case Grade.star3:
                        if(employee.Rank == Rank.employee)
                            view.RankUpButton.gameObject.SetActive(true);
                        break;
                    case Grade.star4:
                    case Grade.star5:
                    case Grade.star6:
                        if (employee.Rank == Rank.employee || employee.Rank == Rank.manager)
                            view.RankUpButton.gameObject.SetActive(true);
                        break;
                }
            }
        }
        #endregion
    }

}
