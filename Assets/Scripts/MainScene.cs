using Noru.Employee;
using UnityEngine;

public class MainScene : MonoBehaviour
{
    private EmployeePresenter employeePresenter;

    private void Awake()
    {
        employeePresenter = GetComponent<EmployeePresenter>();
    }

    void Start()
    {
        employeePresenter.Initialize();
    }
}
