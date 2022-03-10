using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SP_ContactClient : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Client")
        {
            GameManager.Instance.savePositionID = tag;
        }
    }
}
