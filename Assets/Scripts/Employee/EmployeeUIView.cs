using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Noru.Employee
{
    public class EmployeeUIView : MonoBehaviour
    {
        #region Property
        public Button BackButton => backButton;
        public RectTransform EmployeeListParent => employeeListParent;
        public RectTransform ExpGauge => expGauge;
        public Button SalaryButton => salaryButton;

        #endregion

        #region Variable
        [Header("Panels")]
        [SerializeField] private RectTransform topPnael;
        [SerializeField] private RectTransform middlePanel;
        [SerializeField] private RectTransform selectedEmployeePanel;

        [Header("TopPanel")]
        [SerializeField] private Button backButton;

        [Header("MiddlePanel")]
        [SerializeField] private RectTransform employeeListParent;

        [Header("SelectedEmployeePanel")]
        [SerializeField] private Image starImage;
        [SerializeField] private Image profileImage;
        [SerializeField] private TextMeshProUGUI titleTMP;
        [SerializeField] private TextMeshProUGUI nameTMP;
        [SerializeField] private TextMeshProUGUI limitAdvanceTMP;
        [SerializeField] private TextMeshProUGUI nextEXPTMP;
        [SerializeField] private TextMeshProUGUI descriptionTMP;
        [SerializeField] private RectTransform expGauge;
        [SerializeField] private Button salaryButton;

        #endregion

        #region public method
        public void ShowSelectedEmployeePanel(bool isShow) => selectedEmployeePanel.gameObject.SetActive(isShow);

        public void SetStarImage(Sprite sprite) => starImage.sprite = sprite;
        public void SetProfileImage(Sprite sprite) => profileImage.sprite = sprite;

        public void SetTitleTMP(string text) => titleTMP.text = text;
        public void SetNameTMP(string text) => nameTMP.text = text;
        public void SetLimitAdvanceTMP(string text) => limitAdvanceTMP.text = text;
        public void SetNextEXPTMP(string text) => nextEXPTMP.text = text;
        public void SetDescriptionTMP(string text) => descriptionTMP.text = text;

        #endregion
    }

}
