using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangementOfSpot : MonoBehaviour
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

    public bool InInventory = false;

    public static ChangementOfSpot Instance;
    private void Awake()
    {
        Instance = this;
    }

    public void OnMouseClick()
    {
        //Debug.Log(gameObject.tag);
        //Debug.Log("C'EST PARTI");
        if (GameManager.Instance.promotInventoryOpen == true)
        {
            PlacementObjetInShop();
        }
        else if (GameManager.Instance.chestInventoryOpen == true)
        {
            //Debug.Log("STEP 1");
            PlacementObjetInHomeChest();
        }
    }

    private void PlacementObjetInShop()
    {
        if (InInventory == true)
        {
            if (GameManager.Instance.pSlot1Empty == true) GestBoolInInventory1(pSlot1.transform.position, ref GameManager.Instance.pSlot1ID);
            else if (GameManager.Instance.pSlot2Empty == true) GestBoolInInventory1(pSlot2.transform.position, ref GameManager.Instance.pSlot2ID);
            else if (GameManager.Instance.pSlot3Empty == true) GestBoolInInventory1(pSlot3.transform.position, ref GameManager.Instance.pSlot3ID);
            else if (GameManager.Instance.pSlot4Empty == true) GestBoolInInventory1(pSlot4.transform.position, ref GameManager.Instance.pSlot4ID);
        }
        else
        {
            MoveToISlot();
        }
    }

    private void PlacementObjetInHomeChest()
    {
        if (InInventory == true)
        {
            if (GameManager.Instance.cSlot1Empty == true) GestBoolInInventory2(cSlot1.transform.position, ref GameManager.Instance.cSlot1ID);
            else if (GameManager.Instance.cSlot2Empty == true) GestBoolInInventory2(cSlot2.transform.position, ref GameManager.Instance.cSlot2ID);
            else if (GameManager.Instance.cSlot3Empty == true) GestBoolInInventory2(cSlot3.transform.position, ref GameManager.Instance.cSlot3ID);
            else if (GameManager.Instance.cSlot4Empty == true) GestBoolInInventory2(cSlot4.transform.position, ref GameManager.Instance.cSlot4ID);
            else if (GameManager.Instance.cSlot5Empty == true) GestBoolInInventory2(cSlot5.transform.position, ref GameManager.Instance.cSlot5ID);
            else if (GameManager.Instance.cSlot6Empty == true) GestBoolInInventory2(cSlot6.transform.position, ref GameManager.Instance.cSlot6ID);
            else if (GameManager.Instance.cSlot7Empty == true) GestBoolInInventory2(cSlot7.transform.position, ref GameManager.Instance.cSlot7ID);
            else if (GameManager.Instance.cSlot8Empty == true) GestBoolInInventory2(cSlot8.transform.position, ref GameManager.Instance.cSlot8ID);
            else if (GameManager.Instance.cSlot9Empty == true) GestBoolInInventory2(cSlot9.transform.position, ref GameManager.Instance.cSlot9ID);
        }
        else
        {
            MoveToISlot();
        }
    }
    private void MoveToISlot()
    {
        //Debug.Log("STEP 2");
        if (GameManager.Instance.iSlot1Empty == true) GestBoolInPSlot(iSlot1.transform.position, ref GameManager.Instance.iSlot1ID);
        else if (GameManager.Instance.iSlot2Empty == true) GestBoolInPSlot(iSlot2.transform.position, ref GameManager.Instance.iSlot2ID);
        else if (GameManager.Instance.iSlot3Empty == true) GestBoolInPSlot(iSlot3.transform.position, ref GameManager.Instance.iSlot3ID);
        else if (GameManager.Instance.iSlot4Empty == true) GestBoolInPSlot(iSlot4.transform.position, ref GameManager.Instance.iSlot4ID);
        else if (GameManager.Instance.iSlot5Empty == true) GestBoolInPSlot(iSlot5.transform.position, ref GameManager.Instance.iSlot5ID);
        else if (GameManager.Instance.iSlot6Empty == true) GestBoolInPSlot(iSlot6.transform.position, ref GameManager.Instance.iSlot6ID);
        else if (GameManager.Instance.iSlot7Empty == true) GestBoolInPSlot(iSlot7.transform.position, ref GameManager.Instance.iSlot7ID);
        else if (GameManager.Instance.iSlot8Empty == true) GestBoolInPSlot(iSlot8.transform.position, ref GameManager.Instance.iSlot8ID);
        else if (GameManager.Instance.iSlot9Empty == true) GestBoolInPSlot(iSlot9.transform.position, ref GameManager.Instance.iSlot9ID);
    }

    private void GestBoolInInventory1(Vector3 SpotPos, ref string SlotID)
    {
        ResetSpotID();
        InInventory = false;
        transform.position = SpotPos;
        SlotID = tag;
        CheckObjetOnSelling();
    }

    private void GestBoolInInventory2(Vector3 SpotPos, ref string SlotID)
    {
        ResetSpotID();
        InInventory = false;
        transform.position = SpotPos;
        SlotID = tag;
    }

    private void GestBoolInPSlot(Vector3 SpotPos, ref string SlotID)
    {
        ResetSpotID();
        //Debug.Log("STEP 3");
        InInventory = true;
        transform.position = SpotPos;
        SlotID = tag;
    }

    private void ResetSpotID()
    {
        ActualSpotID(ref GameManager.Instance.pSlot1ID);
        ActualSpotID(ref GameManager.Instance.pSlot2ID);
        ActualSpotID(ref GameManager.Instance.pSlot3ID);
        ActualSpotID(ref GameManager.Instance.pSlot4ID);
        ActualSpotID(ref GameManager.Instance.iSlot1ID);
        ActualSpotID(ref GameManager.Instance.iSlot2ID);
        ActualSpotID(ref GameManager.Instance.iSlot3ID);
        ActualSpotID(ref GameManager.Instance.iSlot4ID);
        ActualSpotID(ref GameManager.Instance.iSlot5ID);
        ActualSpotID(ref GameManager.Instance.iSlot6ID);
        ActualSpotID(ref GameManager.Instance.iSlot7ID);
        ActualSpotID(ref GameManager.Instance.iSlot8ID);
        ActualSpotID(ref GameManager.Instance.iSlot9ID);
        ActualSpotID(ref GameManager.Instance.cSlot1ID);
        ActualSpotID(ref GameManager.Instance.cSlot2ID);
        ActualSpotID(ref GameManager.Instance.cSlot3ID);
        ActualSpotID(ref GameManager.Instance.cSlot4ID);
        ActualSpotID(ref GameManager.Instance.cSlot5ID);
        ActualSpotID(ref GameManager.Instance.cSlot6ID);
        ActualSpotID(ref GameManager.Instance.cSlot7ID);
        ActualSpotID(ref GameManager.Instance.cSlot8ID);
        ActualSpotID(ref GameManager.Instance.cSlot9ID);
    }
    private void ActualSpotID(ref string SpotID)
    {
        if (SpotID == tag)
        {
            SpotID = "Default";
        }
    }

    public void CheckObjetOnSelling()
    {
        if (GameManager.Instance.pSlot1ID != "Default") GameManager.Instance.objet1OnSelling = true;
        else GameManager.Instance.objet1OnSelling = false;
        if (GameManager.Instance.pSlot2ID != "Default") GameManager.Instance.objet2OnSelling = true;
        else GameManager.Instance.objet2OnSelling = false;
        if (GameManager.Instance.pSlot3ID != "Default") GameManager.Instance.objet3OnSelling = true;
        else GameManager.Instance.objet3OnSelling = false;
        if (GameManager.Instance.pSlot4ID != "Default") GameManager.Instance.objet4OnSelling = true;
        else GameManager.Instance.objet4OnSelling = false;
    }
}
