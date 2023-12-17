using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button_mng : MonoBehaviour
{
    // Start is called before the first frame update
    //public Animator transition;
    //public int transition_seconds = 1;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void quitGame()
    {
        Application.Quit();
        Debug.Log("Game is exiting");
    }

    public void gameChooseScene()
    {
        //StartCoroutine(loadLevelAnimation(1));
        SceneManager.LoadScene(1);
    }

    //IEnumerator loadLevelAnimation(int lvlIndex)
    //{
    //    transition.SetTrigger("Start");

    //    yield return new WaitForSeconds(transition_seconds);

    //    SceneManager.LoadScene(lvlIndex);
    //}

}
