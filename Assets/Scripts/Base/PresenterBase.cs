using UnityEngine;

public abstract class PresenterBase : MonoBehaviour
{
    [SerializeField] protected UIPresenterBase uIPresenter;

    public void ShowOrHide()
    {
        if (!uIPresenter.gameObject.activeSelf)
            Show();
        else
            Hide();
    }

    public void Show()
    {
        uIPresenter.Show();
    }

    public void Hide()
    {
        uIPresenter.Hide();
    }
}
