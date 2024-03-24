using manager;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class Property
{
    public BigInteger Money {get; set;}
    public int Fame {get; set;}
}

public class PropertyManager: MonoBehaviour
{
    #region Variable
    public static PropertyManager instance;

    public Property Property;
    #endregion

    #region Life Cycle

    private void Awake()
    {
        if (instance != null)
            Destroy(gameObject);
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        Property = new Property();
        Property.Money = 99999;
    }
    #endregion

}
