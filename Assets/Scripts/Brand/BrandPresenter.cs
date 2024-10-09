using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrandPresenter : PresenterBase
{
    #region Variable
    #endregion

    #region Public Method
    public void Initialize()
    {
        (uIPresenter as BrandUIPresenter).Initialize();
    }
    #endregion
}
