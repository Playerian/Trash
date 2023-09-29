using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashSpawner : MonoBehaviour
{
    [SerializeField]
    public float totalTrash;
    [SerializeField]
    public float initialTrashSpawnTime;
    private float trashSpawnTimer;
    [SerializeField]
    public GameObject trashObject;
    // Start is called before the first frame update
    void Start()
    {
        trashSpawnTimer = initialTrashSpawnTime;
        Instantiate(trashObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (trashSpawnTimer <= 0 && totalTrash > 0) {
            Instantiate(trashObject);
            totalTrash -= 1;
            trashSpawnTimer = initialTrashSpawnTime;
        }
        else {
            trashSpawnTimer -= Time.deltaTime;
        }
    }

}
