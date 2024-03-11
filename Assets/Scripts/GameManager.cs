using UnityEngine;

public class GameManager : MonoBehaviour
{
    private float time;
    private float respawnTime;
    private Store store;

    public static GameManager instance;

    public StoreUIPresenter StoreUIPresenter {  get => storeUIPresenter; }
    [SerializeField] private StoreUIPresenter storeUIPresenter;
    [SerializeField] private Store storePrefab;
    [SerializeField] private Employee employeePrefab;

    private void Awake()
    {
        if(instance != null)
            Destroy(gameObject);
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        store = Instantiate(storePrefab);
        store.Initialize(Instantiate(employeePrefab), Instantiate(employeePrefab), Instantiate(employeePrefab));
    }

    private void Update()
    {
        time += Time.deltaTime;
        respawnTime += Time.deltaTime;
        if (respawnTime > 1)
        {
            store.Order();
            respawnTime -= 1;
        }
    }
}
