using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MainSceneUIView : MonoBehaviour
{
    #region Property
    public Button EmployeeCanvasButton => employeeCanvasButton;
    public Button ArrangementCanvasButton => arrangementCanvasButton;
    public Button WorldmapCanvasButton => worldmapCanvasButton;
    public Button BrandCanvasButton => brandCanvasButton;
    public Button OfferAppCanvasButton => offerAppCanvasButton;

    #endregion

    #region Variable
    [SerializeField] private TextMeshProUGUI moneyTMP;
    [SerializeField] private TextMeshProUGUI fameTMP;
    [SerializeField] private Button employeeCanvasButton;
    [SerializeField] private Button arrangementCanvasButton;
    [SerializeField] private Button worldmapCanvasButton;
    [SerializeField] private Button brandCanvasButton;
    [SerializeField] private Button offerAppCanvasButton;
    #endregion

    #region Public Method
    public void SetMoneyTMP(BigInteger money) => moneyTMP.text = $"{money}¿ø";
    public void SetFameTMP(int fame) => fameTMP.text = fame.ToString();

    #endregion
}
