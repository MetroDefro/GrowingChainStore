using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OfferAppUIPresenter : UIPresenterBase
{
    #region Variable
    private OfferAppUIView view;

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
        view = gameObject.GetComponent<OfferAppUIView>();

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
