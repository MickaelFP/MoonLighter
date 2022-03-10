using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Home_Chest : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            GameManager.Instance.interactIsPossible = true;
            GameManager.Instance.interactObject = "Home_Chest";
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
