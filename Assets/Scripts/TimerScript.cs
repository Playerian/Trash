using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class TimerScript : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Setting the timer")]
    private float sec;
    private float currentTime;
    // Start is called before the first frame update
    void Start()
    {
        currentTime = sec;
        StartCoroutine(countdown()); ;
    }

    IEnumerator countdown()
    {
        while (currentTime > 0)
        {
            yield return new WaitForSeconds(1);
            currentTime -= 1;
            int second = (int) Mathf.Floor(currentTime);
            int minute = second / 60;
            second = second % 60;
            string time = "%M:%S".Replace("%S", second.ToString());
            time = time.Replace("%M", minute.ToString());
            gameObject.GetComponent<TextMeshProUGUI>().text = time;  
        }
        // Go back to main menu
        returnToMainMenu();
        yield return null;
    }

    void returnToMainMenu()
    {
        SceneManager.LoadScene("StartingScreen");
    }
}
