using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.IO;

public class WordEvent : MonoBehaviour
{
    public Animator transToScoreboard;
    public GameObject scoreUI;

    public Image[] checkBoxes;
    public TextMeshProUGUI randomThemeText;
    public TextMeshProUGUI randomWordText;
    public TextMeshProUGUI helperText;
    public TMP_InputField answer;

    public TextMeshProUGUI timerText;

    public string[] animals;
    public string[] fruits;
    public string[] vegetables;

    //bool isTheSame = false;
    int missedLetters = 0;
    //-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    private float countdownTime = 8.0f;
    private float currentTime;
    private bool isCounting = false;

    private IEnumerator countdownCoroutine;


    //-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

    int goodGuessesIndex = 0;

    public string filepath;
    int unlockedAnimals;

    public void UnlockingAnimal()
    {
        string[] lines = File.ReadAllLines(filepath);
        if (unlockedAnimals <= 6)
        {
            unlockedAnimals = int.Parse(lines[1]);
            unlockedAnimals++;
            lines[1] = unlockedAnimals.ToString();
        }
        File.WriteAllLines(filepath, lines);
    }
    void Start()
    {

        filepath = Application.dataPath + "/TextFile/animalUnlocks.txt";
        //-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        //resetButton.onClick.AddListener(ResetTimer);
        ResetTimer();
        currentTime = countdownTime;
        UpdateUI();
        //-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        //StartCoroutine(CountDown());
        CheckboxReset();
        ArraysInit();
        nextWord();
        
    }

    // Update is called once per frame
    void Update()
    {//-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        

            if (currentTime <= 0)
            {
            missedLetters++;
            currentTime = 0;
                isCounting = false;
            nextWord();
            }

            UpdateUI();
        
    }
    void UpdateUI()
    {
        timerText.text = currentTime.ToString("0");
    }

    void ResetTimer()
    {
        if (countdownCoroutine != null)
        {
            StopCoroutine(countdownCoroutine);
        }

        currentTime = countdownTime;
        UpdateUI();

        countdownCoroutine = StartCountdown();
        StartCoroutine(countdownCoroutine);
    }
    
    IEnumerator StartCountdown()
    {
        isCounting = true;
        while (currentTime > 0)
        {
            yield return new WaitForSeconds(1);
            currentTime--;
            UpdateUI();
        }

        isCounting = false;
    }
    //-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

    //IEnumerator CountDown()
    //{
    //    int countdownFrom = 8;
    //    Debug.Log("CountDown()");

    //    while (countdownFrom > 0)
    //    {
    //        yield return new WaitForSeconds(1f);
    //        countdownFrom--;
    //        timerText.text = countdownFrom.ToString("D");
    //    }

    //    if (countdownFrom == 0)
    //    {
    //        nextWord();
    //    }
    //}

    public void nextWord()
    {
        ResetTimer();
        //countdownFrom = 5;

        //StartCoroutine(CountDown());

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
            "Medve", "Macska", "Kutya", "Kígyó", "Elefánt", "Oroszlán", "Tigris", "Hattyú", "Orrszarvú", "Szarvas", "Zsiráf", "Róka", "Bagoly", "Pillangó", "Hernyó", "Egér",
            "Koala", "Panda", "Bárány", "Nyúl", "Papagáj", "Gólya", "Béka"};

        fruits = new string[]
        {
            "Alma", "Körte", "Ribizli", "Banán", "Eper", "Cseresznye", "Szilva", "Citrom", "Ananász", "Málna", "Dinnye", "Barack", "Narancs", "Áfonya", "Szeder", "Kókusz"
        };

        vegetables = new string[]
        {
            "Uborka", "Répa", "Retek", "Káposzta", "Hagyma", "Borsó", "Paprika", "Paradicsom", "Karfiol", "Brokkoli", "Karalábé", "Kukorica", "Burgonya"
        };

    }

    public bool SlicingWords(string a, string b)
    {
        bool localCheck = false;
        Debug.Log("Slice beg");
        char[] answerLetters = a.ToCharArray();
        char[] helperLetters = b.ToCharArray();

        //isTheSame = false;
        if (answerLetters.Length != helperLetters.Length)
        {

            //isTheSame = false;
            localCheck = false;
        }
        else
        {
            for (int i = 0; i < answerLetters.Length; i++)
            {
                if (answerLetters[i] != helperLetters[i])
                {
                    missedLetters++;

                    //isTheSame = false;
                    localCheck = false;
                }
                else
                {
                    //isTheSame = true;
                    localCheck = true;
                }
            }

        }

        return localCheck;
    }

    public void CheckingAnswer()
    {
        ResetTimer();
        //Debug.Log("CheckingAnswer()-----------------------------------------------------");
        //SlicingWords(answer.text, helperText.text);
        bool result = answer.text.ToUpper() == helperText.text.ToUpper();

      //  if (SlicingWords(answer.text, helperText.text) == true)
        if(result)
        {

            GoodGuess();

        }
        else
        {
            missedLetters++;
        }

        //ebug.Log("missedLetters: "+missedLetters);
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
        //Debug.Log("Goodguess()");
        //Debug.Log("guessesIndex: "+ guessesIndex);
        nextWord();
        answer.text = "Írd ide...";

        checkBoxes[goodGuessesIndex].enabled = true;
        goodGuessesIndex++;

        if (goodGuessesIndex == 4)
        {
            StartCoroutine(TransToScore());

        }

    }

    public void DeleteUI()
    {

        GameObject.Find("CheckButton").active = false;
        GameObject.Find("GreenChecks").active = false;
        GameObject.Find("Texts").active = false;
        GameObject.Find("CountDown").active = false;
    }

    public void ScoreUI()
    {
        scoreUI.active = true;

        TMP_Text wrongLetters = GameObject.Find("Letters").GetComponent<TMP_Text>();

        wrongLetters.text = "Eltévesztett szavak: " + missedLetters;
    }

    IEnumerator TransToScore()
    {
        UnlockingAnimal();
        transToScoreboard.SetTrigger("ToScoreBegin");

        yield return new WaitForSeconds(1f);

        DeleteUI();

        transToScoreboard.SetTrigger("ToScoreEnd");

        ScoreUI();
    }

 }
