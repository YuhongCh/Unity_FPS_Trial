using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public int maxEnemyNum;
    public float spawnTime;
    public GameObject EnemyPrefab;
    public Transform roomTransform;
    private List <GameObject> EnemyList = new List<GameObject>();
    private Vector3 spawnRange;
    // Start is called before the first frame update
    void Start()
    {
        SpawnRangeCalculator();
        while (EnemyList.Count < maxEnemyNum)
        {
            GameObject enemy = Instantiate(EnemyPrefab, spawnRange, Quaternion.identity);
            EnemyList.Add(enemy);
        }
    }

    void SpawnRangeCalculator(){
        float temporaryScale = roomTransform.lossyScale.x / 2f;
        spawnRange.x = Random.Range(roomTransform.position.x - temporaryScale, roomTransform.position.x + temporaryScale);
        temporaryScale = roomTransform.lossyScale.z / 2f;
        spawnRange.z = Random.Range(roomTransform.position.z - temporaryScale, roomTransform.position.z + temporaryScale);
        spawnRange.y = roomTransform.position.y + 1f;
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < maxEnemyNum; i++)
        {
            if (EnemyList[i] == null) EnemyList[i] = Instantiate(EnemyPrefab, spawnRange, Quaternion.identity);
        }
        if (transform.position.y > 2) Debug.Log(transform.position);
    }
}
