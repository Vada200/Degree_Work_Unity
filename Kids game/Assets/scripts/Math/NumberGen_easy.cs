using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.IO;

public class NumberGen_easy : MonoBehaviour
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

    string secs;
    string mins;

    int num1 = 0;
    int num2 = 0;
    float result = 0;
    char[] ops = { '+', '-'};

    int guessesIndex = 0;

    int badGuess = 0;

    public string filepath;
    int unlockedAnimals=0;

    public void UnlockingAnimal()
    {
        string[] lines = File.ReadAllLines(filepath);
        unlockedAnimals = int.Parse(lines[1]);

        if (unlockedAnimals < 6)
        {
            
            unlockedAnimals++;
            lines[1] = unlockedAnimals.ToString();
        }
        else
        {
            unlockedAnimals = 6;
        }
        File.WriteAllLines(filepath, lines);
    }

    // Start is called before the first frame update
    void Start()
    {
        filepath = Application.dataPath + "/animalUnlocks.txt";
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

        answer.text = "??";
        RandomImage();
        int opIndex = Random.Range(0, ops.Length);
        char randomOp = ops[opIndex];

        switch (randomOp)
        {
            case '+':
                num1 = Random.Range(0, 30);
                num2 = Random.Range(0, (30 - num1 + 1)); //num2 nem lehet 50-num1nél (pl 10 + 20) mert 50-nál több nem lehet
                result = num1 + num2;
                break;
            case '-':
                num1 = Random.Range(0, 30);
                num2 = Random.Range(0, num1 + 1); //num2 mindenképp csak kisebb lehet num1-nél mert ne legyen minusz (30-10)
                result = num1 - num2;
                break;
            //case '*':
            //    num1 = Random.Range(1, 10);
            //    num2 = Random.Range(1, (100 / num1));
            //    //num 2 kevesebb mint 100 és meg kell legyen benne maradék nélkül
            //    result = num1 * num2;
            //    break;
            //case '/':
            //    num2 = Random.Range(1, 10);
            //    num1 = num2 * Random.Range(1, 11); //num1 mindenképp nagyobb mint num1 és meg kell lennie maradék nélkül
            //    result = num1 / num2;
            //    break;
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

        missesText.text = "Elrontott válaszok: " + badGuess;
        timeText.text = "Teljesítetted " + mins + " perc " + secs + " másodperc alatt";


    }

    IEnumerator TransToScore()
    {
        UnlockingAnimal();
        mins = GameObject.Find("TimePassed").GetComponent<TMP_Text>().text.Substring(0, 2);
        secs = GameObject.Find("TimePassed").GetComponent<TMP_Text>().text.Substring(4, 3);

        transToScoreboard.SetTrigger("ToScoreBegin");

        yield return new WaitForSeconds(1f);

        DeleteUI();

        transToScoreboard.SetTrigger("ToScoreEnd");

        ScoreUI();

    }
}
