using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class WordEvent : MonoBehaviour
{

    public Image[] checkBoxes;
    public TextMeshProUGUI randomThemeText;
    public TextMeshProUGUI randomWordText;
    public TextMeshProUGUI helperText;
    public TMP_InputField answer;

    public string[] animals;
    public string[] fruits;
    public string[] vegetables;

    int guessesIndex = 0;
    void Start()
    {
        CheckboxReset();
        ArraysInit();
        nextWord();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void nextWord()
    {
        int randIndex = Random.Range(0, 3);

        switch (randIndex)
        {
            case 0:
                randomThemeText.text = "Gy�m�lcs�k";
                randomWord(fruits);
                break;
            case 1:
                randomThemeText.text = "�llatok";
                randomWord(animals);
                break;
            case 2:
                randomThemeText.text = "Z�lds�gek";
                randomWord(vegetables);
                break;
        }
    }

    public void randomWord(string [] wordsArray)
    {
        int randWordIndex = Random.Range(0, wordsArray.Length);
        //Debug.Log(wordsArray[randWordIndex]);
        //randomWordText.text = wordsArray[randWordIndex];

        //_---------------------------------------------------------------
        int randomLetterIndex = 0;
        int randomLetterIndex2 = 0;
        int randomLetterIndex3 = 0;
        while (randomLetterIndex == randomLetterIndex2 && randomLetterIndex2 == randomLetterIndex3 && randomLetterIndex == randomLetterIndex3)
        {
            randomLetterIndex = Random.Range(0, wordsArray[randWordIndex].Length);
            randomLetterIndex2 = Random.Range(0, wordsArray[randWordIndex].Length);
            randomLetterIndex3 = Random.Range(0, wordsArray[randWordIndex].Length);
        }
            if (wordsArray[randWordIndex].Length > 7)
            {
            helperText.text = wordsArray[randWordIndex];
            randomWordText.text = wordsArray[randWordIndex].Remove(randomLetterIndex, 1).Insert(randomLetterIndex, "_").Remove(randomLetterIndex2, 1).Insert(randomLetterIndex2, "_").Remove(randomLetterIndex3, 1).Insert(randomLetterIndex3, "_");
        }
            else if (wordsArray[randWordIndex].Length > 5 && wordsArray[randWordIndex].Length <= 7)
            {
            helperText.text = wordsArray[randWordIndex];
            randomWordText.text = wordsArray[randWordIndex].Remove(randomLetterIndex, 1).Insert(randomLetterIndex, "_").Remove(randomLetterIndex2, 1).Insert(randomLetterIndex2, "_");
            }
            else if (wordsArray[randWordIndex].Length <= 5)
            {
            helperText.text = wordsArray[randWordIndex];
            randomWordText.text = wordsArray[randWordIndex].Remove(randomLetterIndex, 1).Insert(randomLetterIndex, "_");
            }
        
    }
    public void ArraysInit()
    {
        animals = new string[] {
            "Medve", "Macska", "Kutya", "K�gy�", "Elef�nt", "Oroszl�n", "Tigris", "Hatty�", "Orrszarv�", "Szarvas", "Zsir�f", "R�ka", "Bagoly", "Pillang�", "Herny�", "Eg�r",
            "Koala", "Panda", "B�r�ny", "Ny�l", "Papag�j", "G�lya", "B�ka"};

        fruits = new string[]
        {
            "Alma", "K�rte", "Sz�l�", "Ban�n", "Eper", "Cseresznye", "Szilva", "Citrom", "Anan�sz", "M�lna", "Dinnye", "Barack", "Narancs", "�fonya", "Szeder", "K�kusz"
        };

        vegetables = new string[]
        {
            "Uborka", "R�pa", "Retek", "K�poszta", "Hagyma", "Bors�", "Paprika", "Paradicsom", "Karfiol", "Brokkoli", "Karal�b�", "Kukorica", "Burgonya"
        };

    }

    public void CheckingAnswer()
    {
        if (answer.text == helperText.text)
        {
            //Debug.Log("Helyes");
            GoodGuess();
        }
        else
        {
            //Debug.Log("R�sz");
        }
    }
    public void CheckboxReset()
    {
        foreach (Image a in checkBoxes)
        {
            a.enabled = false;
        }
    }

    public void GoodGuess()
    {
        Debug.Log("guessesIndex: "+ guessesIndex);
        nextWord();
        answer.text = "V�lasz";

        checkBoxes[guessesIndex].enabled = true;
        guessesIndex++;
    }
    
}
