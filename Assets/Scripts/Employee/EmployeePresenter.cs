using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Noru.Employee
{
    public class EmployeePresenter : MonoBehaviour
    {
        private List<Employee> employees;
        private EmployeeUIPresenter uIPresenter;

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
            // �ش� ��ũ �ִ뿡 �����ϸ� exp�� �� ������ �� ���Բ� �սô�.
            // ����ġ ������ ���� ���� �����ϱ�...
        }

        public void RankUp()
        {

        }

        public void LimitAdvance()
        {

            // uIPresenter.SetLimitAdvanceText();
        }

        public void AddEmployee()
        {

        }
    }

}
