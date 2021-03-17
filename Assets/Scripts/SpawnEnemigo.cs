using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemigo : MonoBehaviour {

    public GameObject Enemy1, Enemy2, Enemy3, cruz1, cruz2, cruz3;
  
    float randx;
    float randz;
    Vector3 whereToSpawn;
    public float spawnRatio1 = 5f, spawnRatio2= 8f, spawnRatio3= 6f;
    public float nextSpawn1 = 0f, nextSpawn2=40f, nextSpawn3=90f ;
    public float spawnDecrease1, spawnDecrease2, SpawnDecrease3;
   

     void FixedUpdate()


    {
        if (Time.timeSinceLevelLoad > nextSpawn1)
        {

            nextSpawn1 = Time.timeSinceLevelLoad + spawnRatio1;
            Spawner(Enemy1, cruz1);
            if (GameManager.Instance.sceneActual == "BoxingHard")
            {
                Spawner(Enemy1, cruz1);
                if (Time.timeSinceLevelLoad > 320)
                {
                    Spawner(Enemy1, cruz1);
                }
            }
            if (spawnRatio1 >= 1.3f)
            {
                spawnRatio1 = spawnRatio1 - spawnDecrease1;
            }
        }
        if (Time.timeSinceLevelLoad > nextSpawn2)
        {

            nextSpawn2 = Time.timeSinceLevelLoad + spawnRatio2;
            Spawner(Enemy2, cruz2);
            if (spawnRatio2 >= 3.3f)
            {
                spawnRatio2 = spawnRatio2 - spawnDecrease2;
            }
        }
        if (Time.timeSinceLevelLoad> nextSpawn3)
        {

            nextSpawn3 = Time.timeSinceLevelLoad + spawnRatio3;
            Spawner(Enemy3, cruz3);
            if (spawnRatio3 >= 4f)
            {
                spawnRatio3 = spawnRatio3 - SpawnDecrease3;
            }
        }
        

            
        }
    

    void Spawner(GameObject enemy, GameObject cruz)
    {
        print("Aparecio"+ enemy.name);
        randx = Random.Range(-17f, 17f);
        randz = Random.Range(-16f, 16f);
        whereToSpawn = new Vector3(randx, transform.position.y, randz);
        GameObject enemyClon= Instantiate(enemy, whereToSpawn, transform.rotation);
        Vector3 cruzWhere = new Vector3(randx, 0.3f, randz);
        Instantiate(cruz, cruzWhere, transform.rotation);

        GameManager.Instance.listaEnemigos.Add(enemyClon);

    }




    
}
