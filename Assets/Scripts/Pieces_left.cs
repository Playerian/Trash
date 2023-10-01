using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Pieces_left : MonoBehaviour
{
    public int piecesLeft = 5;
    public TextMeshProUGUI textmeshpro;
    

    private void Start()
    {
        textmeshpro = gameObject.GetComponent<TextMeshProUGUI>();
        textmeshpro.text = ("Pieces left:" + piecesLeft.ToString());
    }
    public void ChangeText()
    {
        piecesLeft -= 1;
        textmeshpro.text = ("Pieces left:" + piecesLeft.ToString());
        if(piecesLeft == 0)
        {
            SceneManager.LoadScene("WinScreen");
        }
    }

    
    
}
