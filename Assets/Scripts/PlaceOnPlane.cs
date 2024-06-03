using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.InputSystem;

[RequireComponent(typeof(ARRaycastManager))]
public class PlaceOnPlane : PressInputBase
{
    /// <summary>
    /// The prefab that will be instantiated on touch.
    /// </summary>
    /// 
    [SerializeField]
    [Tooltip("Instantiates this prefab on a plane at the touch location.")]
    GameObject RectPrefab;

    [SerializeField]
    [Tooltip("Instantiates this prefab on a plane at the touch location.")]
    GameObject placedPrefab;

    /// <summary>
    /// The instantiated object.
    /// </summary>
    GameObject spawnedObject;

   
    Vector3 lookPos;

    /// <summary>
    /// If there is any touch input.
    /// </summary>
    bool isPressed;

    ARRaycastManager aRRaycastManager;
    List<ARRaycastHit> hits = new List<ARRaycastHit>();
 


    protected override void Awake()
    {
        base.Awake();
        aRRaycastManager = GetComponent<ARRaycastManager>();
        
    }
    void Start()
    {
        Screen.SetResolution(790, 1280, true); // 원하는 해상도를 설정
        Camera.main.aspect = 9f / 16f; // 원하는 화면 비율을 설정
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 screenCenter = new Vector3(Screen.width / 2, Screen.height / 2);
        Ray ray = Camera.main.ScreenPointToRay(screenCenter);

        // Check if the raycast hit any trackables
        if (aRRaycastManager.Raycast(ray, hits, TrackableType.PlaneWithinPolygon))
        {
            var hitPose = hits[0].pose;

            // Set RectPrefab's position to the hit position
            RectPrefab.SetActive(true);
            RectPrefab.transform.position = hitPose.position;
        }

        if (spawnedObject != null)
        {
            RectPrefab.SetActive(false);
        }

    }
    public void spawnLevel()
    {
        if (spawnedObject == null)
        {
            spawnedObject = Instantiate(placedPrefab, RectPrefab.transform.position, placedPrefab.transform.rotation);
            //RectPrefab.SetActive(false);

        }
    }

   // protected override void OnPress(Vector3 position) => isPressed = true;

  //  protected override void OnPressCancel() => isPressed = false;
}
