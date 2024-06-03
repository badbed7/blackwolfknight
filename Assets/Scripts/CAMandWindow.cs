using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CAMandWindow : MonoBehaviour
{
    GameObject Cam;
    GameObject Window;

    void Start()
    {
        Cam = GameObject.FindWithTag("MainCamera");
    }

    // Update is called once per frame
    void Update()
    {

        Window = GameObject.FindWithTag("Window");

        if (Window != null)
        {
            // Window 오브젝트의 위치를 카메라의 앞쪽 일정 거리로 설정합니다.
            Window.transform.position = Cam.transform.position + Cam.transform.forward * 10.0f;

            // Window 오브젝트의 회전을 카메라를 향하도록 설정합니다.
            // -z 방향이 카메라를 향하도록 회전
            Vector3 directionToCamera = Cam.transform.position - Window.transform.position;
            Quaternion targetRotation = Quaternion.LookRotation(-directionToCamera, Vector3.up);
            Window.transform.rotation = targetRotation;
        }
    }
}
