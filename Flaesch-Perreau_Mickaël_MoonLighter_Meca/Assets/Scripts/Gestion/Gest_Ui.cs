using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Gest_Ui : MonoBehaviour
{
    [SerializeField] GameObject PressE1;
    [SerializeField] GameObject PressE1_2;
    [SerializeField] GameObject PressE2;
    [SerializeField] GameObject PressE2_2;
    [SerializeField] GameObject PressE2_3;
    [SerializeField] GameObject PressE2_4;
    [SerializeField] GameObject PressE2_5;
    [SerializeField] GameObject PressE3;
    [SerializeField] GameObject PressE3_2;
    [SerializeField] GameObject PressE4;
    [SerializeField] GameObject PressE5;
    [SerializeField] GameObject PressE5_2;
    [SerializeField] GameObject PressI1;
    [SerializeField] GameObject PressI1_2;

    [SerializeField] GameObject InfoDay;

    [SerializeField] TextMeshPro ArgentOwnedTotal;
    [SerializeField] TextMeshProUGUI InfoDayTxT;

    [SerializeField] TextMeshPro Price1;
    [SerializeField] TextMeshPro Price2;
    [SerializeField] TextMeshPro Price3;
    [SerializeField] TextMeshPro Price4;

    void Update()
    {
        MsgInteractIsPossible();
        MsgOnlyPlayerInventoryOpen();
        ShowPrice();
        InfoInGame();
    }

    public void MsgInteractIsPossible()
    {
        // Promontories in shop
        if (GameManager.Instance.interactObject == "Promot_tapis" & GameManager.Instance.HsDoorOpenToClient == false
            & GameManager.Instance.onlyPlayerInventory == false)
        {
            if (GameManager.Instance.promotInventoryOpen == false)
            { 
                PressE1.SetActive(true);
                PressE1_2.SetActive(false);
            }
            else
            {
                PressE1.SetActive(false);
                PressE1_2.SetActive(true);
            }
        }
        else
        { 
            PressE1.SetActive(false);
            PressE1_2.SetActive(false);
        }
        // Personnal chest at home
        if (GameManager.Instance.interactObject == "Home_Chest" & GameManager.Instance.onlyPlayerInventory == false)
        {
            if (GameManager.Instance.chestInventoryOpen == false)
            {
                PressE3.SetActive(true);
                PressE3_2.SetActive(false);
            }
            else
            {
                PressE3.SetActive(false);
                PressE3_2.SetActive(true);
            }
        }
        else
        {
            PressE3.SetActive(false);
            PressE3_2.SetActive(false);
        }
        // Exit/enter shop's door
        if (GameManager.Instance.interactObject == "Hs_S_Door" & GameManager.Instance.onlyPlayerInventory == false)
        {
            if (GameManager.Instance.interactObjectID == "DoorID1")
            {
                if (GameManager.Instance.HsDoorOpenToClient == false)
                {
                    if(GameManager.Instance.timingDay < 4)
                    {
                        if (GameManager.Instance.noArticleInShop != true)
                        {
                            PressE2.SetActive(true);
                            PressE2_2.SetActive(false);
                            PressE2_3.SetActive(false);
                            PressE2_4.SetActive(false);
                            PressE2_5.SetActive(false);
                        }
                        else
                        {
                            PressE2.SetActive(false);
                            PressE2_2.SetActive(false);
                            PressE2_3.SetActive(false);
                            PressE2_4.SetActive(true);
                            PressE2_5.SetActive(false);
                        }
                    }
                    else
                    {
                        PressE2.SetActive(false);
                        PressE2_2.SetActive(false);
                        PressE2_3.SetActive(false);
                        PressE2_4.SetActive(false);
                        PressE2_5.SetActive(true);
                    }
                }
                else
                {
                    if (GameManager.Instance.shopClosing == false)
                    {
                        PressE2.SetActive(false);
                        PressE2_2.SetActive(true);
                        PressE2_3.SetActive(false);
                        PressE2_4.SetActive(false);
                        PressE2_5.SetActive(false);
                    }
                    else
                    {
                        PressE2.SetActive(false);
                        PressE2_2.SetActive(false);
                        PressE2_3.SetActive(true);
                        PressE2_4.SetActive(false);
                        PressE2_5.SetActive(false);
                    }
                }
            }
        }
        else
        {
            PressE2.SetActive(false);
            PressE2_2.SetActive(false);
            PressE2_3.SetActive(false);
            PressE2_4.SetActive(false);
            PressE2_5.SetActive(false);
        }
        // Caisse in shop
        if (GameManager.Instance.interactObject == "CaisseE" & GameManager.Instance.onlyPlayerInventory == false)
        {
            if (GameManager.Instance.argentToEncaisse == false) PressE4.SetActive(true);
            else PressE4.SetActive(false);
        }
        else PressE4.SetActive(false);
        // Lit
        if (GameManager.Instance.interactObject == "Bed" & GameManager.Instance.onlyPlayerInventory == false)
        {
            if (GameManager.Instance.HsDoorOpenToClient == false)
            {
                PressE5.SetActive(true);
                PressE5_2.SetActive(true);
            }
            else
            {
                PressE5.SetActive(false);
                PressE5_2.SetActive(true);
            }
        }
        else
        {
            PressE5.SetActive(false);
            PressE5_2.SetActive(false);
        }
    }

    private void MsgOnlyPlayerInventoryOpen()
    {
        if (GameManager.Instance.promotInventoryOpen == false & GameManager.Instance.chestInventoryOpen == false)
        {
            if (GameManager.Instance.onlyPlayerInventory == true)
            {
                PressI1.SetActive(false);
                PressI1_2.SetActive(true);
            }
            else
            {
                PressI1.SetActive(true);
                PressI1_2.SetActive(false);
            }
        }
        else
        {
            PressI1.SetActive(false);
            PressI1_2.SetActive(false);
        }

    }

    private void ShowPrice()
    {
        ArgentOwnedTotal.text = GameManager.Instance.argentOwned.ToString() + " U";
        InfoDayTxT.text = " Day " + GameManager.Instance.day.ToString();
        Price1.text = InputFields.Instance.input1.ToString() + " U";
        Price2.text = InputFields.Instance.input2.ToString() + " U";
        Price3.text = InputFields.Instance.input3.ToString() + " U";
        Price4.text = InputFields.Instance.input4.ToString() + " U";
    }

    private void InfoInGame()
    {
        if (GameManager.Instance.chestInventoryOpen == false & GameManager.Instance.promotInventoryOpen == false
            & GameManager.Instance.playerInventoryOpen == false & GameManager.Instance.dungeonChestInventoryOpen == false)
        {
            InfoDay.SetActive(true);
        }
        else
        { 
            InfoDay.SetActive(false); 
        }
    }
}
