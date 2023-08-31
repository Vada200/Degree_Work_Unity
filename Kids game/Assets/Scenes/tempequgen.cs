using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class tempequgen : MonoBehaviour
{
    public TextMeshProUGUI egyenlet;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void GenerateRandomEquation()
    {
        char[] operators = { '+', '-', '*', '/' };
        char randomOperator = operators[Random.Range(0, operators.Length)];

        int num1 = 0, num2 = 0;
        float result = 0;

        switch (randomOperator)
        {
            case '+':
                num1 = Random.Range(1, 100);
                num2 = Random.Range(1, Mathf.Max(1, 100 - num1 + 1));
                result = num1 + num2;
                break;
            case '-':
                num1 = Random.Range(0, 100);
                num2 = Random.Range(0, num1 + 1);
                result = num1 - num2;
                break;
            case '*':
                num1 = Random.Range(1, 10);
                num2 = Random.Range(1, Mathf.Max(1, 100 / num1));
                result = num1 * num2;
                break;
            case '/':
                num2 = Random.Range(1, 10);
                num1 = num2 * Random.Range(1, 11);
                result = (float)num1 / num2;
                break;
        }

        egyenlet.text = $"{num1} {randomOperator} {num2} = {result}";
    }
}
    


