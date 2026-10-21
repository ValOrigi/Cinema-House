using UnityEngine;

public class DoorInteract : MonoBehaviour, IInteractable
{
    [SerializeField] private string InteractText = "[F] to Enter";
    [SerializeField] private GameObject player;
    [SerializeField] private Transform location;

    public void Interact()
    {
        player.transform.position = location.position;
    }

    public string InteractionText {  get { return InteractText; } }
}
