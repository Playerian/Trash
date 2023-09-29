using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerScript : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Spawning enemy")]
    private GameObject enemy;
    [SerializeField]
    [Tooltip("Spawn check wait time")]
    private float wait_time;

    private bool active;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnDelay());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnDelay()
    {
        while (true)
        {
            if (!GameObject.Find("Enemy") && !GameObject.Find("Enemy(Clone)"))
            {
                Instantiate(enemy, transform.position, transform.rotation);
            }
            yield return new WaitForSecondsRealtime(wait_time);
        }

    }
}
