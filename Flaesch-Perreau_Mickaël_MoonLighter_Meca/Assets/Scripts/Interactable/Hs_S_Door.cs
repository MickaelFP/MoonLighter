using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hs_S_Door : MonoBehaviour
{
    [SerializeField] GameObject Player;
    [SerializeField] GameObject PlayerSpawnPoint;

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (tag != "DoorID2" & tag != "DoorID3" & tag != "DoorID4")
            {
                GameManager.Instance.interactIsPossible = true;
                GameManager.Instance.interactObject = "Hs_S_Door";
                GameManager.Instance.interactObjectID = tag;
            }
            else if (tag == "DoorID2")
            {
                Player.transform.position = PlayerSpawnPoint.transform.position;
                Gest_Visibility.Instance.HouseVisibility();
            }
            else if (tag == "DoorID3")
            {
                Player.transform.position = PlayerSpawnPoint.transform.position;
                Gest_Visibility.Instance.DongeonVisibility();
            }
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            GameManager.Instance.interactIsPossible = false;
            GameManager.Instance.interactObject = "Default";
            GameManager.Instance.interactObjectID = "Default";
        }
    }
}
