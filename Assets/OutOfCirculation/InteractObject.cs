using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractObject : BaseInteractiveObject
{
    public enum ItemStates { Grabbable, Lookable, Dialogue, Door}

    public Item item;
    public ItemStates states;

    public DialogueHandler DialogueHandler;
    public NavMeshAgentController player;

    public int TargetSceneIndex;
    public int TargetSpawnPointIndex;

    public string FlagName => name + "_Collected";

    protected override void Awake()
    {
        if(states == ItemStates.Grabbable)
        {
            base.Awake();

            if (GameStateManager.Instance.Contains(FlagName))
            {
                gameObject.SetActive(false);
            }
        }
    }

    public override string GetName()
    {
        return item.Name;
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            player = other.transform.gameObject.GetComponent<NavMeshAgentController>();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player = null;
        }
    }

    public void ItemInteract()
    {
        if(player == null)
        {
            return;
        }

        if(states == ItemStates.Lookable)
        {

            base.Interact(player);

            ControlManager.SwitchToUI();
            UIItemInfoPopup.Instance.Show(item, () =>
            {
                ControlManager.SwitchToGameplay();
            });
        }
        else if(states == ItemStates.Grabbable)
        {
            if (!gameObject.activeSelf)
                return;

            var inv = player.GetComponentInChildren<Inventory>();
            inv.AddItem(item);

            GameStateManager.Instance.SetValue(FlagName, true);

            gameObject.SetActive(false);
        }
        else if(states == ItemStates.Dialogue)
        {
            if(DialogueHandler != null)
            {
                DialogueHandler.StartDialogue();
            }
        }
        else if(states == ItemStates.Door)
        {
            base.Interact(player);
            SpawnSystem.LoadInScene(TargetSceneIndex, TargetSpawnPointIndex);
        }
    }
}
