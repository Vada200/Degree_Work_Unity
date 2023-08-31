using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class randomos : MonoBehaviour
{
    public TextMeshProUGUI randomNumText;
    public InputField numGuessText;
    // Start is called before the first frame update
    void Start()
    {
        randomizerNum();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void guesserButton()
    {
        if (numGuessText.text == randomNumText.text)
        {
            Debug.Log("ezjóó");
        }
        else
        {
            Debug.Log("szar");
        }

        randomizerNum();
    }

    public void randomizerNum()
    {
        int randNum = Random.Range(0, 100);
        randomNumText.text = randNum.ToString();
    }
}
