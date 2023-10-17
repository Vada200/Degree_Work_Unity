using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{

    public Animator transition;

    public float transitionTimer = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BackToMenu()
    {
        StartCoroutine(LoadLevel(0));
    }

    public void ToMathGame()
    {
        StartCoroutine(LoadLevel(2));
    }
    public void ToWordGame()
    {
        StartCoroutine(LoadLevel(3));
    }

    public void ToMemoryGame()
    {
        StartCoroutine(LoadLevel(4));
       
    }

    public void TogameChooseScene()
    {
        StartCoroutine(LoadLevel(1));
    }

    IEnumerator LoadLevel (int lvlIndex)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTimer);

        SceneManager.LoadScene(lvlIndex);
    }

}
