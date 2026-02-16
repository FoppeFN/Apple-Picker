using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine;

public class RoundRestartScript : MonoBehaviour
{
    public TMP_Text roundCounter;
    public GameObject restartButton;
    
    // Start is called before the first frame update
    public void SetRound(int round)
    {
        roundCounter.text = "Round" + round;
        
    }

    // Update is called once per frame
    public void GameOver()
   {
    if (roundCounter != null)
        roundCounter.text = "Game Over";
    if (restartButton != null)
        restartButton.SetActive(true);
}

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
