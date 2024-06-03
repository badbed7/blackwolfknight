using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(ARPlaneManager))]
[RequireComponent(typeof(ARRaycastManager))]
public class ARPortal : MonoBehaviour
{
    [SerializeField] string portalSceneName; // 포탈 내부에 로드할 씬 이름
    [SerializeField] float moveSpeed = 0.1f; // 이동 속도

    ARRaycastManager raycastManager;
    GameObject portalInstance;
    GameObject characterInstance;
    List<ARRaycastHit> hits = new List<ARRaycastHit>();

    void Start()
    {
        raycastManager = GetComponent<ARRaycastManager>();
    }

    void Update()
    {
        if (raycastManager.Raycast(new Vector2(Screen.width / 2, Screen.height / 2), hits, TrackableType.PlaneWithinPolygon))
        {
            Pose hitPose = hits[0].pose;

            if (Keyboard.current.spaceKey.wasPressedThisFrame)
                PlacePortal(hitPose);
        }
    }

    void PlacePortal(Pose pose)
    {
        if (portalInstance != null)
            Destroy(portalInstance);

        LoadPortalScene();
    }

    void LoadPortalScene()
    {
        // 씬 로드 디버그 로그 추가
        Debug.Log("Loading scene: " + portalSceneName);

        SceneManager.LoadScene(portalSceneName, LoadSceneMode.Additive);

        // 씬 로드 확인을 위해 콜백 추가
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == portalSceneName)
        {
            Debug.Log("Scene " + portalSceneName + " loaded successfully.");
        }
    }
}