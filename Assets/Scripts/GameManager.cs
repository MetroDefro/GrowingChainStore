using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;


    private void Awake()
    {
        if(instance != null)
            Destroy(gameObject);
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {

    }

    private void Update()
    {

    }
}
