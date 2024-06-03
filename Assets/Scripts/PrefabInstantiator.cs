using UnityEngine;
using UnityEngine.SceneManagement;

public class PrefabInstantiator : MonoBehaviour
{
    public GameObject prefab; // �ν��Ͻ�ȭ�� ������
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
        if (scene.name == "MainScene") // ���⿡ Ÿ�� �� �̸� �Է�
        {
            if (instance == null && prefab != null)
            {
                instance = Instantiate(prefab, Vector3.zero, Quaternion.identity);
            }
        }
    }
}
