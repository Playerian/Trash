using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    #region Enemy_variables
    [SerializeField]
    private int health;
    private int currentHealth;
    private bool holdTrash;
    private Rigidbody2D enemRB;
    [SerializeField]
    private float speed;
    [SerializeField]
    [Tooltip("Speed to run when died")]
    private float dieSpeed;
    [SerializeField]
    [Tooltip("Time to disappear when died")]
    private float dieDelay;
    private Transform playerLocation;
    private Transform offScreen;
    private bool isAlive;
    [SerializeField]
    GameObject player;
    private Animator animator;
    private SpriteRenderer sr;


    #endregion

    private void Start()
    {
        playerLocation = GameObject.FindGameObjectWithTag("Player").transform;
        offScreen = GameObject.FindGameObjectWithTag("OFFSCREEN").transform;
        enemRB = GetComponent<Rigidbody2D>();
        currentHealth = health;
        isAlive = true;
        animator = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }
    #region racoonFunctions
    private void StealTrash()
    {
        transform.position = Vector2.MoveTowards(this.transform.position, playerLocation.position, speed * Time.deltaTime);
        animator.SetBool("isWalk", true);
        if(this.transform.position.x - playerLocation.position.x < 0)
        {
            sr.flipX = true;
        }
        else
        {
            sr.flipX = false;
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player") && isAlive)
        {
            collision.transform.GetComponent<PlayerController>().DropTrash(); 
            //decreaseHealth(1);
        }
    }
    private void Die()
    {
        //walk off screen then destroy gameobject

        gameObject.GetComponent<BoxCollider2D>().size = new Vector2();
        transform.position = Vector2.MoveTowards(this.transform.position, offScreen.position, dieSpeed * Time.deltaTime);
        sr.flipX = true;
        StartCoroutine(DieDelay());
        animator.SetBool("isWalk", true);

    }
    IEnumerator DieDelay()
    {
        yield return new WaitForSecondsRealtime(dieDelay);
        Destroy(gameObject);
        yield return null;
    }
    #endregion

    private void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        if(isAlive && player.transform.GetComponent<PlayerController>().hasTrash == true)
        {
            StealTrash();
        }

        if(isAlive == false)
        {
            Die();
        }
        else if(isAlive && player.transform.GetComponent<PlayerController>().hasTrash == false)
        {
            animator.SetBool("isWalk", false);
        }
    }

    public void decreaseHealth(int amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            isAlive = false;
        }
    }
}