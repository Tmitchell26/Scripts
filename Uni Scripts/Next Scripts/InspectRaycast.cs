using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Playables;

public class InspectRaycast : MonoBehaviour
{
    [SerializeField] private int rayLength = 2;
    [SerializeField] private LayerMask layerMaskInteract;
    private ObjectController raycastedObj;

    [SerializeField] private Image crosshair;
    private bool isCrosshairActive;
    private bool doOnce, doorOpen = false, fridgeDoorOpen = false;
    public bool isOpen, fridgeOpen;
    private bool canPlay = false;
    public PlayableDirector pourMilk;

    public GameObject door, fridgeDoor, milk, doorMilk, protagonistAnimator, canvas, winstonAnimator, fridgeLight, winston, justSomeMilk, yeaMilk, knockSounds;
    public AudioSource lightsFlicker, imSorryAria, hummingSound, glassBrokenSound, knock;
    private void Update()
    {
        RaycastHit hit;
        Vector3 fwd = transform.TransformDirection(Vector3.forward);

        if (Physics.Raycast(transform.position, fwd, out hit, rayLength, layerMaskInteract.value))
        {
            if (hit.collider.CompareTag("InteractObject"))
            {
                if (!doOnce)
                {
                    raycastedObj = hit.collider.gameObject.GetComponent<ObjectController>();
                    raycastedObj.ShowObjectName();
                    raycastedObj.ShowE();
                    CrosshairChange(true);
                }

                isCrosshairActive = true;
                doOnce = true;

                if (Input.GetKeyDown(KeyCode.E))
                {
                    raycastedObj.ShowExtraInfo();  
                }
            }

            if (hit.collider.CompareTag("Door"))
            {
                if (!doOnce)
                {
                    raycastedObj = hit.collider.gameObject.GetComponent<ObjectController>();
                    raycastedObj.ShowObjectName();
                    raycastedObj.ShowE();
                    CrosshairChange(true);
                }

                isCrosshairActive = true;
                doOnce = true;

                if (Input.GetKeyDown(KeyCode.E))
                {
                    door.GetComponent<Animator>().enabled = true;
                    isOpen = true;
                    doorOpen = true;
                    knock.Stop();
                    knockSounds.SetActive(false);
                    lightsFlicker.Play();
                    imSorryAria.Play();
                    hummingSound.Play();
                    StartCoroutine(SmashGlass());
                }

                if (doorOpen == true)
                {
                    raycastedObj.HideObjectName();
                    raycastedObj.HideE();
                    CrosshairChange(false);
                    doOnce = false;
                }

                IEnumerator SmashGlass()
                {
                    yield return new WaitForSeconds(5f);
                    glassBrokenSound.Play();
                }
            }

            if (hit.collider.CompareTag("FridgeDoor"))
            {
                if (!doOnce)
                {
                    raycastedObj = hit.collider.gameObject.GetComponent<ObjectController>();
                    raycastedObj.ShowObjectName();
                    //raycastedObj.ShowE();
                    CrosshairChange(true);
                }

                isCrosshairActive = true;
                doOnce = true;

                if (doorOpen == true)
                {
                    raycastedObj.ShowE();

                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        fridgeDoor.GetComponent<Animator>().enabled = true;
                        fridgeOpen = true;
                        fridgeDoorOpen = true;
                        fridgeLight.SetActive(true);
                        lightsFlicker.Play();
                        hummingSound.Play();
                    }

                    if (fridgeDoorOpen == true)
                    {
                        raycastedObj.HideObjectName();
                        raycastedObj.HideE();
                        CrosshairChange(false);
                        doOnce = false;
                    }
                }
                
            }

            if (hit.collider.CompareTag("Milk"))
            {
                if (!doOnce)
                {
                    raycastedObj = hit.collider.gameObject.GetComponent<ObjectController>();
                    raycastedObj.ShowObjectName();
                    raycastedObj.ShowE();
                    CrosshairChange(true);
                }

                isCrosshairActive = true;
                doOnce = true;

                if (Input.GetKeyDown(KeyCode.E))
                {
                    milk.SetActive(false);
                    Debug.Log("Picked Up Milk");
                    canPlay = true;
                }
            }

            if (hit.collider.CompareTag("Winston"))
            {
                if (!doOnce)
                {
                    raycastedObj = hit.collider.gameObject.GetComponent<ObjectController>();
                    raycastedObj.ShowObjectName();
                    //raycastedObj.ShowE();
                    CrosshairChange(true);
                }

                isCrosshairActive = true;
                doOnce = true;
                
                if (canPlay == true)
                {
                    raycastedObj.ShowE();

                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        pourMilk.Play();
                        canPlay = false;
                        Debug.Log("Pouring Milk");
                        
                        canvas.SetActive(false);
                        doorMilk.SetActive(true);
                        justSomeMilk.SetActive(false);
                        yeaMilk.SetActive(false);

                        protagonistAnimator.GetComponent<Animator>().Play("Idle", 0, 0f);
                        protagonistAnimator.GetComponent<Animator>().speed = 0f;
                        winstonAnimator.GetComponent<Animator>().Play("Asking fo milk", 0, 0f);
                        winstonAnimator.GetComponent<Animator>().speed = 0f;
                    }
                }
            }
        }
        else
        {
            if (isCrosshairActive)
            {
                raycastedObj.HideObjectName();
                raycastedObj.HideE();
                CrosshairChange(false);
                doOnce = false;
            }
        }
    }

    void CrosshairChange(bool  on)
    {
        if (on && !doOnce)
        {
            crosshair.color = Color.red;
        }
        else
        {
            crosshair.color = Color.white;
            isCrosshairActive = false;
        }
        
    }

}
