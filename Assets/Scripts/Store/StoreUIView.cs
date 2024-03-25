using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StoreUIView : MonoBehaviour
{
    #region Property
    public Button[] SlotButtons => slotButtons;
    public Button OpenArrangementButton => openArrangementButton;
    public Button CloseArrangementButton => closeArrangementButton;
    #endregion

    #region Variable
    [SerializeField] private RectTransform arrangementPanel;
    [SerializeField] private Button[] slotButtons;
    [SerializeField] private Button openArrangementButton;
    [SerializeField] private Button closeArrangementButton;
    [SerializeField] private Image[] employeeImages;
    #endregion

    #region Public Method
    public void ShowArrangementPanel(bool isShow)
    {
        arrangementPanel.gameObject.SetActive(isShow);
    }

    public void SwitchButton(bool isOpen)
    {
        OpenArrangementButton.gameObject.SetActive(!isOpen);
        closeArrangementButton.gameObject.SetActive(isOpen);
    }

    public void SetEmployeeSprite(int idx, Sprite sprite)
    {
        employeeImages[idx].sprite = sprite;
    }
    #endregion
}
