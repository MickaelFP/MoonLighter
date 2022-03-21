using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI_Client : MonoBehaviour
{
    [SerializeField] GameObject Hs_H_Door;
    [SerializeField] GameObject Hs_S_Door2;

    [SerializeField] GameObject CaisseWaitingPos;
    [SerializeField] GameObject CaisseWaitingPos2;
    [SerializeField] GameObject CaisseWaitingPos3;
    [SerializeField] GameObject CaisseWaitingPos4;

    [SerializeField] GameObject SavePos1;
    [SerializeField] GameObject SavePos2;
    [SerializeField] GameObject SavePos3;
    [SerializeField] GameObject SavePos4;
    [SerializeField] GameObject SavePos5;
    [SerializeField] GameObject SavePos6;
    [SerializeField] GameObject SavePos7;
    [SerializeField] GameObject SavePos8;
    [SerializeField] GameObject SavePos9;
    [SerializeField] GameObject SavePos10;
    [SerializeField] GameObject SavePos11;
    [SerializeField] GameObject SavePos12;

    [SerializeField] float StartSpeed = 1f;
    [SerializeField] float NormalSpeed = 1f;

    private bool startingSearchingObjet = false;
    public bool objet1Checked = false;
    public bool objet2Checked = false;
    public bool objet3Checked = false;
    public bool objet4Checked = false;
    private bool objetInHand = false;
    public bool leavingShop = false;
    public bool goingToPay = false;

    public int clientIDObjetSearching = 0;
    private int objetInHandValue = 0;
    private int objetContactID = 0;
    private int unit = 0;
    private int personalID = 0;
    //private int priceMax = 0;

    //float RandomTargetPosX;
    //float RandomTargetPosZ;

    bool step1 = false;
    bool step2 = false;
    bool step3 = false;
    bool step4 = false;
    bool step5 = false;
    bool step6 = false;
    bool step7 = false;
    bool step8 = false;
    bool step9 = false;
    bool step10 = false;
    bool step11 = false;
    bool step12 = false;
    bool step13 = false;
    bool step14 = false;
    //bool step15 = false;
    bool stepA = false;
    bool stepA2 = false;
    bool stepB = false;
    bool stepC = false;
    bool stepD1 = false;
    bool stepD2 = false;
    bool stepD3 = false;
    bool stepD4 = false;
    bool stepD5 = false;
    bool stepD6 = false;

    //public Transform goal;
    //NavMeshAgent agent;
    Rigidbody ClientRgb;

    void Start()
    {
        transform.position = new Vector3(-2.88f, 1f, -8f);
        //agent = GetComponent<NavMeshAgent>();
        ClientRgb = GetComponent<Rigidbody>();
        GameManager.Instance.nbClientInShop += 1;
        GameManager.Instance.firstClientSpawned = true;
        clientIDObjetSearching = Random.Range(1, 5);
        unit = Random.Range(20, 1000);
        GameManager.Instance.clientID += 1;
        personalID = GameManager.Instance.clientID;
        //priceMax = Random.Range(20, 1000);
    }

    void FixedUpdate()
    {
        if (GameManager.Instance.shopClosing == false)
        {
            EnteringFirstDeplacement();
            SearchingObjet();
            WaitingToPay();
        }
        else
        {
            if (goingToPay != true) leavingShop = true;
            else WaitingToPay();
        }
        ActualyLeavingShop();
        ActualyGoingToPay();
        DebuggerClient();
    }

    private void OnDestroy()
    {
        GameManager.Instance.nbClientInShop -= 1;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PromotID01") objetContactID = 1;
        if (other.tag == "PromotID02") objetContactID = 2;
        if (other.tag == "PromotID03") objetContactID = 3;
        if (other.tag == "PromotID04") objetContactID = 4;

        if (other.tag == "CWPID01") GameManager.Instance.cWP1ID = personalID;
        if (other.tag == "CWPID02") GameManager.Instance.cWP2ID = personalID;
        if (other.tag == "CWPID03") GameManager.Instance.cWP3ID = personalID;
        if (other.tag == "CWPID04") GameManager.Instance.cWP4ID = personalID;

        /*if (other.tag == "SPID01") GameManager.Instance.sP1ID = personalID;
        if (other.tag == "SPID02") GameManager.Instance.sP2ID = personalID;
        if (other.tag == "SPID03") GameManager.Instance.sP3ID = personalID;
        if (other.tag == "SPID04") GameManager.Instance.sP4ID = personalID;
        if (other.tag == "SPID05") GameManager.Instance.sP5ID = personalID;
        if (other.tag == "SPID06") GameManager.Instance.sP6ID = personalID;
        if (other.tag == "SPID07") GameManager.Instance.sP7ID = personalID;
        if (other.tag == "SPID08") GameManager.Instance.sP8ID = personalID;
        if (other.tag == "SPID09") GameManager.Instance.sP9ID = personalID;
        if (other.tag == "SPID10") GameManager.Instance.sP10ID = personalID;
        if (other.tag == "SPID11") GameManager.Instance.sP11ID = personalID;
        if (other.tag == "SPID12") GameManager.Instance.sP12ID = personalID;*/
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "SPID01") GameManager.Instance.sP1ID = personalID;
        if (other.tag == "SPID02") GameManager.Instance.sP2ID = personalID;
        if (other.tag == "SPID03") GameManager.Instance.sP3ID = personalID;
        if (other.tag == "SPID04") GameManager.Instance.sP4ID = personalID;
        if (other.tag == "SPID05") GameManager.Instance.sP5ID = personalID;
        if (other.tag == "SPID06") GameManager.Instance.sP6ID = personalID;
        if (other.tag == "SPID07") GameManager.Instance.sP7ID = personalID;
        if (other.tag == "SPID08") GameManager.Instance.sP8ID = personalID;
        if (other.tag == "SPID09") GameManager.Instance.sP9ID = personalID;
        if (other.tag == "SPID10") GameManager.Instance.sP10ID = personalID;
        if (other.tag == "SPID11") GameManager.Instance.sP11ID = personalID;
        if (other.tag == "SPID12") GameManager.Instance.sP12ID = personalID;
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "PID01" & objetContactID == 1) objetContactID = 0;
        if (other.tag == "PID02" & objetContactID == 2) objetContactID = 0;
        if (other.tag == "PID03" & objetContactID == 3) objetContactID = 0;
        if (other.tag == "PID04" & objetContactID == 4)  objetContactID = 0;
