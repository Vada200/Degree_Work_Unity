using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class NumberGen : MonoBehaviour
{
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

    

    int num1 = 0;
    int num2 = 0;
    float result = 0;
    char[] ops = { '+', '-', '*', '/' };

    int guessesIndex = 0;



    void Start()
    {
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
                num2 = Random.Range(0, (100 - num1 + 1)); //num2 nem lehet 100-num1nél (pl 60 + 40) mert 100-nál több nem lehet
                result = num1 + num2;
                break;
            case '-':
                num1 = Random.Range(0, 100);
                num2 = Random.Range(0, num1 + 1); //num2 mindenképp csak kisebb lehet num1-nél mert ne legyen minusz (40-60)
                result = num1 - num2;
                break;
            case '*':
                num1 = Random.Range(1, 10);
                num2 = Random.Range(1, (100 / num1));
                //num 2 kevesebb mint 100 és meg kell legyen benne maradék nélkül
                result = num1 * num2;
                break;
            case '/':
                num2 = Random.Range(1, 10);
                num1 = num2 * Random.Range(1, 11); //num1 mindenképp nagyobb mint num1 és meg kell lennie maradék nélkül
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
            //Debug.Log("loss");
            //BadGuess();
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
        
        Debug.Log(guessesIndex);
        checkBoxes[guessesIndex].enabled = true;
        guessesIndex++;

        if (guessesIndex == 4)
        {
            //UnlockingAnimal();
        }


    }
}
