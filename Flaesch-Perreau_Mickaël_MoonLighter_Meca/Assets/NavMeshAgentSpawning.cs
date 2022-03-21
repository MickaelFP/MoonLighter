using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshAgentSpawning : MonoBehaviour
{
    [SerializeField] Transform Sp1;
    [SerializeField] NavMeshAgent Agent;

    [SerializeField] int nbClientMax = 4;
    public int nbClientByTime = 0;

    private float waitingTime = 2f;

    public bool OneSpawnByOneClient = false;

    public static NavMeshAgentSpawning Instance;
    private void Awake()
    {
        Instance = this;
    }

    void Update()
    {
        SpawnerClient();
    }

    private void SpawnerClient()
    {
        if (GameManager.Instance.shopClosing == false & GameManager.Instance.HsDoorOpenToClient == true
            & OneSpawnByOneClient == false & GameManager.Instance.noArticleInShop == false)
        {
            if (GameManager.Instance.nbClientInShop < nbClientMax & nbClientByTime < GameManager.Instance.nbClientMaxDay1)
            {
                if (GameManager.Instance.firstClientSpawned == false) waitingTime = 2f;
                OneSpawnByOneClient = true;
                StartCoroutine(WaitAndStart1(waitingTime));
            }
        }
    }
    IEnumerator WaitAndStart1(float WaitingTime)
    {
        yield return new WaitForSeconds(WaitingTime);
        OneSpawnByOneClient = false;
        if (GameManager.Instance.HsDoorOpenToClient == true)
        {
            Instantiate(Agent, Sp1.position, Quaternion.identity);
            if (GameManager.Instance.day == 1) nbClientByTime += 1;
            waitingTime = 5f;
        }
    }
}
