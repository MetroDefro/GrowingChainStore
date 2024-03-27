using Noru.Employee;
using System;
using UnityEngine;
using UnityEngine.UI;

public class StoreUIPresenter : MonoBehaviour
{
    #region Variable
    private StoreUIView view;
    private EmployeeListUIPresenter employeeListUI;

    private Action<int, Employee> onArrangement;
    #endregion

    #region Life Cycle
    private void Awake()
    {
        
    }
    #endregion

    #region Public Method
    public void Initialize(EmployeeListUIPresenter employeeListUI, Action<int, Employee> onArrangement)
    {
        view = GetComponent<StoreUIView>();

        this.employeeListUI = employeeListUI;
        this.onArrangement = onArrangement;
        AddListeners();
    }
  
    #endregion

    #region Private Method

    private void AddListeners()
    {
        view.OpenArrangementButton.onClick.AddListener(() =>
        {
            view.ShowArrangementPanel(true);
            view.SwitchButton(true);
        });
        view.CloseArrangementButton.onClick.AddListener(() =>
        {
            view.ShowArrangementPanel(false);
            view.SwitchButton(false);
        });

        int idx = 0;
        foreach (Button button in view.SlotButtons) 
        {
            button.onClick.AddListener(() => 
            {
                employeeListUI.SetEmployeeListUI((Employee employee) =>
                {
                    SetEmployee(button, employee, idx++);
                }).Show();
                
            });
        }
    }

    private void SetEmployee(Button button, Employee employee, int idx)
    {
        onArrangement.Invoke(idx, employee);

        button.image.sprite = employee.Character.ProfileSprite;
        employeeListUI.Hide();
        view.SetEmployeeSprite(idx, employee.Character.StandingSprite);
    }
    #endregion

}
