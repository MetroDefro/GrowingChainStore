using TMPro;
using UnityEngine;

public class StoreUIView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI orderCountTMP;
    [SerializeField] private TextMeshProUGUI makingCountTMP;
    [SerializeField] private TextMeshProUGUI moneyTMP;

    public void SetOrderCountTMP(int count) => orderCountTMP.text = count.ToString();

    public void SetMakingCountTMP(int count) => makingCountTMP.text = count.ToString();

    public void SetMoneyTMP(int money) => moneyTMP.text = money.ToString();
}
