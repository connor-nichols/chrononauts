using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Valve.VR;

/*
 * Some notes:
 * The time gun will send out a raycast to see if any objects that are "eligible" are being hit.
 * 
 * Depending on the mode the gun is in, and if the trigger is pressed, gun will instruct the parent object/do it itself(?) to deactivate the current object, do some animation, then move to the next object
 * 
 *TODO: read into raycasts, decide upon whether the object does it, or does the gun do it? Also check docs to see what other features the gun needs to have
 * 
 * 
 */
public class TimeGun : MonoBehaviour
{
    // Start is called before the first frame update
    public int modeDebug = 1;
    public static int mode = 1; //1 is forward, 2 back
    public bool isFiring;

    public Text leftText;
    public Text rightText;
    public Text centerText;
    public int direction;

    private TimeGunEligible manager;

    public SteamVR_Action_Boolean FireGun = SteamVR_Input.GetBooleanAction("Fire");
    void Start()
    {
    }

    // Update is called once per frame
    //note on attachment: when gun is attached to hand, keep attached, when dropped, go back to inventory

    /*
     * todo A: update so that when the colider **of the objects themselves** are hit, then go back to the parent and fire TimeGunForward(); - done
     * 
     * todo B: maybe add a bit of a jump in order to prevent weird collider things from happening
     * 
     * todo B.2: move the dummy object to keep them in the same place
     * 
     * todo C: add highlighting to objects so it's clear when they're selected
     */
    void FixedUpdate()
    {
        setText();
        mode = modeDebug;
        RaycastHit hit;
        Ray ray = new Ray(transform.position, transform.TransformDirection(transform.right));
        if (Physics.Raycast(ray, out hit))
        {
            //Debug.Log("Did Hit");
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.right) * 1000, Color.white);
            //Debug.Log(hit.collider.name);
            /*
            if (hit.collider.tag == "TimeGunParent" && isFiring == true)//todo A: change this so it looks for the TimeGunItem script
            {
                if (mode == 1)
                {
                    manager = hit.collider.gameObject.GetComponent<TimeGunEligible>();//todo A: get the object's parent, then run the timeGunForward script on it
                    manager.TimeGunForward();
                    //todo B: maybe add the jump (move the object up a bit?) to avoid collision issues
                } else if (mode == 2)
                {
                    manager = hit.collider.gameObject.GetComponent<TimeGunEligible>();
                    manager.TimeGunBack();
                }
                isFiring = false;
            }*/

            if(hit.collider.gameObject.GetComponent<TimeGunItem>() != null)
            {
                if (FireGun != null && FireGun.activeBinding)
                {
                    //checking if the player swipes down on the touchpad to toggle the inventory on and off
                    if (FireGun.GetStateDown(SteamVR_Input_Sources.LeftHand) || FireGun.GetStateDown(SteamVR_Input_Sources.RightHand))
                    {
                        Debug.Log("pew");
                        manager = hit.collider.gameObject.GetComponentInParent<TimeGunEligible>();
                        manager.TimeGunForward();
                        isFiring = false;
                    }
                }
            }
        }
        else
        {
            isFiring = false;
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.right) * 1000, Color.white);
        }
    }
    void setText()
    {
        if (mode == 1)
        {
            leftText.text = ">>";
            rightText.text = ">>";
            centerText.text = ">>";
        }
        else if (mode == 2)
        {
            leftText.text = "<<";
            rightText.text = "<<";
            centerText.text = "<<";
        }
    }
}
