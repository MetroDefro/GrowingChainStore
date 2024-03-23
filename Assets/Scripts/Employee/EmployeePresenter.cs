using manager;
using System.Collections.Generic;
using UnityEngine;

namespace Noru.Employee
{
    public class EmployeePresenter : MonoBehaviour
    {
        #region Variable
        private List<Employee> employees;
        [SerializeField] private EmployeeUIPresenter uIPresenter;

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
        public void Initialize()
        {
            employees = new List<Employee>();
            CreateEmployeesForTest();
            uIPresenter.Initialize(employees, (Employee employee, int exp) => Grow(employee, exp));
        }

        #endregion

        #region private Method
        private void CreateEmployeesForTest()
        {
            foreach (Character character in DataManager.instance.CharacterList)
            {
                employees.Add(new Employee(character));
            }
        }

        private void Grow(Employee employee, int exp)
        {
            // �ش� ��ũ �ִ뿡 �����ϸ� exp�� �� ������ �� ���Բ� �սô�.
            
            // while()
        }

        private void RankUp(Employee employee)
        {

        }

        private void LimitAdvance(Employee employee)
        {

            // uIPresenter.SetLimitAdvanceText();
        }

        private void AddEmployee(Employee employee)
        {

        }
        #endregion
    }

}
