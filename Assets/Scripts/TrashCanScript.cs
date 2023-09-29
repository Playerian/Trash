using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashCanScript : MonoBehaviour
{
    #region
    [SerializeField]
    public GameObject explosion;
    #endregion
    // Start is called before the first frame update
    #region Can_Functions
    IEnumerator DestroyTrashCan() {
        yield return new WaitForSeconds(.3f);
        Instantiate(explosion, transform.position, transform.rotation);
    }
    public void Interact() {
        Debug.Log("hello");
        StartCoroutine("DestroyTrashCan");
    }
    #endregion
}
