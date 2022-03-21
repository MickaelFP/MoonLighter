using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopCaisseE : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            GameManager.Instance.interactIsPossible = true;
            GameManager.Instance.interactObject = "CaisseE";
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            GameManager.Instance.interactIsPossible = false;
            GameManager.Instance.interactObject = "Default";
        }
    }
}
