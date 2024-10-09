using manager;
using Noru.Employee;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Menu
{
    employee,
    arrangement,
    brand,
    offerApp,
    worldmap
}

public class MainScenePresenter : MonoBehaviour
{
    #region Property
    private WorldmapPresenter worldmapPresenter;
    private StorePresenter storePresenter;

    private PresenterBase[] presenters = new PresenterBase[4];

    [SerializeField] private MainSceneUIPresenter uIPresenter;
    [SerializeField] private EmployeeListUIPresenter employeeListUIPresenterPrefab;
    #endregion

    #region Life Cycle

    private void Awake()
    {
        worldmapPresenter = GetComponent<WorldmapPresenter>();
        storePresenter = GetComponent<StorePresenter>();
        presenters[(int)Menu.employee] = GetComponent<EmployeePresenter>();
        presenters[(int)Menu.arrangement] = GetComponent<ArrangementPresenter>();
        presenters[(int)Menu.brand] = GetComponent<BrandPresenter>();
        presenters[(int)Menu.offerApp] = GetComponent<OfferAppPresenter>();
    }

    void Start()
    {

    }

    #endregion

    #region Public Method
    public void Initialize()
    {
        // test
        // 여기서 세이브 데이터를 불러올 예정이기 때문.
        List<Employee> employees = new List<Employee>();
        foreach (Character character in DataManager.instance.CharacterList)
        {
            employees.Add(new Employee(character));
        }
        List<Store> stores = new List<Store>();

        EmployeeListUIPresenter employeeListUIPresenter = Instantiate(employeeListUIPresenterPrefab);
        employeeListUIPresenter.Initialize(employees);
        worldmapPresenter.Initialize();
        storePresenter.Initialize(stores, employeeListUIPresenter);

        (presenters[(int)Menu.employee] as EmployeePresenter).Initialize(employees, employeeListUIPresenter);
        (presenters[(int)Menu.arrangement] as ArrangementPresenter).Initialize();
        (presenters[(int)Menu.brand] as BrandPresenter).Initialize();
        (presenters[(int)Menu.offerApp] as OfferAppPresenter).Initialize();

        uIPresenter.Initialize(new MainSceneUIPresenter.MainSceneUIPresenterAction
        {
            OnEmployeeCanvasButtonClick = () =>
            {
                (presenters[(int)Menu.employee] as EmployeePresenter).ShowOrHide();
                SetAction(Menu.employee);
            },
            OnArrangementCanvasButtonClick = () => 
            {
                (presenters[(int)Menu.arrangement] as ArrangementPresenter).ShowOrHide();
                SetAction(Menu.arrangement);
            },
            OnWorldmapCanvasButtonClick = () => 
            {
                SetAction(Menu.worldmap);
            },
            OnBrandCanvasButtonClick = () => 
            {
                (presenters[(int)Menu.brand] as BrandPresenter).ShowOrHide();
                SetAction(Menu.brand);
            },
            OnOfferAppCanvasButtonClick = () =>
            {
                (presenters[(int)Menu.offerApp] as OfferAppPresenter).ShowOrHide();
                SetAction(Menu.offerApp);
            }
        });

        void SetAction(Menu menu)
        {
            for (int i = 0; i < presenters.Length; i++)
            {
                if (i != (int)menu)
                    presenters[i].Hide();
            }
        }
    }
    #endregion
}
