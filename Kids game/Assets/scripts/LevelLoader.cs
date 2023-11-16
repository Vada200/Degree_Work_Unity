using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
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


    public void ToMathGame_Hard()
    {
        StartCoroutine(LoadLevel(2));
    }
    public void ToMathGame_Easy()
    {
        StartCoroutine(LoadLevel(3));
    }

    public void ToWordGame_hard()
    {
        StartCoroutine(LoadLevel(4));
    }
    public void ToWordGame_easy()
    {
        StartCoroutine(LoadLevel(5));
    }

    public void ToMemoryGame_Easy()
    {
        StartCoroutine(LoadLevel(7));

    }

    public void ToMemoryGame_Hard()
    {
        StartCoroutine(LoadLevel(6));

    }

    public void TogameChooseScene()
    {
        StartCoroutine(LoadLevel(1));
    }

    public void ExitButton()
    {
        Application.Quit();
    }

    IEnumerator LoadLevel(int lvlIndex)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTimer);

        SceneManager.LoadScene(lvlIndex);
    }

}
