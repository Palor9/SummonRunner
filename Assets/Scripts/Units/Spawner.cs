using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public int numberToSpawn;
    public List<GameObject> spawnPool;
    private Camera _mainCamera;

    [SerializeField]
    private float spawnRate = 10f;
    [SerializeField]
    private bool isGameActive = true;


    public void Awake()
    {
        _mainCamera = GetComponent<Camera>();
    }

    void Start()
    {
        StartCoroutine(SpawnObjects());
    }

    IEnumerator SpawnObjects()
    {
        int randomItem = 0;
        GameObject toSpawn;

        while (isGameActive)
        {
            for (int i = 0; i < numberToSpawn; i++)
            {
                randomItem = UnityEngine.Random.Range(0, spawnPool.Count);
                toSpawn = spawnPool[randomItem];

                Vector3 bottomLeftWorld = _mainCamera.ViewportToWorldPoint(new Vector3(0, 0, _mainCamera.nearClipPlane));
                Vector3 topRightWorld = _mainCamera.ViewportToWorldPoint(new Vector3(1, 1, _mainCamera.nearClipPlane));

                Instantiate(toSpawn, new Vector2(UnityEngine.Random.Range(bottomLeftWorld.x, topRightWorld.x), topRightWorld.y), Quaternion.identity);
                Debug.Log($"Spawned another bastard Current time is {DateTime.Now}");

                yield return new WaitForSeconds(spawnRate);
            }
        }
    }
}
