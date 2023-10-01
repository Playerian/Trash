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
    [SerializeField]
    [Tooltip("Spawn enemy sprites")]
    private List<Sprite> spriteList;

    // Start is called before the first frame update
    void Start()
    {
        trashSpawnTimer = initialTrashSpawnTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (trashSpawnTimer <= 0 && totalTrash > 0) {
            GameObject trash = Instantiate(trashObject);
            trash.GetComponent<SpriteRenderer>().sprite = spriteList[Random.Range(0, spriteList.Count)];
            totalTrash -= 1;
            trashSpawnTimer = initialTrashSpawnTime;
        }
        else {
            trashSpawnTimer -= Time.deltaTime;
        }
    }

}