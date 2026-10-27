using TMPro;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] private float Range = 5f;
    [SerializeField] private LayerMask LayerMask;

    [SerializeField] private TMP_Text InteractionText;
    [SerializeField] private GameObject InteractUI;
    [SerializeField] private GameObject InteractUIMobile;


    [SerializeField] private Camera mainCamera;
    bool ButtonPressed = false;

    private void Update()
    {
        HandleRaycasting();
    }

    private void HandleRaycasting()
    {
        RaycastHit hit;
        if (!Physics.Raycast(mainCamera.transform.position, mainCamera.transform.forward, out hit, Range, LayerMask))
        {
            InteractUIMobile.SetActive(false);
            InteractUI.SetActive(false);
            return;
        }

        if (!hit.collider.TryGetComponent(out IInteractable interactable))
        {
            return;
        }

        if (!InteractUI.activeSelf)
        {
            InteractUIMobile.SetActive(true);
            InteractUI.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.F))
            interactable.Interact();

        if(ButtonPressed)
        {
            interactable.Interact();
            ButtonPressed = false;
        }
        
    }

    public void InteractButton()
    {
        ButtonPressed = true;
    }

}
