using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Noru.Employee
{
    public class EmployeeUIView : MonoBehaviour
    {
        #region Property
        public Button SalaryButton => salaryButton;
        public Button RankUpButton => rankUpButton;
        public Button SelectedEmployeePanelBackButton => selectedEmployeePanelBackButton;
        public Button FailPanelSummitButton => failPanelSummitButton;
        public Button LevelUpResultPanelButton => levelUpResultPanel.GetComponent<Button>();
        public Button RankUpResultPanelButton => rankUpResultPanel.GetComponent<Button>();

        #endregion

        #region Variable
        [Header("Panel")]
        [SerializeField] private RectTransform selectedEmployeePanel;

        [Header("SelectedEmployeePanel")]
        [SerializeField] private Image starImage;
        [SerializeField] private Image profileImage;
        [SerializeField] private TextMeshProUGUI titleTMP;
        [SerializeField] private TextMeshProUGUI nameTMP;
        [SerializeField] private TextMeshProUGUI limitAdvanceTMP;
        [SerializeField] private TextMeshProUGUI nextEXPTMP;
        [SerializeField] private TextMeshProUGUI descriptionTMP;
        [SerializeField] private Button salaryButton;
        [SerializeField] private Button rankUpButton;
        [SerializeField] private Button selectedEmployeePanelBackButton;

        [Header("ResultPanel")]
        [SerializeField] private RectTransform levelUpResultPanel;
        [SerializeField] private RectTransform rankUpResultPanel;
        [SerializeField] private RectTransform failPanel;
        [SerializeField] private TextMeshProUGUI levelUpResultContentTMP;
        [SerializeField] private Image levelUpResultstandingImage;
        [SerializeField] private TextMeshProUGUI rankUpResultContentTMP;
        [SerializeField] private Image rankUpResultstandingImage;
        [SerializeField] private Button failPanelSummitButton;

        #endregion

        #region public method
        public void Initialize()
        {
            ShowEmployeeUI(true);
            ShowSelectedEmployeePanel(false);
            ShowLevelUpResultPanel(false);
            ShowRankUpResultPanel(false);
            ShowFailPanel(false);

        }

        public void ShowEmployeeUI(bool isShow) => gameObject.SetActive(isShow);

        public void ShowSelectedEmployeePanel(bool isShow) => selectedEmployeePanel.gameObject.SetActive(isShow);
        public void ShowLevelUpResultPanel(bool isShow) => levelUpResultPanel.gameObject.SetActive(isShow);
        public void ShowRankUpResultPanel(bool isShow) => rankUpResultPanel.gameObject.SetActive(isShow);
        public void ShowFailPanel(bool isShow) => failPanel.gameObject.SetActive(isShow);

        public void SetSelectedEmployeePanel(Sprite starSprite, Sprite profileSprite, string titleText
            , string nameText, string limitAdvanceText, string descriptionText, int maxEXP)
        {
            starImage.sprite = starSprite;
            profileImage.sprite = profileSprite;
            titleTMP.text = titleText;
            nameTMP.text = nameText;
            limitAdvanceTMP.text = limitAdvanceText;
            nextEXPTMP.text = maxEXP.ToString();
            descriptionTMP.text = descriptionText;
        }

        public void SetLevelUpResultPanel(string title, string name, Sprite standingSprite)
        {
            levelUpResultContentTMP.text = $"{name}은/는\n{title}로\n레벨 업 했다!";
            levelUpResultstandingImage.sprite = standingSprite;
        }
        public void SetRankUpResultPanel(string title, string name, Sprite standingSprite)
        {
            rankUpResultContentTMP.text = $"{name}은/는\n{title}로\n랭크 업 했다!";
            rankUpResultstandingImage.sprite = standingSprite;
        }

        public void SetStarImage(Sprite sprite) => starImage.sprite = sprite;
        public void SetProfileImage(Sprite sprite) => profileImage.sprite = sprite;
        public void SetTitleTMP(string text) => titleTMP.text = text;
        public void SetNameTMP(string text) => nameTMP.text = text;
        public void SetLimitAdvanceTMP(string text) => limitAdvanceTMP.text = text;
        public void SetNextEXPTMP(int curEXP, int maxEXP) => nextEXPTMP.text = (maxEXP - curEXP).ToString();
        public void SetDescriptionTMP(string text) => descriptionTMP.text = text;
        #endregion
    }

}
