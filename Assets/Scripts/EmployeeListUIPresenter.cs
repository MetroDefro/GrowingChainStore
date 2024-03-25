using Noru.Employee;
using System;
using System.Collections.Generic;
using UnityEngine;

public class EmployeeListUIPresenter : MonoBehaviour
{
    #region Property
    public Sprite[] StarSprites => view.StarSprites;
    #endregion

    #region Variable
    private EmployeeListUIView view;
    [SerializeField] private EmployeeButton employeeButtonPrefab;

    private Action<Employee> onClick;

    private List<EmployeeButton> employeeButtons;
    #endregion

    #region Public Method
    public void Initialize(List<Employee> employees)
    {
        view = gameObject.GetComponent<EmployeeListUIView>();
        CreateEmployeeButtons(employees);

        this.onClick = null;
        AddListeners();
    }

    public void Show()
    {
        view.Show(true);
    }
    public void Hide()
    {
        view.Show(false);
    }

    public EmployeeListUIPresenter SetEmployeeListUI(Action<Employee> onClick)
    {
        this.onClick = onClick;
        return this;
    }

    #endregion

    #region Private Method
    private void AddListeners()
    {
        view.BackButton.onClick.AddListener(() => view.Show(false));
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
        employeeButtons.Add(Instantiate(employeeButtonPrefab, view.EmployeeListParent)
            .SetEmployeeButton(employee, view.StarSprites[(int)employee.Character.Grade], (Employee employee) =>
            {
                onClick.Invoke(employee);
            }));
    }
    #endregion
}
