using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractButton : MonoBehaviour
{
    public GameObject player;
    private PlayerTrigger trigger;
    private Button btn;

    private void Start()
    {
        btn = GetComponent<Button>();
        player = GameObject.FindWithTag("Player").gameObject;
        trigger = player.transform.GetComponent<PlayerTrigger>();
        btn.onClick.AddListener(trigger.Interact);
    }

    
}
