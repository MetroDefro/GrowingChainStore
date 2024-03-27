using manager;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Noru.Employee
{
    public class EmployeeUIPresenter : UIPresenterBase
    {
        #region Variable
        private EmployeeUIView view;
        private EmployeeListUIPresenter employeeListUI;

        private Action<Employee> onClickSararyButton;
        private Action<Employee> onClickRankUpButton;

        private List<EmployeeButton> employeeButtons;
        #endregion

        #region Life Cycle

        private void Dispose()
        {
            foreach (var employeeButton in employeeButtons) 
            {
                Destroy(employeeButton.gameObject);
            }
            employeeButtons.Clear();
        }
        #endregion

        #region public Method
        public void Initialize(EmployeeListUIPresenter employeeListUI, Action<Employee> onClickSararyButton, Action<Employee> onClickRankUpButton)
        {
            view = GetComponent<EmployeeUIView>();
            this.onClickSararyButton = onClickSararyButton;
            this.onClickRankUpButton = onClickRankUpButton;

            this.employeeListUI = employeeListUI;
            employeeListUI.SetEmployeeListUI((Employee employee) =>
            {
                SetSelectedEmployeePanel(employee);
                AddSelectedEmployeePanelListeners(employee);
                view.ShowSelectedEmployeePanel(true);
            });

            view.Initialize();
            Hide();
        }

        override public void Show()
        {
            view.Show();
            employeeListUI.Show();
        }

        override public void Hide()
        {
            view.Hide();
            employeeListUI.Hide();
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
            view.SetRankUpResultPanel(DataManager.instance.RankToKorean(employee.Rank).ToString(), employee.Character.Name, employee.Character.StandingSprite);
            view.ShowRankUpResultPanel(isShow);

            SetSelectedEmployeePanel(employee);
        }
        public void ShowFailPanel(bool isShow) => view.ShowFailPanel(isShow);

        #endregion

        #region private Method
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
            view.FailPanelSummitButton.onClick.AddListener(() => view.ShowFailPanel(false));
        }

        private void RemoveSelectedEmployeePanelListeners()
        {
            view.SalaryButton.onClick.RemoveAllListeners();
            view.SelectedEmployeePanelBackButton.onClick.RemoveAllListeners();
        }

        private void SetSelectedEmployeePanel(Employee employee)
        {
            view.SetSelectedEmployeePanel(employeeListUI.StarSprites[(int)employee.Character.Grade], employee.Character.ProfileSprite
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
