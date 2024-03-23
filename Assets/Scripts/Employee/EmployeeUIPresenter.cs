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

        private Action<Employee, int> onClickSararyButton;

        private List<EmployeeButton> employeeButtons;
        #endregion

        #region Life Cycle
        private void Awake()
        {
            view = GetComponent<EmployeeUIView>();
        }

        #endregion

        #region public Method
        public void Initialize(List<Employee> employees, Action<Employee, int> onClickSararyButton)
        {
            view.Initialize();

            this.onClickSararyButton = onClickSararyButton;
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

        public void SetLimitAdvanceText(string text)
        {
            view.SetLimitAdvanceTMP(text);
        }

        #endregion

        #region private Method
        
        private void AddListeners()
        {
            view.BackButton.onClick.AddListener(() => view.ShowEmployeeUI(false));
        }

        private void AddSelectedEmployeePanelListeners(Employee employee)
        {
            view.SalaryButton.onClick.AddListener(() => view.ShowSalaryPaymentPanel(true));
            view.SelectedEmployeePanelBackButton.onClick.AddListener(() =>
            {
                RemoveSelectedEmployeePanelListeners();
                view.ShowSelectedEmployeePanel(false);
            });

            int mul = 10;
            foreach(Button button in view.PaymentButtons)
            {
                button.onClick.AddListener(() => onClickSararyButton(employee, mul));
                mul *= 10;
            }
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
            // EXP 부분은 따로 남은 EXP를 구하는 수식을 만들 예정.
            // 직원 성장 기능을 추가할 때 변경하겠음.
            view.SetSelectedEmployeePanel(view.StarSprites[(int)employee.Character.Grade], employee.Character.ProfileSprite, employee.Rank.ToString(), employee.Character.Name
                , ((int)employee.Limit).ToString(), (employee.EXP).ToString(), employee.Character.Description);
        }
        #endregion
    }

}
