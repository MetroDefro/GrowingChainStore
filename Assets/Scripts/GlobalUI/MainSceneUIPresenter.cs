using Noru.Employee;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainSceneUIPresenter : MonoBehaviour
{
    #region Variable
    private MainSceneUIView view;
    public class MainSceneUIPresenterAction
    {
        public Action OnEmployeeCanvasButtonClick { get; set; }
        public Action OnArrangementCanvasButtonClick { get; set; }
        public Action OnWorldmapCanvasButtonClick { get; set; }
        public Action OnBrandCanvasButtonClick { get; set; }
        public Action OnOfferAppCanvasButtonClick { get; set; }
    }

    private MainSceneUIPresenterAction action;

    #endregion

    #region Life Cycle
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    #endregion

    #region Public Method
    public void Initialize(MainSceneUIPresenterAction action)
    {
        view = GetComponent<MainSceneUIView>();

        this.action = action;
        AddListners();
    }

    #endregion

    #region Private Method
    private void AddListners()
    {
        view.EmployeeCanvasButton.onClick.AddListener(() => action.OnEmployeeCanvasButtonClick.Invoke());
        view.ArrangementCanvasButton.onClick.AddListener(() => action.OnArrangementCanvasButtonClick.Invoke());
        view.WorldmapCanvasButton.onClick.AddListener(() => action.OnWorldmapCanvasButtonClick.Invoke());
        view.BrandCanvasButton.onClick.AddListener(() => action.OnBrandCanvasButtonClick.Invoke());
        view.OfferAppCanvasButton.onClick.AddListener(() => action.OnOfferAppCanvasButtonClick.Invoke());
    }
    #endregion
}
