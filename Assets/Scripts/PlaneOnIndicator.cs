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
    [SerializeField] Vector3 positionOffset; // ����ڰ� ������ ������ ��

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

        // ������ ��ġ�� ������Ʈ�� �ִٸ� ����
        if (spawnedObject != null)
        {
            Destroy(spawnedObject);
        }

        // ������Ʈ�� ��ġ�� ��ġ�� ������ ���� �����Ͽ� ����
        Vector3 adjustedPosition = placementIndicator.transform.position + positionOffset;

        // ���ο� ������Ʈ ��ġ
        spawnedObject = Instantiate(placePrefab, adjustedPosition, placePrefab.transform.rotation);
    }
}