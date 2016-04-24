using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class menuScript : MonoBehaviour {

    public Canvas quitMenu; // quit menu
    public Canvas gameMode; // game mode selector
    public Button startText; //play button
    public Button classicMode; // original mode
    public Button survivalMode; // survival mode
    public Button exitText; // quit button

	// Use this for initialization
	void Start () {
        quitMenu = quitMenu.GetComponent<Canvas>();
        gameMode = gameMode.GetComponent<Canvas>();
        startText = startText.GetComponent<Button>();
        exitText = exitText.GetComponent<Button>();
        classicMode = classicMode.GetComponent<Button>();
        survivalMode = survivalMode.GetComponent<Button>();
        quitMenu.enabled = false;
        gameMode.enabled = false;

	}
	
    public void exitPressed()
    {
        quitMenu.enabled = true;
        startText.enabled = false;
        exitText.enabled = false;
    }

    public void noPressed()
    {
        quitMenu.enabled = false;
        startText.enabled = true;
        exitText.enabled = true;
    }

    public void playPressed()
    {
        gameMode.enabled = true;
        startText.enabled = false;
        classicMode.enabled = true;
        survivalMode.enabled = true;
    }

    public void startClassic()
    {
        SceneManager.LoadScene("Sam's Scene");
    }

    public void startSurvival()
    {
        SceneManager.LoadScene("SurvivalMode");
    }

    public void exitGame()
    {
        Application.Quit();
    }
}
