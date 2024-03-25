using Noru.Employee;
using UnityEngine;
using UnityEngine.UI;

public class StoreUIPresenter : MonoBehaviour
{
    #region Variable
    private StoreUIView view;
    private EmployeeListUIPresenter employeeListUI;
    #endregion

    #region Life Cycle
    private void Awake()
    {
        
    }
    #endregion

    #region Public Method
    public void Initialize(EmployeeListUIPresenter employeeListUI)
    {
        view = GetComponent<StoreUIView>();

        this.employeeListUI = employeeListUI;
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
        button.image.sprite = employee.Character.ProfileSprite;
        employeeListUI.Hide();
        view.SetEmployeeSprite(idx, employee.Character.StandingSprite);
    }
    #endregion

}
