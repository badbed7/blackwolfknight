using UnityEngine;
using UnityEngine.SceneManagement;

public class GameInitializer : MonoBehaviour
{
    public GameObject playerPrefab; // 인스턴스화할 플레이어 프리팹

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
        if (scene.name == "GameScene") // 게임 씬 이름 확인
        {
            Instantiate(playerPrefab, Vector3.zero, Quaternion.identity); // 프리팹 인스턴스화
        }
    }
}
