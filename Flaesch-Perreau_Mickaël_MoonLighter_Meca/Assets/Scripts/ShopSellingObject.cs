using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopSellingObject : MonoBehaviour
{
    [SerializeField] GameObject Objet1;
    [SerializeField] GameObject Objet2;
    [SerializeField] GameObject Objet3;
    [SerializeField] GameObject Objet4;
    [SerializeField] GameObject Objet5;
    [SerializeField] GameObject Objet6;
    [SerializeField] GameObject Objet7;
    [SerializeField] GameObject Objet8;
    [SerializeField] GameObject Objet9;

    [SerializeField] GameObject Objet1_1;
    [SerializeField] GameObject Objet2_1;
    [SerializeField] GameObject Objet3_1;
    [SerializeField] GameObject Objet4_1;
    [SerializeField] GameObject Objet5_1;
    [SerializeField] GameObject Objet6_1;
    [SerializeField] GameObject Objet7_1;
    [SerializeField] GameObject Objet8_1;
    [SerializeField] GameObject Objet9_1;

    [SerializeField] GameObject Objet1_2;
    [SerializeField] GameObject Objet2_2;
    [SerializeField] GameObject Objet3_2;
    [SerializeField] GameObject Objet4_2;
    [SerializeField] GameObject Objet5_2;
    [SerializeField] GameObject Objet6_2;
    [SerializeField] GameObject Objet7_2;
    [SerializeField] GameObject Objet8_2;
    [SerializeField] GameObject Objet9_2;

    [SerializeField] GameObject Objet1_3;
    [SerializeField] GameObject Objet2_3;
    [SerializeField] GameObject Objet3_3;
    [SerializeField] GameObject Objet4_3;
    [SerializeField] GameObject Objet5_3;
    [SerializeField] GameObject Objet6_3;
    [SerializeField] GameObject Objet7_3;
    [SerializeField] GameObject Objet8_3;
    [SerializeField] GameObject Objet9_3;

    void Update()
    {
        ObjetShow();
    }

    private void ObjetShow()
    {
        SlotShowing1("ID01", Objet1, Objet1_1, Objet1_2, Objet1_3);
        SlotShowing1("ID02", Objet2, Objet2_1, Objet2_2, Objet2_3);
        SlotShowing1("ID03", Objet3, Objet3_1, Objet3_2, Objet3_3);
        SlotShowing1("ID04", Objet4, Objet4_1, Objet4_2, Objet4_3);
        SlotShowing1("ID05", Objet5, Objet5_1, Objet5_2, Objet5_3);
        SlotShowing1("ID06", Objet6, Objet6_1, Objet6_2, Objet6_3);
        SlotShowing1("ID07", Objet7, Objet7_1, Objet7_2, Objet7_3);
        SlotShowing1("ID08", Objet8, Objet8_1, Objet8_2, Objet8_3);
        SlotShowing1("ID09", Objet9, Objet9_1, Objet9_2, Objet9_3);
    }

    private void SlotShowing1(string parID, GameObject parObjet, GameObject parObjet2, GameObject parObjet3, GameObject parObjet4)
    {
        if (GameManager.Instance.pSlot1ID == parID & GameManager.Instance.objet1OnSelling == true) parObjet.SetActive(true);
        else parObjet.SetActive(false);

        if (GameManager.Instance.pSlot2ID == parID & GameManager.Instance.objet2OnSelling == true) parObjet2.SetActive(true);
        else parObjet2.SetActive(false);

        if (GameManager.Instance.pSlot3ID == parID & GameManager.Instance.objet3OnSelling == true) parObjet3.SetActive(true);
        else parObjet3.SetActive(false);

        if (GameManager.Instance.pSlot4ID == parID & GameManager.Instance.objet4OnSelling == true) parObjet4.SetActive(true);
        else parObjet4.SetActive(false);
    }
}
