using UnityEngine;
using UnityEngine.UI;

public class EmployeeListUIView : MonoBehaviour
{
    #region Property
    public Button BackButton => backButton;
    public RectTransform EmployeeListParent => employeeListParent;
    public Sprite[] StarSprites => starSprites;

    #endregion

    #region Variable
    [SerializeField] private RectTransform topPnael;
    [SerializeField] private RectTransform middlePanel;
    [SerializeField] private RectTransform employeeListParent;
    [SerializeField] private Button backButton;
    [SerializeField] private Sprite[] starSprites;

    #endregion

    #region Public Method
    public void Show(bool isShow) => gameObject.SetActive(isShow);
    #endregion
}
