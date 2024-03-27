using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldmapPresenter : PresenterBase
{
    #region Variable
    #endregion

    #region Public Method
    public void Initialize()
    {
        (uIPresenter as WorldmapUIPresenter).Initialize();
    }
    #endregion
}
