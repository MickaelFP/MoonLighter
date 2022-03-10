/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToPSlotEmpty : MonoBehaviour
{
    [SerializeField] GameObject pSlot1;
    [SerializeField] GameObject pSlot2;
    [SerializeField] GameObject pSlot3;
    [SerializeField] GameObject pSlot4;

    [SerializeField] GameObject iSlot1;
    [SerializeField] GameObject iSlot2;
    [SerializeField] GameObject iSlot3;
    [SerializeField] GameObject iSlot4;
    [SerializeField] GameObject iSlot5;
    [SerializeField] GameObject iSlot6;
    [SerializeField] GameObject iSlot7;
    [SerializeField] GameObject iSlot8;
    [SerializeField] GameObject iSlot9;

    [SerializeField] GameObject cSlot1;
    [SerializeField] GameObject cSlot2;
    [SerializeField] GameObject cSlot3;
    [SerializeField] GameObject cSlot4;
    [SerializeField] GameObject cSlot5;
    [SerializeField] GameObject cSlot6;
    [SerializeField] GameObject cSlot7;
    [SerializeField] GameObject cSlot8;
    [SerializeField] GameObject cSlot9;

    [SerializeField] float speedMoveTo = 1f;
    float speedTemp;

    public bool InInventory = false;
    public bool Moving = false;

    public bool MoveToPSlot1 = false;
    public bool MoveToPSlot2 = false;
    public bool MoveToPSlot3 = false;
    public bool MoveToPSlot4 = false;

    public bool MoveToISlot1 = false;
    public bool MoveToISlot2 = false;
    public bool MoveToISlot3 = false;
    public bool MoveToISlot4 = false;
    public bool MoveToISlot5 = false;
    public bool MoveToISlot6 = false;
    public bool MoveToISlot7 = false;
    public bool MoveToISlot8 = false;
    public bool MoveToISlot9 = false;

    public bool MoveToCSlot1 = false;
    public bool MoveToCSlot2 = false;
    public bool MoveToCSlot3 = false;
    public bool MoveToCSlot4 = false;
    public bool MoveToCSlot5 = false;
    public bool MoveToCSlot6 = false;
    public bool MoveToCSlot7 = false;
    public bool MoveToCSlot8 = false;
    public bool MoveToCSlot9 = false;

    public static MoveToPSlotEmpty Instance;
    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        //ActualObjetImmobile();
    }

    void Update()
    {
        if (transform.position == iSlot1.transform.position)
        {
            Debug.Log("WHYYYYYYYY");
        }
    }

    void FixedUpdate()
    {
        speedTemp = speedMoveTo * Time.deltaTime * 100;

        if (GameManager.Instance.promotInventoryOpen == true)
        {
            MoveToPSlot();
        }
        if (GameManager.Instance.chestInventoryOpen == true)
        {
            MoveToCSlot();
        }
        MoveToISlot();
        FreezPosition();
        MovePosition();
    }

    public void OnMouseClick()
    {
        Debug.Log(gameObject.tag);
        if (GameManager.Instance.IObjetMoving == false)
        {
            GameManager.Instance.IObjetMoving = true;
            Debug.Log("C'EST PARTI");
            if (GameManager.Instance.promotInventoryOpen == true)
            {
                PlacementObjetInShop();
            }
            else if (GameManager.Instance.chestInventoryOpen == true)
            {
                Debug.Log("STEP 1");
                PlacementObjetInHomeChest();
            }

        }
        else
        {
            Debug.Log("PAS ENCORE");
        }
    }

    private void PlacementObjetInShop()
    {
        if (InInventory == true)
        {
            if (GameManager.Instance.pSlot1Empty == true) GestBoolInInventory(ref MoveToPSlot1);
            else if (GameManager.Instance.pSlot2Empty == true) GestBoolInInventory(ref MoveToPSlot2);
            else if (GameManager.Instance.pSlot3Empty == true) GestBoolInInventory(ref MoveToPSlot3);
            else if (GameManager.Instance.pSlot4Empty == true) GestBoolInInventory(ref MoveToPSlot4);
        }
        else
        {
            Debug.Log("STEP 2");
            if (GameManager.Instance.iSlot1Empty == true) GestBoolInPSlot(ref MoveToISlot1);
            else if (GameManager.Instance.iSlot2Empty == true) GestBoolInPSlot(ref MoveToISlot2);
            else if (GameManager.Instance.iSlot3Empty == true) GestBoolInPSlot(ref MoveToISlot3);
            else if (GameManager.Instance.iSlot4Empty == true) GestBoolInPSlot(ref MoveToISlot4);
            else if (GameManager.Instance.iSlot5Empty == true) GestBoolInPSlot(ref MoveToISlot5);
            else if (GameManager.Instance.iSlot6Empty == true) GestBoolInPSlot(ref MoveToISlot6);
            else if (GameManager.Instance.iSlot7Empty == true) GestBoolInPSlot(ref MoveToISlot7);
            else if (GameManager.Instance.iSlot8Empty == true) GestBoolInPSlot(ref MoveToISlot8);
            else if (GameManager.Instance.iSlot9Empty == true) GestBoolInPSlot(ref MoveToISlot9);
        }
    }

    private void PlacementObjetInHomeChest()
    {
        if (InInventory == true)
        {
            if (GameManager.Instance.cSlot1Empty == true) GestBoolInInventory(ref MoveToCSlot1);
            else if (GameManager.Instance.cSlot2Empty == true) GestBoolInInventory(ref MoveToCSlot2);
            else if (GameManager.Instance.cSlot3Empty == true) GestBoolInInventory(ref MoveToCSlot3);
            else if (GameManager.Instance.cSlot4Empty == true) GestBoolInInventory(ref MoveToCSlot4);
            else if (GameManager.Instance.cSlot5Empty == true) GestBoolInInventory(ref MoveToCSlot5);
            else if (GameManager.Instance.cSlot6Empty == true) GestBoolInInventory(ref MoveToCSlot6);
            else if (GameManager.Instance.cSlot7Empty == true) GestBoolInInventory(ref MoveToCSlot7);
            else if (GameManager.Instance.cSlot8Empty == true) GestBoolInInventory(ref MoveToCSlot8);
            else if (GameManager.Instance.cSlot9Empty == true) GestBoolInInventory(ref MoveToCSlot9);
        }
        else
        {
            Debug.Log("STEP 3");
            if (GameManager.Instance.iSlot1Empty == true) GestBoolInPSlot(ref MoveToISlot1);
            else if (GameManager.Instance.iSlot2Empty == true) GestBoolInPSlot(ref MoveToISlot2);
            else if (GameManager.Instance.iSlot3Empty == true) GestBoolInPSlot(ref MoveToISlot3);
            else if (GameManager.Instance.iSlot4Empty == true) GestBoolInPSlot(ref MoveToISlot4);
            else if (GameManager.Instance.iSlot5Empty == true) GestBoolInPSlot(ref MoveToISlot5);
            else if (GameManager.Instance.iSlot6Empty == true) GestBoolInPSlot(ref MoveToISlot6);
            else if (GameManager.Instance.iSlot7Empty == true) GestBoolInPSlot(ref MoveToISlot7);
            else if (GameManager.Instance.iSlot8Empty == true) GestBoolInPSlot(ref MoveToISlot8);
            else if (GameManager.Instance.iSlot9Empty == true) GestBoolInPSlot(ref MoveToISlot9);
        }
    }

    private void GestBoolInInventory(ref bool parGoingPos)
    {
        parGoingPos = true;
        InInventory = false;
        Moving = true;
    }
    private void GestBoolInPSlot(ref bool parGoingPos)
    {
        Debug.Log("STEP 4");
        parGoingPos = true;
        InInventory = true;
        Moving = true;
    }

    private void MoveToPSlot()
    {
        if (MoveToPSlot1 == true) transform.position = Vector3.MoveTowards(transform.position, pSlot1.transform.position, speedTemp);
        else if (MoveToPSlot2 == true) transform.position = Vector3.MoveTowards(transform.position, pSlot2.transform.position, speedTemp);
        else if (MoveToPSlot3 == true) transform.position = Vector3.MoveTowards(transform.position, pSlot3.transform.position, speedTemp);
        else if (MoveToPSlot4 == true) transform.position = Vector3.MoveTowards(transform.position, pSlot4.transform.position, speedTemp);
    }

    private void MoveToISlot()
    {
        *//*if (MoveToISlot1 == true)
        { 
            transform.position = Vector3.MoveTowards(transform.position, iSlot1.transform.position, speedTemp);
            Debug.Log("STEP 5");
        }
        else if (MoveToISlot2 == true) transform.position = Vector3.MoveTowards(transform.position, iSlot2.transform.position, speedTemp);
        else if (MoveToISlot3 == true) transform.position = Vector3.MoveTowards(transform.position, iSlot3.transform.position, speedTemp);
        else if (MoveToISlot4 == true) transform.position = Vector3.MoveTowards(transform.position, iSlot4.transform.position, speedTemp);
        else if (MoveToISlot5 == true) transform.position = Vector3.MoveTowards(transform.position, iSlot5.transform.position, speedTemp);
        else if (MoveToISlot6 == true) transform.position = Vector3.MoveTowards(transform.position, iSlot6.transform.position, speedTemp);
        else if (MoveToISlot7 == true) transform.position = Vector3.MoveTowards(transform.position, iSlot7.transform.position, speedTemp);
        else if (MoveToISlot8 == true) transform.position = Vector3.MoveTowards(transform.position, iSlot8.transform.position, speedTemp);
        else if (MoveToISlot9 == true) transform.position = Vector3.MoveTowards(transform.position, iSlot9.transform.position, speedTemp);*//*
        if (MoveToISlot1 == true)
        {
            transform.position = iSlot1.transform.position;
            Debug.Log("STEP 5");
        }
        else if (MoveToISlot2 == true) transform.position = Vector3.MoveTowards(transform.position, iSlot2.transform.position, speedTemp);
        else if (MoveToISlot3 == true) transform.position = Vector3.MoveTowards(transform.position, iSlot3.transform.position, speedTemp);
        else if (MoveToISlot4 == true) transform.position = Vector3.MoveTowards(transform.position, iSlot4.transform.position, speedTemp);
        else if (MoveToISlot5 == true) transform.position = Vector3.MoveTowards(transform.position, iSlot5.transform.position, speedTemp);
        else if (MoveToISlot6 == true) transform.position = Vector3.MoveTowards(transform.position, iSlot6.transform.position, speedTemp);
        else if (MoveToISlot7 == true) transform.position = Vector3.MoveTowards(transform.position, iSlot7.transform.position, speedTemp);
        else if (MoveToISlot8 == true) transform.position = Vector3.MoveTowards(transform.position, iSlot8.transform.position, speedTemp);
        else if (MoveToISlot9 == true) transform.position = Vector3.MoveTowards(transform.position, iSlot9.transform.position, speedTemp);
    }

    private void MoveToCSlot()
    {
        if (MoveToCSlot1 == true) transform.position = Vector3.MoveTowards(transform.position, cSlot1.transform.position, speedTemp);
        else if (MoveToCSlot2 == true) transform.position = Vector3.MoveTowards(transform.position, cSlot2.transform.position, speedTemp);
        else if (MoveToCSlot3 == true) transform.position = Vector3.MoveTowards(transform.position, cSlot3.transform.position, speedTemp);
        else if (MoveToCSlot4 == true) transform.position = Vector3.MoveTowards(transform.position, cSlot4.transform.position, speedTemp);
        else if (MoveToCSlot5 == true) transform.position = Vector3.MoveTowards(transform.position, cSlot5.transform.position, speedTemp);
        else if (MoveToCSlot6 == true) transform.position = Vector3.MoveTowards(transform.position, cSlot6.transform.position, speedTemp);
        else if (MoveToCSlot7 == true) transform.position = Vector3.MoveTowards(transform.position, cSlot7.transform.position, speedTemp);
        else if (MoveToCSlot8 == true) transform.position = Vector3.MoveTowards(transform.position, cSlot8.transform.position, speedTemp);
        else if (MoveToCSlot9 == true) transform.position = Vector3.MoveTowards(transform.position, cSlot9.transform.position, speedTemp);
    }

    public void FreezPosition()
    {*/
        /*if (transform.position == pSlot1.transform.position
            || transform.position == pSlot2.transform.position
            || transform.position == pSlot3.transform.position
            || transform.position == pSlot4.transform.position
            || transform.position == iSlot1.transform.position
            || transform.position == iSlot2.transform.position
            || transform.position == iSlot3.transform.position
            || transform.position == iSlot4.transform.position
            || transform.position == iSlot5.transform.position
            || transform.position == iSlot6.transform.position
            || transform.position == iSlot7.transform.position
            || transform.position == iSlot8.transform.position
            || transform.position == iSlot9.transform.position
            || transform.position == cSlot1.transform.position
            || transform.position == cSlot2.transform.position
            || transform.position == cSlot3.transform.position
            || transform.position == cSlot4.transform.position
            || transform.position == cSlot5.transform.position
            || transform.position == cSlot6.transform.position
            || transform.position == cSlot7.transform.position
            || transform.position == cSlot8.transform.position
            || transform.position == cSlot9.transform.position)
        {
            MoveTo = false;
            Moving = false;
        }*//*
        Stopping(iSlot1.transform.position, ref MoveToISlot1);
        Stopping(iSlot2.transform.position, ref MoveToISlot2);
        Stopping(iSlot3.transform.position, ref MoveToISlot3);
        Stopping(iSlot4.transform.position, ref MoveToISlot4);
        Stopping(iSlot5.transform.position, ref MoveToISlot5);
        Stopping(iSlot6.transform.position, ref MoveToISlot6);
        Stopping(iSlot7.transform.position, ref MoveToISlot7);
        Stopping(iSlot8.transform.position, ref MoveToISlot8);
        Stopping(iSlot9.transform.position, ref MoveToISlot9);
        Stopping(cSlot1.transform.position, ref MoveToCSlot1);
        Stopping(cSlot2.transform.position, ref MoveToCSlot2);
        Stopping(cSlot3.transform.position, ref MoveToCSlot3);
        Stopping(cSlot4.transform.position, ref MoveToCSlot4);
        Stopping(cSlot5.transform.position, ref MoveToCSlot5);
        Stopping(cSlot6.transform.position, ref MoveToCSlot6);
        Stopping(cSlot7.transform.position, ref MoveToCSlot7);
        Stopping(cSlot8.transform.position, ref MoveToCSlot8);
        Stopping(cSlot9.transform.position, ref MoveToCSlot9);
    }

    public void Stopping(Vector3 parSlotPos, ref bool MoveTo)
    {
        if (transform.position == parSlotPos)
        {
            MoveTo = false;
            Moving = false;
            ActualObjetImmobile();
        }
    }

    private void MovePosition()
    {
        if (Moving == true)
        {
            ActualObjetMobile();
        }
    }

    public void ActualObjetImmobile()
    {
        if (tag == "ID01") GameManager.Instance.ObjectID1moving = false;
        if (tag == "ID02") GameManager.Instance.ObjectID2moving = false;
        if (tag == "ID03") GameManager.Instance.ObjectID3moving = false;
        if (tag == "ID04") GameManager.Instance.ObjectID4moving = false;
        if (tag == "ID05") GameManager.Instance.ObjectID5moving = false;
        if (tag == "ID06") GameManager.Instance.ObjectID6moving = false;
        if (tag == "ID07") GameManager.Instance.ObjectID7moving = false;
        if (tag == "ID08") GameManager.Instance.ObjectID8moving = false;
        if (tag == "ID09") GameManager.Instance.ObjectID9moving = false;
    }
    public void ActualObjetMobile()
    {
        if (tag == "ID01") GameManager.Instance.ObjectID1moving = true;
        if (tag == "ID02") GameManager.Instance.ObjectID2moving = true;
        if (tag == "ID03") GameManager.Instance.ObjectID3moving = true;
        if (tag == "ID04") GameManager.Instance.ObjectID4moving = true;
        if (tag == "ID05") GameManager.Instance.ObjectID5moving = true;
        if (tag == "ID06") GameManager.Instance.ObjectID6moving = true;
        if (tag == "ID07") GameManager.Instance.ObjectID7moving = true;
        if (tag == "ID08") GameManager.Instance.ObjectID8moving = true;
        if (tag == "ID09") GameManager.Instance.ObjectID9moving = true;
    }
}*/
