using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Noru.Employee
{
    public class EmployeeUIPresenter : MonoBehaviour
    {
        #region Variable
        private EmployeeUIView view;

        #endregion

        #region Life Cycle
        // Start is called before the first frame update
        private void Awake()
        {
            view = GetComponent<EmployeeUIView>();
        }

        #endregion

        #region public Method
        public void SetLimitAdvanceText(string text)
        {
            view.SetLimitAdvanceTMP(text);
        }

        #endregion

        #region private Method
        private void Initialize()
        {

        }

        #endregion
    }

}
