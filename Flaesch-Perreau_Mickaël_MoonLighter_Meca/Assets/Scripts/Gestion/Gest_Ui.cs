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
    [SerializeField] GameObject PressE3;
    [SerializeField] GameObject PressE3_2;
    [SerializeField] GameObject PressE4;

    [SerializeField] TextMeshPro ArgentOwnedTotal;

    [SerializeField] TextMeshPro Price1;
    [SerializeField] TextMeshPro Price2;
    [SerializeField] TextMeshPro Price3;
    [SerializeField] TextMeshPro Price4;

    void Update()
    {
        MsgInteractIsPossible();
        ShowPrice();
    }

    public void MsgInteractIsPossible()
    {
        if (GameManager.Instance.interactObject == "Promot_tapis" & GameManager.Instance.HsDoorOpenToClient == false)
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

        if (GameManager.Instance.interactObject == "Home_Chest")
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

        if (GameManager.Instance.interactObject == "Hs_S_Door")
        {
            if (GameManager.Instance.interactObjectID == "DoorID1")
            {
                if (GameManager.Instance.HsDoorOpenToClient == false)
                {
                    if (GameManager.Instance.noArticleInShop != true)
                    {
                        PressE2.SetActive(true);
                        PressE2_2.SetActive(false);
                        PressE2_3.SetActive(false);
                        PressE2_4.SetActive(false);
                    }
                    else
                    {
                        PressE2_4.SetActive(true);
                        PressE2.SetActive(false);
                        PressE2_2.SetActive(false);
                        PressE2_3.SetActive(false);
                    }

                }
                else
                {
                    if (GameManager.Instance.shopClosing == false)
                    {
                        PressE2_2.SetActive(true);
                        PressE2.SetActive(false);
                        PressE2_3.SetActive(false);
                        PressE2_4.SetActive(false);
                    }
                    else
                    {
                        PressE2_3.SetActive(true);
                        PressE2_2.SetActive(false);
                        PressE2.SetActive(false);
                        PressE2_4.SetActive(false);
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
        }

        if (GameManager.Instance.interactObject == "CaisseE")
        {
            if (GameManager.Instance.argentToEncaisse == false) PressE4.SetActive(true);
            else PressE4.SetActive(false);

        }
        else PressE4.SetActive(false);
    }

    private void ShowPrice()
    {
        ArgentOwnedTotal.text = GameManager.Instance.argentOwned.ToString() + " U";
        Price1.text = InputFields.Instance.input1.ToString() + " U";
        Price2.text = InputFields.Instance.input2.ToString() + " U";
        Price3.text = InputFields.Instance.input3.ToString() + " U";
        Price4.text = InputFields.Instance.input4.ToString() + " U";
    }
}
