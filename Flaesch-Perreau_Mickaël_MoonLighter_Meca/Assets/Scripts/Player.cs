using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] GameObject Hs_SpawnPoint;
    [SerializeField] GameObject Outside_SpawnPoint1;
    [SerializeField] GameObject Outside_SpawnPoint2;
    //[SerializeField] GameObject Dungeon_SpawnPoint1;

    [SerializeField] float playerSpeed = 1f;

    Rigidbody PlayerRgb;

    void Start()
    {
        PlayerRgb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        InteractionWithObject();
    }

    void FixedUpdate()
    {
        if (GameManager.Instance.playerCanMove == true) Deplacements();
    }


    public void Deplacements()
    {
        float speed = playerSpeed * Time.deltaTime;

        // Moving
        if (GameManager.Instance.gameState == "In Game" & GameManager.Instance.promotInventoryOpen == false)
        {
            if (Input.GetKey(KeyCode.Q) || Input.GetKey(KeyCode.LeftArrow))
            {
                if (Input.GetKey(KeyCode.Z) || Input.GetKey(KeyCode.UpArrow))
                {
                    PlayerRgb.MovePosition(transform.position + new Vector3(-1, 0, 1) * speed);
                }
                else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
                {
                    PlayerRgb.MovePosition(transform.position + new Vector3(-1, 0, -1) * speed);
                }
                else
                {
                    PlayerRgb.MovePosition(transform.position + new Vector3(-1, 0, 0) * speed);
                }
            }
            else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                if (Input.GetKey(KeyCode.Z) || Input.GetKey(KeyCode.UpArrow))
                {
                    PlayerRgb.MovePosition(transform.position + new Vector3(1, 0, 1) * speed);
                }
                else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
                {
                    PlayerRgb.MovePosition(transform.position + new Vector3(1, 0, -1) * speed);
                }
                else
                {
                    PlayerRgb.MovePosition(transform.position + new Vector3(1, 0, 0) * speed);
                }
            }
            else if (Input.GetKey(KeyCode.Z) || Input.GetKey(KeyCode.UpArrow))
            {
                PlayerRgb.MovePosition(transform.position + new Vector3(0, 0, 1) * speed);
            }
            else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            {
                PlayerRgb.MovePosition(transform.position + new Vector3(0, 0, -1) * speed);
            }
        }
    }

    public void InteractionWithObject()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if(GameManager.Instance.interactObject == "Promot_tapis" & GameManager.Instance.HsDoorOpenToClient == false)
            {
                if (GameManager.Instance.promotInventoryOpen == false) Gest_Visibility.Instance.PromotInventoryVisibility();
                else
                {
                    Gest_Visibility.Instance.HouseVisibility();
                }
            }
            if (GameManager.Instance.interactObject == "Home_Chest")
            {
                if (GameManager.Instance.chestInventoryOpen == false) Gest_Visibility.Instance.ChestInventoryVisibility();
                else Gest_Visibility.Instance.HouseVisibility();
            }
            if (GameManager.Instance.interactObject == "Hs_S_Door")
            {
                if (GameManager.Instance.interactObjectID == "DoorID1")
                {
                    if (GameManager.Instance.HsDoorOpenToClient == false)
                    {
                        if (GameManager.Instance.noArticleInShop != true)
                        {
                            Gest_Visibility.Instance.ShopOpenVisibility();
                        }
                    }
                    else GameManager.Instance.shopClosing = true;
                }
            }
            if (GameManager.Instance.interactObject == "CaisseE")
            {
                GameManager.Instance.argentToEncaisse = true;
            }
        }
        if (Input.GetKeyUp(KeyCode.E))
        {
            GameManager.Instance.argentToEncaisse = false;
        }

            if (Input.GetKeyDown(KeyCode.L))
        {
            if (GameManager.Instance.interactObject == "Hs_S_Door")
            {
                if (GameManager.Instance.interactObjectID == "DoorID1")
                {
                    if (GameManager.Instance.HsDoorOpenToClient == false)
                    {
                        Gest_Visibility.Instance.OutsideVisibility();
                        transform.position = Outside_SpawnPoint1.transform.position;
                    }
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.G))
        {
            //Debug.Log("ObjetMoving  " + GameManager.Instance.IObjetMoving);
            Debug.Log("pSlot1Empty  " + GameManager.Instance.pSlot1Empty);
            Debug.Log("objet1OnSelling  " + GameManager.Instance.objet1OnSelling);
            Debug.Log("pSlot2Empty  " + GameManager.Instance.pSlot2Empty);
            Debug.Log("objet2OnSelling  " + GameManager.Instance.objet2OnSelling);
            Debug.Log("               ");
        }
    }
}
