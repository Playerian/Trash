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
    public bool hasTrash;
    private GameObject trash;
    [SerializeField]
    [Tooltip("Spawning explosion")]
    private GameObject explosion;
    private Animator anim;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        PlayerRB = GetComponent<Rigidbody2D>();
        hasTrash = false;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        x_input = Input.GetAxisRaw("Horizontal");
        y_input = Input.GetAxisRaw("Vertical");
        Move();
        if (Input.GetKeyDown(KeyCode.Space)) {
            Interact();
        }

    }

    #region Movement_functions
    private void Move()
    {
        PlayerRB.velocity = Vector2.zero;
        if (x_input > 0)
        {
            PlayerRB.velocity = Vector2.right * movespeed;
            currDirection = Vector2.right;
            anim.SetInteger("walk_int", 1);
        }
        if (x_input < 0)
        {
            PlayerRB.velocity = Vector2.left * movespeed;
            currDirection = Vector2.left;
            anim.SetInteger("walk_int", 3);
        }
        if (y_input > 0)
        {
            PlayerRB.velocity = Vector2.up * movespeed;
            currDirection = Vector2.up;
            anim.SetInteger("walk_int", 0);
        }
        if (y_input < 0)
        {
            PlayerRB.velocity = Vector2.down * movespeed;
            currDirection = Vector2.down;
            anim.SetInteger("walk_int", 2);
        }
    }
    #endregion

    #region Interact_functions 
    private void Interact() {
        RaycastHit2D[] hits = Physics2D.BoxCastAll(PlayerRB.position + currDirection, new Vector2(0.5f, 0.5f), 0f, Vector2.zero, 0f);
        foreach (RaycastHit2D hit in hits) {
            if (hit.transform.CompareTag("Trash") && !hasTrash) {
                hasTrash = true;
                pickUpTrash_Anim();
                // GameObject trash = collision.gameObject;
                hit.transform.GetComponent<TrashScript>().gettingPickedUp(gameObject);
                trash = hit.transform.gameObject;
            }
            if (hit.transform.CompareTag("Can") && hasTrash)
            {
                hasTrash = false;
                throwTrash_Anim();
                hit.transform.GetComponent<TrashCanScript>().Interact();
                Destroy(trash);
            }
        }
    }
    #endregion

    #region Animation_functions
    void pickUpTrash_Anim()
    {

    }
    void throwTrash_Anim() {

    }
    #endregion

    public void DropTrash()
    {
        if (hasTrash)
        {
            hasTrash = false;
            Instantiate(explosion, trash.transform.position, trash.transform.rotation);
            Destroy(trash);
        }
    }
}
