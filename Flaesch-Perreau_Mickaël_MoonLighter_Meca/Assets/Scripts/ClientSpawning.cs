using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClientSpawning : MonoBehaviour
{
    [SerializeField] GameObject PrefabClient;
    [SerializeField] Transform ContainerClient;

    [SerializeField] int nbClientMax = 4;
    private float waitingTime = 2f;

    public bool OneSpawnByOneClient = false;

    // Update is called once per frame
    void Update()
    {
        SpawnerClient();
    }

    private void SpawnerClient()
    {
        if (GameManager.Instance.shopClosing == false & GameManager.Instance.HsDoorOpenToClient == true 
            & OneSpawnByOneClient == false & GameManager.Instance.noArticleInShop == false)
        {
            if (GameManager.Instance.nbClientInShop < nbClientMax & GameManager.Instance.nbClientMaxDay1 < 10)
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
            Instantiate(PrefabClient, ContainerClient);
            if (GameManager.Instance.day == 1) GameManager.Instance.nbClientMaxDay1 += 1;
            waitingTime = 5f;
        }
    }
}
