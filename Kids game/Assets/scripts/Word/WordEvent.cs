using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class WordEvent : MonoBehaviour
{
    public TextMeshProUGUI randomThemeText;
    public TextMeshProUGUI randomWordText;

    public string[] animals;
    public string[] fruits;
    public string[] vegetables;
    void Start()
    {
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
                randomThemeText.text = "Gyümölcsök";
                randomWord(fruits);
                break;
            case 1:
                randomThemeText.text = "Állatok";
                randomWord(animals);
                break;
            case 2:
                randomThemeText.text = "Zöldségek";
                randomWord(vegetables);
                break;
        }
    }

    public void randomWord(string [] wordsArray)
    {
        int randWordIndex = Random.Range(0, wordsArray.Length);
        Debug.Log(wordsArray[randWordIndex]);
        //randomWordText.text = wordsArray[randWordIndex];

        //_---------------------------------------------------------------
        int randomLetterIndex = 0;
        int randomLetterIndex2 = 0;
        while (randomLetterIndex == randomLetterIndex2)
        {
            randomLetterIndex = Random.Range(0, wordsArray[randWordIndex].Length);
            randomLetterIndex2 = Random.Range(0, wordsArray[randWordIndex].Length);
        }
            if (wordsArray[randWordIndex].Length > 5)
            {

                randomWordText.text = wordsArray[randWordIndex].Remove(randomLetterIndex, 1).Insert(randomLetterIndex, "_").Remove(randomLetterIndex2, 1).Insert(randomLetterIndex2, "_");
            }
            else if (wordsArray[randWordIndex].Length <= 5)
            {
                randomWordText.text = wordsArray[randWordIndex].Remove(randomLetterIndex, 1).Insert(randomLetterIndex, "_");
            }
        
        



    }
    public void ArraysInit()
    {
        animals = new string[] {
            "Medve", "Macska", "Kutya", "Kígyó", "Elefánt", "Oroszlán", "Tigris", "Hattyú", "Orrszarvú", "Szarvas", "Zsiráf", "Róka", "Bagoly", "Pillangó", "Hernyó", "Egér",
            "Koala", "Panda", "Bárány", "Nyúl", "Papagáj", "Gólya", "Béka"};

        fruits = new string[]
        {
            "Alma", "Körte", "Szõlõ", "Banán", "Eper", "Cseresznye", "Szilva", "Citrom", "Ananász", "Málna", "Dinnye", "Barack", "Narancs", "Áfonya", "Szeder", "Kókusz"
        };

        vegetables = new string[]
        {
            "Uborka", "Répa", "Retek", "Káposzta", "Hagyma", "Borsó", "Paprika", "Paradicsom", "Karfiol", "Brokkoli", "Karalábé", "Kukorica", "Burgonya"
        };

    }
}
