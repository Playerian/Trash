using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashScript : MonoBehaviour
{
    #region Following variables
    public bool isHeld;
    #endregion

    #region Player Object
    private GameObject player;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isHeld)
        {
            print("yes1");
            transform.position = player.transform.position + new Vector3(1,1);
        }
    }

    public void gettingPickedUp(GameObject playerObject)
    {
        print("yes2");
        isHeld = true;
        player = playerObject;
    }
}
