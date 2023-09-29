using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    #region Movement_variables
    public float movespeed;
    float x_input;
    float y_input;
    Vector2 currDirection;
    #endregion

    #region Components
    private Rigidbody2D PlayerRB;
    #endregion

    #region Game_variables
    bool hasTrash;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        PlayerRB = GetComponent<Rigidbody2D>();
        hasTrash = false;
    }

    // Update is called once per frame
    void Update()
    {
        x_input = Input.GetAxisRaw("Horizontal");
        y_input = Input.GetAxisRaw("Vertical");
        Move();

    }

    #region Movement_functions
    private void Move()
    {
        PlayerRB.velocity = Vector2.zero;
        if (x_input > 0)
        {
            PlayerRB.velocity = Vector2.right * movespeed;
            currDirection = Vector2.right;
        }
        if (x_input < 0)
        {
            PlayerRB.velocity = Vector2.left * movespeed;
            currDirection = Vector2.left;
        }
        if (y_input > 0)
        {
            PlayerRB.velocity = Vector2.up * movespeed;
            currDirection = Vector2.up;
        }
        if (y_input < 0)
        {
            PlayerRB.velocity = Vector2.down * movespeed;
            currDirection = Vector2.down;
        }
    }
    #endregion

    #region Interact_functions 
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Trash"))
        {
            if (Input.GetKeyDown(KeyCode.Space) && !hasTrash)
            {
                hasTrash = true;
                pickUpTrash_Anim();
                GameObject trash = collision.gameObject;
                collision.transform.GetComponent<TrashScript>().gettingPickedUp(gameObject);
            }
        }
    }
    #endregion

    #region Animation_functions
    void pickUpTrash_Anim()
    {

    }
    #endregion
}
