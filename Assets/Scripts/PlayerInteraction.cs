using TMPro;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] private float Range = 5f;
    [SerializeField] private LayerMask LayerMask;

    [SerializeField] private TMP_Text InteractionText;

    [SerializeField] private Camera mainCamera;

    private void Update()
    {
        HandleRaycasting();
    }

    private void HandleRaycasting()
    {
        RaycastHit hit;
        if (!Physics.Raycast(mainCamera.transform.position, mainCamera.transform.forward, out hit, Range, LayerMask))
        {
            InteractionText.text = "";
            return;
        }

        if (!hit.collider.TryGetComponent(out IInteractable interactable))
        {
            return;
        }

        InteractionText.text = interactable.InteractionText;
        if (Input.GetKeyDown(KeyCode.F))
            interactable.Interact();
    }
}
