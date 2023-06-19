using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolScript : MonoBehaviour
{
    [SerializeField] GameObject enemy;
    [SerializeField] [Range(0,50)] int poolSize = 5;
    [SerializeField] [Range(0.1f, 30f)] float spawnTimer = 2f;

    GameObject[] actualPool;

    private void Awake()
    {
        PopulatePool();
    }

    private void PopulatePool()
    {
        actualPool = new GameObject[poolSize];

        for (int i = 0; i < actualPool.Length; i++)
        {
            actualPool[i] = Instantiate(enemy, transform);
            actualPool[i].SetActive(false);
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(EnemyInstatiation());
    }

    IEnumerator EnemyInstatiation()
    {
        while (true)
        {
            EnableObjectInPool();
            yield return new WaitForSeconds(spawnTimer);
        }
       
    }

    private void EnableObjectInPool()
    {
        foreach(GameObject enemyGameObject in actualPool)
        {
            if (!enemyGameObject.activeInHierarchy)
            {
                enemyGameObject.SetActive(true);
                return;
            }
        }
    }
}
