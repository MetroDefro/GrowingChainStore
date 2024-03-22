using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


namespace Noru.Employee
{
    public class EmployeeButton : MonoBehaviour
    {
        #region Property

        #endregion

        #region Variable
        [SerializeField] private Button button;
        [SerializeField] private Image profileImage;
        [SerializeField] private Image starImage;
        [SerializeField] private TextMeshProUGUI nameTMP;

        #endregion

        #region Public Method

        public EmployeeButton SetEmployeeButton(Employee employee, Sprite starSprite, Action<Employee> onClick) 
        {
            profileImage.sprite = employee.Character.ProfileSprite;
            nameTMP.text = employee.Character.Name;
            starImage.sprite = starSprite;

            button.onClick.AddListener(() => onClick.Invoke(employee));

            return this;
        }

        #endregion

        #region Private Method

        #endregion
    }

}

