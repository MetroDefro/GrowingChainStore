using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OfferAppPresenter : PresenterBase
{
    #region Variable
    #endregion

    #region Public Method
    public void Initialize()
    {
        (uIPresenter as OfferAppUIPresenter).Initialize();
    }
    #endregion
}
