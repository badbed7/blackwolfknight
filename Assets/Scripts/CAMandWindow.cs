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
            // Window ������Ʈ�� ��ġ�� ī�޶��� ���� ���� �Ÿ��� �����մϴ�.
            Window.transform.position = Cam.transform.position + Cam.transform.forward * 10.0f;

            // Window ������Ʈ�� ȸ���� ī�޶� ���ϵ��� �����մϴ�.
            // -z ������ ī�޶� ���ϵ��� ȸ��
            Vector3 directionToCamera = Cam.transform.position - Window.transform.position;
            Quaternion targetRotation = Quaternion.LookRotation(-directionToCamera, Vector3.up);
            Window.transform.rotation = targetRotation;
        }
    }
}
