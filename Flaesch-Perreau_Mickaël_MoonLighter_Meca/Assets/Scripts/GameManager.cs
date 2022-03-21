using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    /****************** STRING ******************/

    public int nbClientInShop = 0;
    public int argentOwned = 0;
    public int day = 1;
    public int timingDay = 1;
    public int nbClientMaxDay1 = 6;
    public int clientID = 0;

    public int sP1ID = 0;
    public int sP2ID = 0;
    public int sP3ID = 0;
    public int sP4ID = 0;
    public int sP5ID = 0;
    public int sP6ID = 0;
    public int sP7ID = 0;
    public int sP8ID = 0;
    public int sP9ID = 0;
    public int sP10ID = 0;
    public int sP11ID = 0;
    public int sP12ID = 0;

    // String HouseRoom = "Default";
    public string gameState = "Default";
    public string place = "Default";
    public string interactObject = "Default";
    public string interactObjectID = "Default";

    // Each slot take the ID of object sit on their position
    public string pSlot1ID = "Default";
    public string pSlot2ID = "Default";
    public string pSlot3ID = "Default";
    public string pSlot4ID = "Default";

    public string iSlot1ID = "Default";
    public string iSlot2ID = "Default";
    public string iSlot3ID = "Default";
    public string iSlot4ID = "Default";
    public string iSlot5ID = "Default";
    public string iSlot6ID = "Default";
    public string iSlot7ID = "Default";
    public string iSlot8ID = "Default";
    public string iSlot9ID = "Default";

    public string cSlot1ID = "Default";
    public string cSlot2ID = "Default";
    public string cSlot3ID = "Default";
    public string cSlot4ID = "Default";
    public string cSlot5ID = "Default";
    public string cSlot6ID = "Default";
    public string cSlot7ID = "Default";
    public string cSlot8ID = "Default";
    public string cSlot9ID = "Default";

    // Same for the waiting fill to pay & save position
    public int cWP1ID = 0;
    public int cWP2ID = 0;
    public int cWP3ID = 0;
    public int cWP4ID = 0;
    public int cWP5ID = 0;
    public int cWP6ID = 0;

    public string savePositionID = "Default";

    public int cWP1Reaching = 0;
    public int cWP2Reaching = 0;
    public int cWP3Reaching = 0;
    public int cWP4Reaching = 0;
    public int nbObjetInHand = 0;

    /****************** BOOLEAN ******************/

    public bool interactIsPossible = false;
    public bool promotInventoryOpen = false;
    public bool chestInventoryOpen = false;
    public bool playerInventoryOpen = false;
    public bool onlyPlayerInventory = false;
    public bool dungeonChestInventoryOpen = false;
    public bool IObjetMoving = false;
    public bool HsDoorOpenToClient = false;
    public bool shopClosing = false;
    public bool firstClientSpawned = false;
    public bool argentToEncaisse = false;
    public bool playerCanMove = true;
    public bool noArticleInShop = true;

    public bool objet1OnSelling = false;
    public bool objet2OnSelling = false;
    public bool objet3OnSelling = false;
    public bool objet4OnSelling = false;

    public bool pSlot1Empty = true;
    public bool pSlot2Empty = true;
    public bool pSlot3Empty = true;
    public bool pSlot4Empty = true;

    // State of Slots and Objects
    public bool iSlot1Empty = false;
    public bool iSlot2Empty = false;
    public bool iSlot3Empty = false;
    public bool iSlot4Empty = false;
    public bool iSlot5Empty = false;
    public bool iSlot6Empty = false;
    public bool iSlot7Empty = false;
    public bool iSlot8Empty = false;
    public bool iSlot9Empty = false;

    public bool cSlot1Empty = false;
    public bool cSlot2Empty = false;
    public bool cSlot3Empty = false;
    public bool cSlot4Empty = false;
    public bool cSlot5Empty = false;
    public bool cSlot6Empty = false;
    public bool cSlot7Empty = false;
    public bool cSlot8Empty = false;
    public bool cSlot9Empty = false;

    public bool ID01OnSelling = false;
    public bool ID02OnSelling = false;
    public bool ID03OnSelling = false;
    public bool ID04OnSelling = false;
    public bool ID05OnSelling = false;
    public bool ID06OnSelling = false;
    public bool ID07OnSelling = false;
    public bool ID08OnSelling = false;
    public bool ID09OnSelling = false;

    /*public bool ObjectID1moving = false;
    public bool ObjectID2moving = false;
    public bool ObjectID3moving = false;
    public bool ObjectID4moving = false;
    public bool ObjectID5moving = false;
    public bool ObjectID6moving = false;
    public bool ObjectID7moving = false;
    public bool ObjectID8moving = false;
    public bool ObjectID9moving = false;*/

    public static GameManager Instance;
    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        Gest_Visibility.Instance.HouseVisibility();
        gameState = "House";
    }
     // Pour le déplacment des objets de l'inventaire en MoveToward
    /*void Update()
    {
        // Deplacement des objects via l'inventaire
        if (promotInventoryOpen == true || chestInventoryOpen)
        {
            OneByOne();
        }
    }

    private void OneByOne()
    {
        if (ObjectID1moving == false
            & ObjectID2moving == false
            & ObjectID3moving == false
            & ObjectID4moving == false
            & ObjectID5moving == false
            & ObjectID6moving == false
            & ObjectID7moving == false
            & ObjectID8moving == false
            & ObjectID9moving == false)
        {
            IObjetMoving = false;
        }
        else
        {
            IObjetMoving = true;
        }
    }*/
}
