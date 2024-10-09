using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrangementPresenter : PresenterBase
{
    #region Variable
    #endregion

    #region Public Method
    public void Initialize()
    {
        (uIPresenter as ArrangementUIPresenter).Initialize();
    }

    #endregion
}
