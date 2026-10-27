using Microsoft.Extensions.DependencyInjection;
using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class DoorInteract : MonoBehaviour, IInteractable
{
    [SerializeField] private string InteractText = "[F] to Enter";
    [SerializeField] private GameObject player;
    [SerializeField] private Transform location;
    [SerializeField] private GameObject check;
    [SerializeField] private string locationName;
    [SerializeField] private string subLocationName;
    [SerializeField] private TMP_Text locationTxt;
    [SerializeField] private TMP_Text subLocationTxt;


    [SerializeField] private ButtonsUI buttonsUIsc;
    public void Interact()
    {

        locationTxt.text = locationName;
        subLocationTxt.text = subLocationName;

        buttonsUIsc.ShowCurrentLocation();
        player.transform.position = location.position;

        if (!check.activeSelf)
        {
            check.SetActive(true);
        }
    }

    

    private void Start()
    {


    }

    private void Update()
    {
      
    }

    public string InteractionText {  get { return InteractText; } }
}
