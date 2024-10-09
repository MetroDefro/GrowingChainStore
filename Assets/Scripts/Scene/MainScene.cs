using Noru.Employee;
using UnityEngine;

public class MainScene : MonoBehaviour
{
    private MainScenePresenter presenter;

    private void Awake()
    {
        presenter = GetComponent<MainScenePresenter>();
    }

    void Start()
    {
        presenter.Initialize();
    }
}
