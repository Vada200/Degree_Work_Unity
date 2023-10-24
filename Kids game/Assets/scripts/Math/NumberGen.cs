using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class NumberGen : MonoBehaviour
{
    
    public Animator transToScoreboard;
    public GameObject scoreUI;

    public Image[] checkBoxes;
    public TextMeshProUGUI num1Text;
    public TextMeshProUGUI num2Text;
    public TextMeshProUGUI opText;
    public TextMeshProUGUI helperText;
    public InputField answer;

    public Image randPicFirst;
    public Image randPicSec;
    public Image randPicThird;

    public Sprite[] randPicSprites;

    string timePassed;

    int num1 = 0;
    int num2 = 0;
    float result = 0;
    char[] ops = { '+', '-', '*', '/' };

    int guessesIndex = 0;

    int badGuess = 0;


    void Start()
    {
        scoreUI.active = false;
        CheckboxReset();
        GenerateRandomEqu();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void CheckboxReset()
    {
        foreach (Image a in checkBoxes)
        {
            a.enabled = false;
        }
    }

    public void GenerateRandomEqu()
    {
        
        answer.text = "00";
        RandomImage();
        int opIndex = Random.Range(0, ops.Length);
        char randomOp = ops[opIndex];

        switch (randomOp)
        {
            case '+':
                num1 = Random.Range(0, 100);
                num2 = Random.Range(0, (100 - num1 + 1)); //num2 nem lehet 100-num1n�l (pl 60 + 40) mert 100-n�l t�bb nem lehet
                result = num1 + num2;
                break;
            case '-':
                num1 = Random.Range(0, 100);
                num2 = Random.Range(0, num1 + 1); //num2 mindenk�pp csak kisebb lehet num1-n�l mert ne legyen minusz (40-60)
                result = num1 - num2;
                break;
            case '*':
                num1 = Random.Range(1, 10);
                num2 = Random.Range(1, (100 / num1));
                //num 2 kevesebb mint 100 �s meg kell legyen benne marad�k n�lk�l
                result = num1 * num2;
                break;
            case '/':
                num2 = Random.Range(1, 10);
                num1 = num2 * Random.Range(1, 11); //num1 mindenk�pp nagyobb mint num1 �s meg kell lennie marad�k n�lk�l
                result = num1 / num2;
                break;
        }

        num1Text.text = num1.ToString();
        num2Text.text = num2.ToString();
        opText.text = randomOp.ToString();

        helperText.text = result.ToString();
    }



    public void guessNum()
    {
        if (answer.text == helperText.text)
        {
            //Debug.Log("win");
            GoodGuess();
        }
        else
        {
            badGuess++;
        }

        GenerateRandomEqu();

    }

    public void RandomImage()
    {
        int randPicIndex = Random.Range(0, randPicSprites.Length);
        //Debug.Log(randPicIndex);
        randPicFirst.sprite = randPicSprites[randPicIndex];
        randPicSec.sprite = randPicSprites[randPicIndex];
        randPicThird.sprite = randPicSprites[randPicIndex];
    }

    public void GoodGuess()
    {
        
        if (guessesIndex < 4)
        {
            Debug.Log(guessesIndex);
            checkBoxes[guessesIndex].enabled = true;
            guessesIndex++;
        }
        else
        {
            StartCoroutine(TransToScore());
        }


    }

    public void DeleteUI()
    {

        GameObject.Find("Guesses").active = false;
        GameObject.Find("Equation").active = false;
        GameObject.Find("TimePassed").active = false;
    }

    public void ScoreUI()
    {

        scoreUI.active = true;

        TMP_Text missesText = GameObject.Find("Misses").GetComponent<TMP_Text>();
        TMP_Text timeText = GameObject.Find("Time").GetComponent<TMP_Text>();

        missesText.text = "Wrong answers: "+ badGuess;
        timeText.text = "Time: " + timePassed;


    }

    IEnumerator TransToScore()
    {

        timePassed = GameObject.Find("TimePassed").GetComponent<TMP_Text>().text;

        transToScoreboard.SetTrigger("ToScoreBegin");

        yield return new WaitForSeconds(1f);

        DeleteUI();

        transToScoreboard.SetTrigger("ToScoreEnd");

        ScoreUI();

    }
}
