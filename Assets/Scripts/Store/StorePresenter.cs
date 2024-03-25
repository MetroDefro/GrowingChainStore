using Noru.Employee;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StorePresenter : MonoBehaviour
{
    #region Variable
    [SerializeField] private StoreUIPresenter uIPresenter;
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
    public void Initialize(EmployeeListUIPresenter employeeListUI)
    {
        uIPresenter.Initialize(employeeListUI);
    }

    #endregion
}
