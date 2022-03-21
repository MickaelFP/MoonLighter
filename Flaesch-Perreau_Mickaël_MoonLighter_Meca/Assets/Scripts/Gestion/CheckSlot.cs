using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckSlot : MonoBehaviour
{
    [SerializeField] GameObject ID01;
    [SerializeField] GameObject ID02;
    [SerializeField] GameObject ID03;
    [SerializeField] GameObject ID04;
    [SerializeField] GameObject ID05;
    [SerializeField] GameObject ID06;
    [SerializeField] GameObject ID07;
    [SerializeField] GameObject ID08;
    [SerializeField] GameObject ID09;

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

    public static CheckSlot Instance;
    private void Awake()
    {
        Instance = this;
    }

    void Update()
    {
        DetectingSlot();
        CheckNoArticleInShop();
        /*WhatShowInShop();
        WhatShowInInventory();
        WhatShowInChest();*/
    }

    private void DetectingSlot()
    {
        FillOrEmpty(ref GameManager.Instance.pSlot1ID , ref GameManager.Instance.pSlot1Empty);
        FillOrEmpty(ref GameManager.Instance.pSlot2ID, ref GameManager.Instance.pSlot2Empty);
        FillOrEmpty(ref GameManager.Instance.pSlot3ID, ref GameManager.Instance.pSlot3Empty);
        FillOrEmpty(ref GameManager.Instance.pSlot4ID, ref GameManager.Instance.pSlot4Empty);
        FillOrEmpty(ref GameManager.Instance.iSlot1ID, ref GameManager.Instance.iSlot1Empty);
        FillOrEmpty(ref GameManager.Instance.iSlot2ID, ref GameManager.Instance.iSlot2Empty);
        FillOrEmpty(ref GameManager.Instance.iSlot3ID, ref GameManager.Instance.iSlot3Empty);
        FillOrEmpty(ref GameManager.Instance.iSlot4ID, ref GameManager.Instance.iSlot4Empty);
        FillOrEmpty(ref GameManager.Instance.iSlot5ID, ref GameManager.Instance.iSlot5Empty);
        FillOrEmpty(ref GameManager.Instance.iSlot6ID, ref GameManager.Instance.iSlot6Empty);
        FillOrEmpty(ref GameManager.Instance.iSlot7ID, ref GameManager.Instance.iSlot7Empty);
        FillOrEmpty(ref GameManager.Instance.iSlot8ID, ref GameManager.Instance.iSlot8Empty);
        FillOrEmpty(ref GameManager.Instance.iSlot9ID, ref GameManager.Instance.iSlot9Empty);
        FillOrEmpty(ref GameManager.Instance.cSlot1ID, ref GameManager.Instance.cSlot1Empty);
        FillOrEmpty(ref GameManager.Instance.cSlot2ID, ref GameManager.Instance.cSlot2Empty);
        FillOrEmpty(ref GameManager.Instance.cSlot3ID, ref GameManager.Instance.cSlot3Empty);
        FillOrEmpty(ref GameManager.Instance.cSlot4ID, ref GameManager.Instance.cSlot4Empty);
        FillOrEmpty(ref GameManager.Instance.cSlot5ID, ref GameManager.Instance.cSlot5Empty);
        FillOrEmpty(ref GameManager.Instance.cSlot6ID, ref GameManager.Instance.cSlot6Empty);
        FillOrEmpty(ref GameManager.Instance.cSlot7ID, ref GameManager.Instance.cSlot7Empty);
        FillOrEmpty(ref GameManager.Instance.cSlot8ID, ref GameManager.Instance.cSlot8Empty);
        FillOrEmpty(ref GameManager.Instance.cSlot9ID, ref GameManager.Instance.cSlot9Empty);
    }

    private void FillOrEmpty(ref string parSlotID, ref bool parSlotVide)
    {
        if (parSlotID != "Default")
        {
            parSlotVide = false;
        }
        else parSlotVide = true;
    }

    public void SelledObjet()
    {
        CheckSelled1(ref GameManager.Instance.objet1OnSelling, ref GameManager.Instance.pSlot1ID);
        CheckSelled1(ref GameManager.Instance.objet2OnSelling, ref GameManager.Instance.pSlot2ID);
        CheckSelled1(ref GameManager.Instance.objet3OnSelling, ref GameManager.Instance.pSlot3ID);
        CheckSelled1(ref GameManager.Instance.objet4OnSelling, ref GameManager.Instance.pSlot4ID);
    }
    public void CheckSelled1(ref bool ObjetOnSelling, ref string PSlotID)
    {
        if (ObjetOnSelling == false)
        {
            CheckSelled2(ref PSlotID, "ID01", ID01);
            CheckSelled2(ref PSlotID, "ID02", ID02);
            CheckSelled2(ref PSlotID, "ID03", ID03);
            CheckSelled2(ref PSlotID, "ID04", ID04);
            CheckSelled2(ref PSlotID, "ID05", ID05);
            CheckSelled2(ref PSlotID, "ID06", ID06);
            CheckSelled2(ref PSlotID, "ID07", ID07);
            CheckSelled2(ref PSlotID, "ID08", ID08);
            CheckSelled2(ref PSlotID, "ID09", ID09);
        }
    }
    public void CheckSelled2(ref string PSlotID, string ObjetID, GameObject Objet)
    {
        if(PSlotID == ObjetID)
        {
            Objet.transform.position = new Vector3(0f, 0f, 0f);
        }
    }

    public void InHomeChest()
    {
        ObjetPos1("ID01", ID01);
        ObjetPos1("ID02", ID02);
        ObjetPos1("ID03", ID03);
        ObjetPos1("ID04", ID04);
        ObjetPos1("ID05", ID05);
        ObjetPos1("ID06", ID06);
        ObjetPos1("ID07", ID07);
        ObjetPos1("ID08", ID08);
        ObjetPos1("ID09", ID09);
    }

    private void ObjetPos1(string ObjetID, GameObject parID)
    {
        if (GameManager.Instance.iSlot1ID != ObjetID
        & GameManager.Instance.iSlot2ID != ObjetID
        & GameManager.Instance.iSlot3ID != ObjetID
        & GameManager.Instance.iSlot4ID != ObjetID
        & GameManager.Instance.iSlot5ID != ObjetID
        & GameManager.Instance.iSlot6ID != ObjetID
        & GameManager.Instance.iSlot7ID != ObjetID
        & GameManager.Instance.iSlot8ID != ObjetID
        & GameManager.Instance.iSlot9ID != ObjetID
        & GameManager.Instance.cSlot1ID != ObjetID
        & GameManager.Instance.cSlot2ID != ObjetID
        & GameManager.Instance.cSlot3ID != ObjetID
        & GameManager.Instance.cSlot4ID != ObjetID
        & GameManager.Instance.cSlot5ID != ObjetID
        & GameManager.Instance.cSlot6ID != ObjetID
        & GameManager.Instance.cSlot7ID != ObjetID
        & GameManager.Instance.cSlot8ID != ObjetID
        & GameManager.Instance.cSlot9ID != ObjetID) parID.SetActive(false);
        else parID.SetActive(true);
    }

    public void InPromot()
    {
        ObjetPos2("ID01", ID01);
        ObjetPos2("ID02", ID02);
        ObjetPos2("ID03", ID03);
        ObjetPos2("ID04", ID04);
        ObjetPos2("ID05", ID05);
        ObjetPos2("ID06", ID06);
        ObjetPos2("ID07", ID07);
        ObjetPos2("ID08", ID08);
        ObjetPos2("ID09", ID09);
    }
    private void ObjetPos2(string ObjetID, GameObject parID)
    {
        if (GameManager.Instance.iSlot1ID != ObjetID
        & GameManager.Instance.iSlot2ID != ObjetID
        & GameManager.Instance.iSlot3ID != ObjetID
        & GameManager.Instance.iSlot4ID != ObjetID
        & GameManager.Instance.iSlot5ID != ObjetID
        & GameManager.Instance.iSlot6ID != ObjetID
        & GameManager.Instance.iSlot7ID != ObjetID
        & GameManager.Instance.iSlot8ID != ObjetID
        & GameManager.Instance.iSlot9ID != ObjetID
        & GameManager.Instance.pSlot1ID != ObjetID
        & GameManager.Instance.pSlot2ID != ObjetID
        & GameManager.Instance.pSlot3ID != ObjetID
        & GameManager.Instance.pSlot4ID != ObjetID) parID.SetActive(false);
        else parID.SetActive(true);
    }

    public void InGame()
    {
        ObjetPos3("ID01", ID01);
        ObjetPos3("ID02", ID02);
        ObjetPos3("ID03", ID03);
        ObjetPos3("ID04", ID04);
        ObjetPos3("ID05", ID05);
        ObjetPos3("ID06", ID06);
        ObjetPos3("ID07", ID07);
        ObjetPos3("ID08", ID08);
        ObjetPos3("ID09", ID09);
    }
    private void ObjetPos3(string ObjetID, GameObject parID)
    {
        if (GameManager.Instance.iSlot1ID != ObjetID
        & GameManager.Instance.iSlot2ID != ObjetID
        & GameManager.Instance.iSlot3ID != ObjetID
        & GameManager.Instance.iSlot4ID != ObjetID
        & GameManager.Instance.iSlot5ID != ObjetID
        & GameManager.Instance.iSlot6ID != ObjetID
        & GameManager.Instance.iSlot7ID != ObjetID
        & GameManager.Instance.iSlot8ID != ObjetID
        & GameManager.Instance.iSlot9ID != ObjetID) parID.SetActive(false);
        else parID.SetActive(true);
    }

    private void CheckNoArticleInShop()
    {
        if (GameManager.Instance.pSlot1Empty & GameManager.Instance.pSlot2Empty & GameManager.Instance.pSlot3Empty
            & GameManager.Instance.pSlot4Empty) GameManager.Instance.noArticleInShop = true;
        else GameManager.Instance.noArticleInShop = false;
    }
}
