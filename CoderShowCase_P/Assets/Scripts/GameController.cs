using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public Text randomNumber;
    int intRandomNumber;
    public Text scoreText;
    public int score;
    int auxDebug;

    public Button Button1, Button2;

    public Text initialText;

    bool gameOver = false;

    public Text end;

    // Use this for initialization
    void Start () {
        score = 0;
        randomNumber.text = "";
        end.text = "";
        StartCoroutine(changeNumber());

        Button oddButton = Button1.GetComponent<Button>();
        Button evenButton = Button2.GetComponent<Button>();
   
        //Calls the TaskOnClick method when you click the Button
        oddButton.onClick.AddListener(delegate { checkButton(oddButton.name); });
        evenButton.onClick.AddListener(delegate { checkButton(evenButton.name); });

    }

    

    // Update is called once per frame
    void Update () {
        Destroy(initialText,2);

        if (score == 5)
        {
            gameOver = true;
            end.text = "You Win!";
        }

    }

    IEnumerator changeNumber()
    {
        yield return new WaitForSeconds(2);
        while (!gameOver)
        {
            intRandomNumber = Random.Range(0, 100);
            randomNumber.text = intRandomNumber.ToString();
            yield return new WaitForSeconds(3);
        }
    }

    void checkButton(string nameButton)
    {
        if ((intRandomNumber % 2 == 0) && (nameButton.Equals("Even")))
        {
            UpdateScore();

        }
        else if ((intRandomNumber % 2 != 0) && (nameButton.Equals("Odd")))
        {
            UpdateScore();

        }
        
    }

    void UpdateScore()
    {
        score += 1;
        scoreText.text = "Score: " + score;
    }

}


