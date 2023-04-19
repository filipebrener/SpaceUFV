using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{

    public float timeToStart = 0.7f;
    public float timeToClose = 0.7f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Close()
    {
        StartCoroutine(Wait(timeToClose, () => {
            Application.Quit();
        }));
    }

    public void Play()
    {
        Time.timeScale = 1;
        StartCoroutine(Wait(timeToStart, () => {
            SceneManager.LoadScene("Fase 1");
        }));
    }

    public void BackToMainMenu()
    {
        Time.timeScale = 1;
        StartCoroutine(Wait(timeToStart, () => {
            SceneManager.LoadScene("Menu");
        }));
    }

    IEnumerator Wait(float seconds, System.Action action)
    {
        yield return new WaitForSeconds(seconds);
        action();
    }
}
