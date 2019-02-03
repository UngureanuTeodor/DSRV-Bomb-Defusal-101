using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerTriggerAction : MonoBehaviour {

    private SteamVR_TrackedObject trackedObj;
    // 1
    private GameObject collidingObject;
    // 2
    private GameObject objectInHand;

    // 1
    public GameObject laserPrefab;
    // 2
    private GameObject laser;
    // 3
    private Transform laserTransform;
    // 4
    private Vector3 hitPoint;
    private bool hasLaser = false;
    public int controllerIndex;
    private int layerMask = 1 << 8;
    private GameObject lastHighlighted;

    private SteamVR_Controller.Device Controller
    {
        get { return SteamVR_Controller.Input((int)trackedObj.index); }
    }

    void Awake()
    {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
    }

    // Use this for initialization
    void Start()
    {
        // 1
        laser = Instantiate(laserPrefab);
        // 2
        laserTransform = laser.transform;
    }

    public void setHasLaser(bool newValue)
    {
        hasLaser = newValue;
    }

    private void ShowLaser(RaycastHit hit)
    {
        // 1
        laser.SetActive(true);
        // 2
        laserTransform.position = Vector3.Lerp(trackedObj.transform.position, hitPoint, .5f);
        // 3
        laserTransform.LookAt(hitPoint);
        // 4
        laserTransform.localScale = new Vector3(laserTransform.localScale.x, laserTransform.localScale.y,
            hit.distance);
    }

    private void SetCollidingObject(Collider col)
    {

        // 1
        if (collidingObject || !col.GetComponent<Rigidbody>() || !(col.gameObject.tag == "Bomb"))
        {
            return;
        }
        // 2
        collidingObject = col.gameObject;
    }

    // 1
    public void OnTriggerEnter(Collider other)
    {
        //Debug.Log("trigger enter: " + other.gameObject.tag);
        SetCollidingObject(other);
    }

    // 2
    public void OnTriggerStay(Collider other)
    {
        SetCollidingObject(other);
    }

    // 3
    public void OnTriggerExit(Collider other)
    {
        //Debug.Log("trigger exit: " + other.gameObject.tag);
        if (!collidingObject)
        {
            return;
        }

        collidingObject = null;
    }

    private void GrabObject()
    {
        // 1
        objectInHand = collidingObject;
        collidingObject = null;
        GameManager.Get().selectBomb(controllerIndex);
        // 2
        var joint = AddFixedJoint();
        joint.connectedBody = objectInHand.GetComponent<Rigidbody>();
    }

    // 3
    private FixedJoint AddFixedJoint()
    {
        FixedJoint fx = gameObject.AddComponent<FixedJoint>();
        fx.breakForce = 20000;
        fx.breakTorque = 20000;
        return fx;
    }

    private void ReleaseObject()
    {
        // 1
        if (GetComponent<FixedJoint>())
        {
            // 2
            GetComponent<FixedJoint>().connectedBody = null;
            Destroy(GetComponent<FixedJoint>());
            GameManager.Get().deselectBomb();
            // 3
            objectInHand.GetComponent<Rigidbody>().velocity = Controller.velocity;
            objectInHand.GetComponent<Rigidbody>().angularVelocity = Controller.angularVelocity;
        }
        // 4
        objectInHand = null;
    }

    // Update is called once per frame
    void Update () {
        // 1
        if (hasLaser)
        {
            RaycastHit hit;

            // 2
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 10))
            {
                hitPoint = hit.point;
                ShowLaser(hit);

                if (hit.transform.gameObject.layer == 8)
                {
                    if(lastHighlighted != hit.transform.gameObject)
                    {
                        if (lastHighlighted != null)
                        {
                            lastHighlighted.GetComponent<InteractibleElementScript>().unhighlightObject();
                        }
                        if (hit.transform.gameObject.GetComponent<ChessButtonScript>())
                        {
                            hit.transform.gameObject.GetComponent<ChessButtonScript>().highlightObject();
                        }
                        if (hit.transform.gameObject.GetComponent<Keypad>())
                        {
                            hit.transform.gameObject.GetComponent<Keypad>().highlightObject();
                        }
                        if (hit.transform.gameObject.GetComponent<WOF_PressButton>())
                        {
                            hit.transform.gameObject.GetComponent<WOF_PressButton>().highlightObject();
                        }
                        if (hit.transform.gameObject.GetComponent<WireObj>())
                        {
                            hit.transform.gameObject.GetComponent<WireObj>().highlightObject();
                        }
                        if (hit.transform.gameObject.GetComponent<ScreenBoxButton>())
                        {
                            hit.transform.gameObject.GetComponent<ScreenBoxButton>().highlightObject();
                        }
                        if (hit.collider.transform.parent.gameObject.GetComponent<Book>())
                        {
                            hit.collider.transform.parent.gameObject.GetComponent<Book>().selectedPage = hit.transform.name;
                            hit.collider.transform.parent.gameObject.GetComponent<Book>().highlightObject();
                        }
                    }
                    if (hit.collider.transform.parent.gameObject.GetComponent<Book>())
                    {
                        lastHighlighted = hit.collider.transform.parent.gameObject;
                    }
                    else
                    {
                        lastHighlighted = hit.transform.gameObject;
                    }
                    //Debug.Log(hit.transform.name);
                } else
                {
                    if (lastHighlighted != null)
                    {
                        lastHighlighted.GetComponent<InteractibleElementScript>().unhighlightObject();
                        lastHighlighted = null;
                    }
                }
            }
            if (Controller.GetHairTriggerUp())
            {
                if (lastHighlighted != null)
                {
                    lastHighlighted.GetComponent<InteractibleElementScript>().interactWithElement();;
                }
                laser.SetActive(false);
            }
        }
        else
        {
            laser.SetActive(false);
            if (Controller.GetHairTriggerDown())
            {
                if (collidingObject)
                {
                    GrabObject();
                }
            }

            // 2
            if (Controller.GetHairTriggerUp())
            {
                if (objectInHand)
                {
                    ReleaseObject();
                }
            }
        }
    }
}
