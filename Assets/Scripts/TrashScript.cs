using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashScript : MonoBehaviour
{
    #region Following variables
    public bool isHeld;
    public bool isExploded;
    #endregion


    #region Player Object
    private GameObject player;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        float x_pos = Random.Range(-10f, 10f);
        float y_pos = Random.Range(-5f, 5f);
        transform.position = new Vector3(x_pos, y_pos, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (isHeld)
        {
            // print("yes1");
            transform.position = player.transform.position + new Vector3(1,1);
        }
        if (isExploded)
        {
            Destroy(this.gameObject);
        }
    }

    public void gettingPickedUp(GameObject playerObject)
    {
        // print("yes2");
        isHeld = true;
        player = playerObject;
    }
}
