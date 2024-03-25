using manager;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ConfigScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameManager.instance.Initialize();
        DataManager.instance.Initialize();

        SceneManager.LoadScene("MainScene");
    }

}
