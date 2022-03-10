using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Promot_tapis : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            GameManager.Instance.interactIsPossible = true;
            GameManager.Instance.interactObject = "Promot_tapis";
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
