using System.Collections.Generic;
using Noru.Employee;

public class Store
{
    #region Property
    public Employee[] Employees => employees;
    public StoreSize Size => size;
    #endregion

    #region Variable
    private Employee[] employees;
    private StoreSize size;
    #endregion

    #region Public Method
    public Store(StoreSize size)
    {
        employees = new Employee[3];
        this.size = size;
    }

    public void SetEmployee(int idx, Employee employee)
    {
        employees[idx] = employee;
    }

    public void SetSize(StoreSize size)
    {
        this.size = size;
    }
    #endregion
}