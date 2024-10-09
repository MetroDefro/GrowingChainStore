using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrangementUIPresenter : UIPresenterBase
{
    #region Variable
    private ArrangementUIView view;

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
    public void Initialize()
    {
        view = gameObject.GetComponent<ArrangementUIView>();

        Hide();
    }

    override public void Show()
    {
        view.Show();
    }

    override public void Hide()
    {
        view.Hide();
    }

    #endregion
}
