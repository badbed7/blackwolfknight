using UnityEngine;

public class Portal : MonoBehaviour
{
    public SceneLoader sceneLoader; // �� �δ� ����

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PotalWindow"))
        {
            sceneLoader.LoadScene();
        }
    }
}