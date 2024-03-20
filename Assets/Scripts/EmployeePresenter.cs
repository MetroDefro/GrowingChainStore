using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmployeePresenter : MonoBehaviour
{
    private List<Employee> employees;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Initialize() 
    {
        employees = new List<Employee>();
    }

    public void Grow()
    {
        // 해당 랭크 최대에 도달하면 exp를 더 투자할 수 없게끔 합시다.
        // 경험치 구간에 따른 레벨 적용하기...
    }

    public void RankUp() 
    {

    }

    public void LimitAdvance() 
    {

    }

    public void AddEmployee() 
    {

    }
}
