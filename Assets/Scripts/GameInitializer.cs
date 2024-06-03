using UnityEngine;
using UnityEngine.SceneManagement;

public class GameInitializer : MonoBehaviour
{
    public GameObject playerPrefab; // �ν��Ͻ�ȭ�� �÷��̾� ������

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
        if (scene.name == "GameScene") // ���� �� �̸� Ȯ��
        {
            Instantiate(playerPrefab, Vector3.zero, Quaternion.identity); // ������ �ν��Ͻ�ȭ
        }
    }
}
