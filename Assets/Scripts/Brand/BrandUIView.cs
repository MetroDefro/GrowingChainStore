using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrandUIView : MonoBehaviour
{
    #region Public Method
    public void Show() => gameObject.SetActive(true);
    public void Hide() => gameObject.SetActive(false);
    #endregion
}
