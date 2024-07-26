using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Reflection;


public class GameManager : MonoBehaviour
{
    public Button rockButton;
    public Button paperButton;
    public Button scissorsButton;
    public Button shootButton;
    public Button replayButton;
    public Button quitButton;

    public TMP_Text myChoicetext;
    public TMP_Text computerChoicetext;
    public TMP_Text Resulttext;

    public Image myChoiceImage;
    public Image computerChoiceImage;

    public Sprite rockSprite;
    public Sprite paperSprite;
    public Sprite scissorsSprite;

    private Choice myChoice;
    private Choice computerChoice;

    public enum Choice
    {
        Rock,
        Paper,
        Scissors,
    }
    void Start()
    {
        shootButton.onClick.AddListener(Shoot);
        replayButton.onClick.AddListener(Replay);
        quitButton.onClick.AddListener(LeaveGame);
       

        ResetGame();
    }

   public void OnPlayerChoice(int choice)
    {
        
            myChoice = (Choice)choice;
           // myChoicetext.text = "Player: " + myChoice.ToString();
        myChoiceImage.sprite = GetChoiceSprite(myChoice);
        
        
    }

    public void Shoot()
    {
     
        GetComputerChoice();
        GetWinner();

        shootButton.interactable = false;
        replayButton.interactable = true;
        Resulttext.gameObject.SetActive(true);
    }

    public void GetComputerChoice()
    {
        computerChoice = (Choice)Random.Range(0, 2);
       // computerChoicetext.text = "Computer: " + computerChoice.ToString();
        computerChoiceImage.sprite = GetChoiceSprite(computerChoice);
    }

    public void GetWinner()
    {
        if (myChoice == computerChoice)
        {
            Resulttext.text = "Tie! Shoot Again!";
        }
        else if (myChoice == Choice.Rock && computerChoice == Choice.Scissors || myChoice == Choice.Scissors && computerChoice == Choice.Paper || myChoice == Choice.Paper && computerChoice == Choice.Rock)
        {
            
            Resulttext.text = "You win!";     
        }
        else
        {
            Resulttext.text = "Computer Wins!";
        }
    }

    public void Replay()
    {
        ResetGame();
    }

    void ResetGame() {
        myChoicetext.text = "Player: ";
        computerChoicetext.text = "Computer: ";
        Resulttext.text = "";
        Resulttext.gameObject.SetActive(false);

        myChoiceImage.sprite = null;
        computerChoiceImage.sprite = null;

        shootButton.interactable = true;
        replayButton.interactable = false;
     
    }

    public Sprite GetChoiceSprite(Choice choice)
    {
        switch (choice)
        {
            case Choice.Rock:
                return rockSprite;
            case Choice.Paper:
                return paperSprite;
            case Choice.Scissors:
                return scissorsSprite;
            default:
                return null;
        }
    }
    public void LeaveGame()
    {
#if UNITY_EDITOR
UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif

    }
}
