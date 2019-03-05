using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    public Text amountStepsBot;
    public Text botCleanField;

    private void Start()
    {
        ResetUI();
    }

    private void Update()
    {
        ShowAmountStepsBot();

        if (Game.isOver)
        {
            ShowBotFinishClean();
        }
    }

    public void ShowAmountStepsBot()
    {
        amountStepsBot.GetComponentInParent<Image>().enabled = true;
        amountStepsBot.enabled = true;
        amountStepsBot.text = "Amount steps bot: " + Game.amountStepsBot;
    }

    public void ShowBotFinishClean()
    {
        botCleanField.GetComponentInParent<Image>().enabled = true;
        botCleanField.enabled = true;
        botCleanField.text = "Bot finished cleaning garbage";
    }

    public void ResetUI()
    {
        botCleanField.GetComponentInParent<Image>().enabled = false;
        botCleanField.enabled = false;
        botCleanField.text = "";

        amountStepsBot.GetComponentInParent<Image>().enabled = false;
        amountStepsBot.enabled = false;
        amountStepsBot.text = "";
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
