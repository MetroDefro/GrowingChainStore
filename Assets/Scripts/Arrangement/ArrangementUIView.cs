using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrangementUIView : MonoBehaviour
{
    #region Public Method
    public void Show() => gameObject.SetActive(true);
    public void Hide() => gameObject.SetActive(false);
    #endregion
}
