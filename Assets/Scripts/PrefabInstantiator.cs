using UnityEngine;
using UnityEngine.SceneManagement;

public class PrefabInstantiator : MonoBehaviour
{
    public GameObject prefab; // 인스턴스화할 프리팹
    private GameObject instance;

    void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "MainScene") // 여기에 타겟 씬 이름 입력
        {
            if (instance == null && prefab != null)
            {
                instance = Instantiate(prefab, Vector3.zero, Quaternion.identity);
            }
        }
    }
}
