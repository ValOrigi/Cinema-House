using JetBrains.Annotations;
using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class ButtonsUI : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] Animator TPUIAnimator;

    private bool isAnimating = false;
    private bool isOpen = false;
    Transform locationTransform;

    [Header ("Tutorial")]
    [SerializeField] GameObject PCTutorial;

    [SerializeField] GameObject[] MobileTutorial;

    [SerializeField] private GameObject locationTextall;
    [SerializeField] private CameraLook camerasc;

    [SerializeField] private GameObject blackPlane;
    private bool Flag;
    float activeTimer;
    float elapsedTime;


    public void TurnPCTutorialOff()
    {
        PCTutorial.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void TurnMobileTutorialOff()
    {
        foreach (GameObject mobiletut in MobileTutorial)
        {
            mobiletut.SetActive(false);
        }
    }

    public void InteractCinemaHouseButton(GameObject CinemaHouseCont)
    {
        if (!CinemaHouseCont.activeSelf)
        {
            CinemaHouseCont.SetActive(true);
        }
        else
            CinemaHouseCont.SetActive(false);
    }

    public void TeleportToLocation(DoorInteract doorInteract)
    {

        doorInteract.Interact();
    }


    public void ShowCurrentLocation()
    {
        activeTimer = 0f;
        elapsedTime = 0f;
        Flag = false;
    }

    public void Check(GameObject check)
    {
        if(!check.activeSelf)
        {
            check.SetActive(true);
        }
    }


/*    public void CursorToggle()
    {
        if(Cursor.visible == true)
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Confined;
        }
        else
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }*/
    
    public void InteractTP()
    {

        if (isAnimating) return;

        if (!isOpen)
        {
            StartCoroutine(InteractTPUI("TPSlideIn", true));
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            camerasc.enabled = false;
            blackPlane.SetActive(true);


        }
        else
        {
            StartCoroutine(InteractTPUI("TPSlideOut", false));
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Confined;
            camerasc.enabled = true;
            blackPlane.SetActive(false);

        }
        ;
    }


    private IEnumerator InteractTPUI(string AnimState, bool flag)
    {
        isAnimating = true;

        TPUIAnimator.Play(AnimState);

        yield return null;

        yield return new WaitForSeconds(TPUIAnimator.GetCurrentAnimatorStateInfo(0).length);

        isOpen = flag;
        isAnimating = false;

    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            if (PCTutorial.activeSelf)
            {
                PCTutorial.SetActive(false);
            }

        }
        if (Input.GetKey(KeyCode.Tab))
        {
            InteractTP();
        }

        if (!Flag)
        {
            locationTextall.GetComponent<CanvasGroup>().alpha = 1f;
            Debug.Log("animStarting");
            if (activeTimer < 3)
            {
                Debug.Log("animActive Countdown");
                activeTimer += Time.deltaTime;
            }
            else
            {
                Debug.Log("CountdownActive over going to fade");

                if (elapsedTime < 1)
                {
                    Debug.Log("Fading");
                    elapsedTime += Time.deltaTime;
                    locationTextall.GetComponent<CanvasGroup>().alpha = Mathf.Lerp(1, 0, elapsedTime / 1);
                }
                else
                {
                    locationTextall.GetComponent<CanvasGroup>().alpha = 0f;
                    Flag = true;
                }
                Debug.Log("Fading Stopped, Stopping whole anim");

            }
        }
    }

    private void Start()
    {
        Flag = false;
        ShowCurrentLocation();
    }

}
