using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[RequireComponent(typeof(ARPlaneManager))]
[RequireComponent(typeof(ARRaycastManager))]
public class PlaneOnIndicator : MonoBehaviour
{
    [SerializeField] GameObject placementIndicator;
    [SerializeField] GameObject placePrefab;
    [SerializeField] Vector3 positionOffset; // 사용자가 지정할 오프셋 값

    GameObject spawnedObject;
    ARRaycastManager aRRaycastManager;
    List<ARRaycastHit> hits = new List<ARRaycastHit>();

    void Awake()
    {
        aRRaycastManager = GetComponent<ARRaycastManager>();
        placementIndicator.SetActive(false);
    }

    void Update()
    {
        if (aRRaycastManager.Raycast(new Vector2(Screen.width / 2, Screen.height / 2), hits, TrackableType.PlaneWithinPolygon))
        {
            var hitpose = hits[0].pose;
            placementIndicator.transform.SetPositionAndRotation(hitpose.position, hitpose.rotation);
            if (!placementIndicator.activeInHierarchy)
            {
                placementIndicator.SetActive(true);
            }
        }
        else
        {
            if (placementIndicator.activeInHierarchy)
            {
                placementIndicator.SetActive(false);
            }
        }
    }

    public void PlaceObject()
    {
        if (!placementIndicator.activeInHierarchy)
            return;

        // 이전에 배치된 오브젝트가 있다면 제거
        if (spawnedObject != null)
        {
            Destroy(spawnedObject);
        }

        // 오브젝트를 배치할 위치를 오프셋 값을 적용하여 조정
        Vector3 adjustedPosition = placementIndicator.transform.position + positionOffset;

        // 새로운 오브젝트 배치
        spawnedObject = Instantiate(placePrefab, adjustedPosition, placePrefab.transform.rotation);
    }
}