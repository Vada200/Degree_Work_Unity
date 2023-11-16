using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;

public class MenuControll : MonoBehaviour
{

    public string filepath;
    public TextMeshProUGUI numbers;
    int unlockedAnimals;
    public List<GameObject> animals = new List<GameObject>();




    // Start is called before the first frame update
    void Start()
    {
        filepath = Application.dataPath + "/animalUnlocks.txt";

        readFromFile();

        animalUnlock();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void readFromFile()
    {
        string[] lines = File.ReadAllLines(filepath);

        unlockedAnimals = int.Parse(lines[1]);
        Debug.Log("Unlocked animals: " + unlockedAnimals);
    }

    public void animalUnlock()
    {
        for (int i = 0; i < unlockedAnimals; i++)
        {
            if (unlockedAnimals <= 6)
            {
                animals[i].SetActive(true);
            }
            
        }
    }



}
