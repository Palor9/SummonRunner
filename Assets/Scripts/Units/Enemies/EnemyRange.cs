using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRange : EnemyStats
{
    EnemyDirector EnemyDirector;

    public int numberToSpawn;
    public List<GameObject> spawnPool;

    [SerializeField]
    private float spawnRate = 10f;

    public EnemyRange()
    {
        Health = 50f;
        Armor = 10;
        Speed = 20;
        DMG = 5;
        DamageSpeed = 10f;
    }

    public void Awake()
    {
        EnemyDirector = GetComponent<EnemyDirector>();
    }

    public void Start()
    {
        StartCoroutine(Shoot());
    }

    IEnumerator Shoot()
    {
        int randomItem = 0;
        GameObject toSpawn;

        Vector2 pos;

        while (true)
        {
            for (int i = 0; i < numberToSpawn; i++)
            {
                randomItem = Random.Range(0, spawnPool.Count);
                toSpawn = spawnPool[randomItem];

                pos = EnemyDirector.transform.position;

                Instantiate(toSpawn, pos, toSpawn.transform.rotation);

                yield return new WaitForSeconds(spawnRate);
            }
        }
    }
}
