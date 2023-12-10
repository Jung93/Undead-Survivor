using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{


    public Transform[] spawnPoints;
    public SpawnData[] spawnDatas;


    int level;
    float timer;

    private void Awake()
    {
        spawnPoints = GetComponentsInChildren<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        level = Mathf.Min( Mathf.FloorToInt(GameManager.instance.gameTime / 10f), spawnDatas.Length - 1);


        if (timer > spawnDatas[level].spawnTime) {
            timer = 0f;
            Spawn();
        }

    }


    void Spawn() { 
        GameObject enemy = GameManager.instance.pool.Get(0);

        enemy.transform.position = spawnPoints[Random.Range(1, spawnPoints.Length)].position;
        enemy.GetComponent<Enemy>().Init(spawnDatas[level]);
    }

}
[System.Serializable]
public class SpawnData{

    public int spriteType;
    public float spawnTime;
    public int health;
    public float speed;





}
