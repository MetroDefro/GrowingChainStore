using Noru.Employee;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StorePresenter : MonoBehaviour
{
    #region Variable
    [SerializeField] private StoreUIPresenter uIPresenter;
    private List<Store> stores;

    private Store store;
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
    public void Initialize(List<Store> stores, EmployeeListUIPresenter employeeListUI)
    {
        this.stores = stores;
        uIPresenter.Initialize(employeeListUI
            , (int idx, Employee employee) => SetEmployee(idx, employee));

        // test
        store = new Store(StoreSize.size30);
    }

    public void CreateStore()
    {

    }

    public void SetStore(Store store)
    {

    }

    public void SetEmployee(int idx, Employee employee)
    {
        store.SetEmployee(idx, employee);

        Debug.Log(store.Employees[idx].Character.Name);
    }

    #endregion
}
