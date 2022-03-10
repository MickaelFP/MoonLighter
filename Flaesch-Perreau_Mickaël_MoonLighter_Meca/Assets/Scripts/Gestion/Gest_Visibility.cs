using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gest_Visibility : MonoBehaviour
{
    [SerializeField] GameObject Objets;
    [SerializeField] GameObject PromotInventory;
    [SerializeField] GameObject ChestInventory;
    [SerializeField] GameObject PlayerInventory;
    [SerializeField] GameObject Hs_S_Door1;
    [SerializeField] GameObject Hs_S_Door2;

    public static Gest_Visibility Instance;
    private void Awake()
    {
        Instance = this;
    }

    void Update()
    {
        ShopClosingVisibility();
    }

    public void StartVisibility()
    {

    }

    public void CreditsVisibility()
    {

    }

    public void DeathVisibility()
    {

    }

    // Inventaires
    public void PromotInventoryVisibility()
    {
        GameManager.Instance.playerCanMove = false;
        Objets.SetActive(true);
        PlayerInventory.SetActive(true);
        PromotInventory.SetActive(true);
        GameManager.Instance.playerInventoryOpen = true;
        GameManager.Instance.promotInventoryOpen = true;
        CheckSlot.Instance.InPromot();
    }

    public void ChestInventoryVisibility()
    {
        GameManager.Instance.playerCanMove = false;
        Objets.SetActive(true);
        PlayerInventory.SetActive(true);
        ChestInventory.SetActive(true);
        GameManager.Instance.playerInventoryOpen = true;
        GameManager.Instance.chestInventoryOpen = true;
        CheckSlot.Instance.InHomeChest();
    }

    public void ShopOpenVisibility()
    {
        Hs_S_Door2.SetActive(true);
        Hs_S_Door1.SetActive(false);
        GameManager.Instance.HsDoorOpenToClient = true;
    }

    public void ShopClosingVisibility()
    {
        if (GameManager.Instance.shopClosing == true)
        {
            if (GameManager.Instance.nbClientInShop == 0)
            {
                HouseVisibility();
                GameManager.Instance.shopClosing = false;
                GameManager.Instance.firstClientSpawned = false;
            }
        }

        if (GameManager.Instance.shopClosing == false & GameManager.Instance.noArticleInShop == true 
            & GameManager.Instance.firstClientSpawned == true & GameManager.Instance.nbObjetInHand == 0)
        {
            GameManager.Instance.shopClosing = true;
        }
    }

    // Lieux
    public void HouseVisibility()
    {
        GameManager.Instance.playerCanMove = true;
        Objets.SetActive(false);
        PlayerInventory.SetActive(false);
        PromotInventory.SetActive(false);
        ChestInventory.SetActive(false);
        Hs_S_Door2.SetActive(false);
        Hs_S_Door1.SetActive(true);
        GameManager.Instance.playerInventoryOpen = false;
        GameManager.Instance.promotInventoryOpen = false;
        GameManager.Instance.chestInventoryOpen = false;
        GameManager.Instance.HsDoorOpenToClient = false;
    }

    public void OutsideVisibility()
    {
        CheckSlot.Instance.InGame();
    }

    public void DongeonVisibility()
    {
        CheckSlot.Instance.InGame();
    }
}
