using UnityEngine;

public class Portal : MonoBehaviour
{
    public SceneLoader sceneLoader; // 씬 로더 참조

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PotalWindow"))
        {
            sceneLoader.LoadScene();
        }
    }
}