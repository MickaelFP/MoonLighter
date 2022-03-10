using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IDPosInventory : MonoBehaviour
{
    [SerializeField] GameObject cSlot1;
    [SerializeField] GameObject cSlot2;
    [SerializeField] GameObject cSlot3;
    [SerializeField] GameObject cSlot4;
    [SerializeField] GameObject cSlot5;
    [SerializeField] GameObject cSlot6;
    [SerializeField] GameObject cSlot7;
    [SerializeField] GameObject cSlot8;
    [SerializeField] GameObject cSlot9;

    void Start()
    {
        StartPosition();
    }

    void StartPosition()
    {
        StartPositionByTag("ID01", ref GameManager.Instance.ID01OnSelling, cSlot1.transform.position, ref GameManager.Instance.cSlot1ID);
        StartPositionByTag("ID02", ref GameManager.Instance.ID02OnSelling, cSlot2.transform.position, ref GameManager.Instance.cSlot2ID);
        StartPositionByTag("ID03", ref GameManager.Instance.ID03OnSelling, cSlot3.transform.position, ref GameManager.Instance.cSlot3ID);
        StartPositionByTag("ID04", ref GameManager.Instance.ID04OnSelling, cSlot4.transform.position, ref GameManager.Instance.cSlot4ID);
        StartPositionByTag("ID05", ref GameManager.Instance.ID05OnSelling, cSlot5.transform.position, ref GameManager.Instance.cSlot5ID);
        StartPositionByTag("ID06", ref GameManager.Instance.ID06OnSelling, cSlot6.transform.position, ref GameManager.Instance.cSlot6ID);
        StartPositionByTag("ID07", ref GameManager.Instance.ID07OnSelling, cSlot7.transform.position, ref GameManager.Instance.cSlot7ID);
        StartPositionByTag("ID08", ref GameManager.Instance.ID08OnSelling, cSlot8.transform.position, ref GameManager.Instance.cSlot8ID);
        StartPositionByTag("ID09", ref GameManager.Instance.ID09OnSelling, cSlot9.transform.position, ref GameManager.Instance.cSlot9ID);
    }
    void StartPositionByTag(string parID, ref bool parIDEnVente, Vector3 parPosDepart, ref string SlotID)
    {
        if (tag == parID)
        {
            if (parIDEnVente == false)
            {
                transform.position = parPosDepart;
                SlotID = parID;
            }
        }
    }
}
