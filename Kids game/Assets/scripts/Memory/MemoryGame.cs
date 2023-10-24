using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class MemoryGame : MonoBehaviour
{
    // Start is called before the first frame update

    public Animator transToScoreboard;
    public GameObject scoreUI;

    public Sprite cardBack;

    public Transform CardBacks;

    public Sprite[] pics;

    public List<Sprite> cardFronts = new List<Sprite>();

    public GameObject cards;

    public List<Button> buttons = new List<Button>();

    int numberOfCards = 20;

    private bool firstGuess, secondGuess;

    private int countGuesses;
    private int countCorretGuesses;
    private int gameGuesses;

    private string firstGuessCard, secondGuessCard;
    private int firstGuessIndex, secondGuessIndex;

    public void GetPics()
    {
        pics = Resources.LoadAll<Sprite>("Pieces");
    }

    private void Awake()
    {
        GetPics();

        for (int i = 0; i < numberOfCards; i++)
        {
            GameObject guard = Instantiate(cards);
            guard.name = "Card" + i;
            guard.transform.SetParent(CardBacks, false);
        }
    }
    void Start()
    {
        GetButtons();
        AddListener();
        AddPicturesToCard();
        RandomiseCards(cardFronts);

        gameGuesses = cardFronts.Count / 2;
        //1 db guess 2 lap felford�t�s�val j�r
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetButtons()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Cards");

        for (int i = 0; i < objs.Length; i++)
        {
            buttons.Add(objs[i].GetComponent<Button>());
            buttons[i].image.sprite = cardBack;
        }
    }

    public void AddListener()
    {
        foreach (Button b in buttons)
        {
            b.onClick.AddListener(() => CardOnClick());
        }
    }

    public void AddPicturesToCard()
    {
        int splittingButtons = buttons.Count;
        int index = 0;

        for (int i = 0; i < splittingButtons; i++)
        {
            if (index == 10)
            {
                index = 0;
            }

            cardFronts.Add(pics[index]);

            index++;
        }
        //Ha a fel�ig elment a k�p mennyis�gnek akkor el�r�l kezdi, �gy mindenk�pp esz mindenkinek p�rja de csak az els� (buttons.Count/2) elemnek
    }

    public void CardOnClick()
    {
        //string name = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name; //get clicked name
        

        //string index = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name.Substring(4);
        //Debug.Log("Clicked at: " + name+ " with index: "+index);

        if (!firstGuess)
        {
            firstGuess = true;
            firstGuessIndex = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name.Substring(4));

            firstGuessCard = cardFronts[firstGuessIndex].name;
            buttons[firstGuessIndex].image.sprite = cardFronts[firstGuessIndex];
        }
        else if (!secondGuess)
        {
            secondGuess = true;
            secondGuessIndex = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name.Substring(4));

            secondGuessCard = cardFronts[secondGuessIndex].name;
            buttons[secondGuessIndex].image.sprite = cardFronts[secondGuessIndex];

            countGuesses++;

            StartCoroutine(IsItMatching());
        }
    }

    IEnumerator IsItMatching()
    {
        yield return new WaitForSeconds(1f);

        if (firstGuessCard == secondGuessCard)
        {
            yield return new WaitForSeconds(0.5f);

            //Card gone
            buttons[firstGuessIndex].interactable = false; //no clickable
            buttons[secondGuessIndex].interactable = false;

            buttons[firstGuessIndex].image.color = new Color(0,0,0,0); //rgb alpha
            buttons[secondGuessIndex].image.color = new Color(0,0,0,0); //rgb alpha

            IsItFinished();
        } else
        {
            yield return new WaitForSeconds(0.5f);
            buttons[firstGuessIndex].image.sprite = cardBack;
            buttons[secondGuessIndex].image.sprite = cardBack;
        }

        yield return new WaitForSeconds(0.5f);

        firstGuess = secondGuess = false;
    }

    void IsItFinished()
    {
        countCorretGuesses++;

        if (countCorretGuesses == gameGuesses)
        {
            StartCoroutine(TransToScore());
        }
    }

    public void DeleteUI()
    {
        GameObject.Find("CardBacks").active = false;

    }

    public void ScoreUI()
    {

        scoreUI.active = true;

        //countGuesses

        TMP_Text guessesText = GameObject.Find("Steps").GetComponent<TMP_Text>();

        guessesText.text = "Won with guesses: " + countGuesses;


    }

    IEnumerator TransToScore()
    {


        transToScoreboard.SetTrigger("ToScoreBegin");

        yield return new WaitForSeconds(1f);

        DeleteUI();

        transToScoreboard.SetTrigger("ToScoreEnd");

        ScoreUI();

    }

    void RandomiseCards(List<Sprite> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            Sprite temp = list[i];
            int randomIndex = Random.Range(i, list.Count);
            list[i] = list[randomIndex];
            list[randomIndex] = temp;
        }

        //Temp megkapja i. elemet ideiglenesben (itt i = 0)
        //random index kap egy random sz�mot (itt pl 8)
        //K�rty�k i. eleme (itt 0.) a random index-edik (itt 8) elemm� v�ltozik
        //A random index-edik (itt 8) elem pedig a Temp (ami itt 0. volt) elemm� v�ltozik
        //i++
        //ez l�nyeg�ben egy temp csere
    }
}
