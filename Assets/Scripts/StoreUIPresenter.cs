using UnityEngine;

public class StoreUIPresenter : MonoBehaviour
{
    StoreUIView view;

    private void Awake()
    {
        view = GetComponent<StoreUIView>();
    }

    public void SetOrderCountUI(int count) => view.SetOrderCountTMP(count);

    public void SetMakingCountUI(int count) => view.SetMakingCountTMP(count);

    public void SetMoneyUI(int money) => view.SetMoneyTMP(money);
}
