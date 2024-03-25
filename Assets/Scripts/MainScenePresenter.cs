using manager;
using Noru.Employee;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainScenePresenter : MonoBehaviour
{
    #region Property
    private EmployeePresenter employeePresenter;
    private StorePresenter storePresenter;

    [SerializeField] private EmployeeListUIPresenter employeeListUIPresenterPrefab;
    #endregion

    #region Life Cycle

    private void Awake()
    {
        employeePresenter = GetComponent<EmployeePresenter>();
        storePresenter = GetComponent<StorePresenter>();
    }

    void Start()
    {

    }

    #endregion

    #region Public Method
    public void Initialize()
    {
        // test
        // 여기서 세이브 데이터를 불러올 예정이기 때문.
        List<Employee> employees = new List<Employee>();
        foreach (Character character in DataManager.instance.CharacterList)
        {
            employees.Add(new Employee(character));
        }

        EmployeeListUIPresenter employeeListUIPresenter = Instantiate(employeeListUIPresenterPrefab);
        employeeListUIPresenter.Initialize(employees);
        employeePresenter.Initialize(employees, employeeListUIPresenter);
        storePresenter.Initialize(employeeListUIPresenter);
        
    }
    #endregion
}
