using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    #region Enemy_variables
    [SerializeField]
    private int health;
    private bool holdTrash;
    private Rigidbody2D enemRB;
    [SerializeField]
    private float speed;
    private Transform playerLocation;
    private Transform offScreen;
    private bool isAlive = true;
    [SerializeField]
    GameObject player;


    #endregion

    private void Start()
    {
        playerLocation = GameObject.FindGameObjectWithTag("Player").transform;
        offScreen = GameObject.FindGameObjectWithTag("OFFSCREEN").transform;
        enemRB = GetComponent<Rigidbody2D>();
    }
    #region racoonFunctions
    private void StealTrash()
    {
        transform.position = Vector2.MoveTowards(this.transform.position, playerLocation.position, speed * Time.deltaTime);
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
                collision.transform.GetComponent<PlayerController>().DropTrash(); 
        }
    }
    private void Die()
    {
        //walk off screen then destroy gameobject

        transform.position = Vector2.MoveTowards(this.transform.position, offScreen.position, speed * Time.deltaTime);
        DieDelay();

    }
    IEnumerator DieDelay()
    {
        yield return new WaitForSecondsRealtime(10);
        Destroy(this.gameObject);
    }
    #endregion

    private void Update()
    {
        if(player.transform.GetComponent<PlayerController>().hasTrash == true)
        {
            StealTrash();
        }

        if(isAlive == false)
        {
            Die();
        }
    }
}