;
        if (other.tag == "CWPID01")
        {
            GameManager.Instance.cWP1ID = 0;
            GameManager.Instance.cWP1Reaching = 0;
        }
        if (other.tag == "CWPID02")
        {
            GameManager.Instance.cWP2ID = 0;
            GameManager.Instance.cWP2Reaching = 0;
        }
        if (other.tag == "CWPID03")
        {
            GameManager.Instance.cWP3ID = 0;
            GameManager.Instance.cWP3Reaching = 0;
        }
        if (other.tag == "CWPID04")
        {
            GameManager.Instance.cWP4ID = 0;
            GameManager.Instance.cWP4Reaching = 0;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == ("DoorID1")) Destroy(gameObject, 0f);
    }

    private void EnteringFirstDeplacement()
    {
        if (startingSearchingObjet == false)
        {
            step1 = true;
            float speedTemp = StartSpeed * Time.deltaTime;
            transform.Translate(0, 0, 1 * speedTemp, Space.World);
            //agent.destination = Hs_H_Door.transform.position;
            StartCoroutine(WaitAndStartSearching1(1f));
        }
    }
    IEnumerator WaitAndStartSearching1(float WaitingTime)
    {
        yield return new WaitForSeconds(WaitingTime);
        startingSearchingObjet = true;
        step2 = true;
    }

    private void SearchingObjet()
    {
        if (startingSearchingObjet == true & leavingShop == false & goingToPay == false)
        {
            // Droite, gauche, bas, haut
            step3 = true;
            CheckParcour(1, 2, ref objet1Checked, ref GameManager.Instance.objet1OnSelling, InputFields.Instance.price1,
                    SavePos4.transform.position, SavePos6.transform.position, SavePos8.transform.position, SavePos8.transform.position,
                    SavePos10.transform.position, SavePos8.transform.position, SavePos6.transform.position, SavePos6.transform.position,
                    ref GameManager.Instance.sP4ID, ref GameManager.Instance.sP8ID, ref GameManager.Instance.sP10ID, 
                    ref GameManager.Instance.sP6ID, ref GameManager.Instance.pSlot1Empty, ref GameManager.Instance.pSlot1ID);

            CheckParcour(2, 3, ref objet2Checked, ref GameManager.Instance.objet2OnSelling, InputFields.Instance.price2,
                    SavePos3.transform.position, SavePos3.transform.position, SavePos7.transform.position, SavePos5.transform.position,
                    SavePos1.transform.position, SavePos3.transform.position, SavePos5.transform.position, SavePos5.transform.position,
                    ref GameManager.Instance.sP3ID, ref GameManager.Instance.sP7ID, ref GameManager.Instance.sP1ID,
                    ref GameManager.Instance.sP5ID, ref GameManager.Instance.pSlot2Empty, ref GameManager.Instance.pSlot2ID);

            CheckParcour(3, 4, ref objet3Checked, ref GameManager.Instance.objet3OnSelling, InputFields.Instance.price3,
                    SavePos1.transform.position, SavePos11.transform.position, SavePos9.transform.position, SavePos9.transform.position,
                    SavePos11.transform.position, SavePos11.transform.position, SavePos7.transform.position, SavePos9.transform.position,
                    ref GameManager.Instance.sP1ID, ref GameManager.Instance.sP9ID, ref GameManager.Instance.sP11ID,
                    ref GameManager.Instance.sP7ID, ref GameManager.Instance.pSlot3Empty, ref GameManager.Instance.pSlot3ID);

            CheckParcour(4, 1, ref objet4Checked, ref GameManager.Instance.objet4OnSelling, InputFields.Instance.price4,
                    SavePos2.transform.position, SavePos2.transform.position, SavePos10.transform.position, SavePos12.transform.position,
                    SavePos12.transform.position, SavePos12.transform.position, SavePos4.transform.position, SavePos2.transform.position,
                    ref GameManager.Instance.sP2ID, ref GameManager.Instance.sP10ID, ref GameManager.Instance.sP12ID,
                    ref GameManager.Instance.sP4ID, ref GameManager.Instance.pSlot4Empty, ref GameManager.Instance.pSlot4ID);
        }
    }

    private void CheckParcour(int IDObjetSearching, int IDObjetSearchingNew, ref bool ObjetCheked, ref bool ObjetOnSelling, int InputPrice,
        Vector3 SavePos1, Vector3 SavePos1_2, Vector3 SavePos2, Vector3 SavePos2_2,
        Vector3 SavePos3, Vector3 SavePos3_2, Vector3 SavePos4, Vector3 SavePos4_2,
        ref int SPID_1, ref int SPID_2, ref int SPID_3, ref int SPID_4, ref bool pSlotEmpty,  ref string pSlotID)
    {
        step4 = true;
        if (clientIDObjetSearching == IDObjetSearching & objetInHand == false)
        {
            step5 = true;
            if (ObjetCheked == false)
            {
                step6 = true;
                //agent.destination = PromotPos;
                //transform.position = Vector3.MoveTowards(transform.position, PromotPos, speedTemp);
                //float damping = NormalSpeed * 10 * Time.deltaTime;

                if (transform.position.x >= -9f)
                {
                    step7 = true;
                    if (SPID_1 != personalID) 
                        transform.position = Vector3.MoveTowards(transform.position, SavePos1, StartSpeed * Time.deltaTime);
                    else transform.position = Vector3.MoveTowards(transform.position, SavePos1_2, StartSpeed * Time.deltaTime);
                }
                if (transform.position.x <= -15f)
                {
                    step8 = true;
                    if (SPID_2 != personalID) 
                        transform.position = Vector3.MoveTowards(transform.position, SavePos2, StartSpeed * Time.deltaTime);
                    else transform.position = Vector3.MoveTowards(transform.position, SavePos2_2, StartSpeed * Time.deltaTime);
                }
                if (transform.position.x <= -9 & transform.position.x >= -15f & transform.position.z <= -3.7f)
                {
                    step9 = true;
                    if (SPID_3 != personalID) 
                        transform.position = Vector3.MoveTowards(transform.position, SavePos3, StartSpeed * Time.deltaTime);
                    else transform.position = Vector3.MoveTowards(transform.position, SavePos3_2, StartSpeed * Time.deltaTime);
                }
                if (transform.position.x <= -9 & transform.position.x >= -15f & transform.position.z >= 2.3f)
                {
                    step10 = true;
                    if (SPID_4 != personalID) 
                        transform.position = Vector3.MoveTowards(transform.position, SavePos4, StartSpeed * Time.deltaTime);
                    else transform.position = Vector3.MoveTowards(transform.position, SavePos4_2, StartSpeed * Time.deltaTime);
                }

                if (objetContactID == IDObjetSearching)
                {
                    ObjetCheked = true;
                    clientIDObjetSearching = IDObjetSearchingNew;
                    ComparePrice(ref ObjetOnSelling, InputPrice, ref pSlotEmpty, ref pSlotID);
                }
            }
            else leavingShop = true;
        }
        else if (objetInHand == true) goingToPay = true;
    }

    private void ComparePrice(ref bool ObjetOnSelling,int InputPrice, ref bool pSlotEmpty, ref string pSlotID)
    {
        if (ObjetOnSelling == true)
        {
            if (InputPrice <= unit)
            {
                step11 = true;
                unit -= InputPrice;
                objetInHandValue = InputPrice;
                objetInHand = true;
                GameManager.Instance.nbObjetInHand += 1;
                ObjetOnSelling = false;
                pSlotEmpty = true;
                pSlotID = "Default";
            }
        }
    }

    private void ActualyLeavingShop()
    {
        if (leavingShop == true)
        {
            step12 = true;
            float speedTemp = NormalSpeed * Time.deltaTime;
            if (transform.position.x <= -15f & transform.position.z < 2.3f & GameManager.Instance.sP10ID != personalID) 
                transform.position = Vector3.MoveTowards(transform.position, SavePos10.transform.position, speedTemp);

            else if (transform.position.x <= -9 & transform.position.x >= -15f & transform.position.z >= 2.3f 
                & GameManager.Instance.sP4ID != personalID) 
                transform.position = Vector3.MoveTowards(transform.position, SavePos4.transform.position, speedTemp);

            else transform.position = Vector3.MoveTowards(transform.position, Hs_S_Door2.transform.position, speedTemp);
            //agent.destination = Hs_S_Door2.transform.position;
        }
    }

    private void ActualyGoingToPay()
    {
        if (goingToPay == true)
        {
            //agent.destination = CaisseWaitingPos.transform.position;
            step13 = true;
            CheckCaisseWaitingPos();
        }
    }

    private void CheckCaisseWaitingPos()
    {
        float speedTemp = NormalSpeed * Time.deltaTime;

        ChangingWaitingFillPos(GameManager.Instance.cWP1ID, GameManager.Instance.cWP1ID, ref GameManager.Instance.cWP1Reaching,
            CaisseWaitingPos.transform.position, CaisseWaitingPos.transform.position, ref stepA);
        ChangingWaitingFillPos(GameManager.Instance.cWP2ID, GameManager.Instance.cWP1ID, ref GameManager.Instance.cWP1Reaching,
            CaisseWaitingPos.transform.position, CaisseWaitingPos2.transform.position, ref stepA2);
        ChangingWaitingFillPos(GameManager.Instance.cWP3ID, GameManager.Instance.cWP2ID, ref GameManager.Instance.cWP2Reaching,
            CaisseWaitingPos2.transform.position, CaisseWaitingPos3.transform.position, ref stepB);
        ChangingWaitingFillPos(GameManager.Instance.cWP4ID, GameManager.Instance.cWP3ID, ref GameManager.Instance.cWP3Reaching,
            CaisseWaitingPos3.transform.position, CaisseWaitingPos4.transform.position, ref stepC);

        if (GameManager.Instance.cWP1ID != personalID & GameManager.Instance.cWP2ID != personalID 
            & GameManager.Instance.cWP3ID != personalID & GameManager.Instance.cWP4ID != personalID)
        {
            stepD1 = true;
            if (transform.position.x <= -15f & GameManager.Instance.sP10ID != personalID) 
                transform.position = Vector3.MoveTowards(transform.position, SavePos10.transform.position, speedTemp);
            else
            {
                stepD2 = true;
                if (GameManager.Instance.cWP1Reaching == 0 || GameManager.Instance.cWP1Reaching == personalID)
                    ReachingWaitingFill(ref GameManager.Instance.cWP1Reaching, CaisseWaitingPos.transform.position, ref stepD3);
                else if (GameManager.Instance.cWP2Reaching == 0 || GameManager.Instance.cWP2Reaching == personalID) 
                    ReachingWaitingFill(ref GameManager.Instance.cWP2Reaching, CaisseWaitingPos2.transform.position, ref stepD4);
                else if (GameManager.Instance.cWP3Reaching == 0 || GameManager.Instance.cWP3Reaching == personalID) 
                    ReachingWaitingFill(ref GameManager.Instance.cWP3Reaching, CaisseWaitingPos3.transform.position, ref stepD5);
                else if (GameManager.Instance.cWP4Reaching == 0 || GameManager.Instance.cWP4Reaching == personalID) 
                    ReachingWaitingFill(ref GameManager.Instance.cWP4Reaching, CaisseWaitingPos4.transform.position, ref stepD6);
            }
        }
    }
    private void ChangingWaitingFillPos(int CWPID, int CWPID2, ref int CWPReaching, Vector3 CWP1, Vector3 CWP2, ref bool Step)
    {
        if (CWPID == personalID)
        {
            float speedTemp = NormalSpeed * Time.deltaTime;
            if (CWPID2 == 0 || CWPID2 == personalID)
            {
                if (CWPReaching == 0 || CWPReaching == personalID)
                {
                    transform.position = Vector3.MoveTowards(transform.position, CWP1, speedTemp);
                    CWPReaching = personalID;
                    Step = true;
                }
            }
            else transform.position = Vector3.MoveTowards(transform.position, CWP2, speedTemp);
        }
    }
    private void ReachingWaitingFill(ref int CWPReaching, Vector3 CWP, ref bool Step)
    {
        float speedTemp = NormalSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, CWP, speedTemp);
        CWPReaching = personalID;
        Step = true;
    }

    private void WaitingToPay()
    {
        if (GameManager.Instance.shopClosing == false)
        {
            if (goingToPay == true & GameManager.Instance.cWP1ID == personalID)
            {
                if (GameManager.Instance.argentToEncaisse == true & objetInHandValue >= 0)
                {
                    GameManager.Instance.argentOwned += objetInHandValue;
                    GameManager.Instance.nbObjetInHand -= 1;
                    objetInHandValue = 0;
                    objetInHand = false;
                    goingToPay = false;
                    leavingShop = true;
                }
            }
        }
        else goingToPay = false;
    }

    public void DebuggerClient()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            Debug.Log("step1   " + step1);
            Debug.Log("step2   " + step2);
            Debug.Log("step3   " + step3);
            Debug.Log("step4   " + step4);
            Debug.Log("step5   " + step5);
            Debug.Log("step6   " + step6);
            Debug.Log("step7   " + step7);
            Debug.Log("step8   " + step8);
            Debug.Log("step9   " + step9);
            Debug.Log("step10  " + step10);
            Debug.Log("step11  " + step11);
            Debug.Log("step12  " + step12);
            Debug.Log("step13  " + step13);
            Debug.Log("step14  " + step14);
            Debug.Log("stepA  " + stepA);
            Debug.Log("stepB  " + stepB);
            Debug.Log("stepC  " + stepC);
            Debug.Log("stepD1  " + stepD1);
            Debug.Log("stepD2  " + stepD2);
            Debug.Log("stepD3  " + stepD3);
            Debug.Log("stepD3  " + stepD4);
            Debug.Log("stepD3  " + stepD5);
            Debug.Log("stepD3  " + stepD6);
        }
    
    }
}
