using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int countDownTime = 3;
    public Text countDownText;
   
    bool endGame = false;

  
    public void EndGame()
    {
        if (!endGame)
        {
            endGame = true;
            Debug.Log("Game Over!");
            countDownText.gameObject.SetActive(true);
            countDownText.text = "Game Over!";
            
            Restart();
            
        }
        
    }

    void Restart()
    {
        
        StartCoroutine(resetCourotin());
    }

    IEnumerator resetCourotin()
    {

        yield return new WaitForSeconds(1f);
        while (countDownTime > 0)
        {
            countDownText.text = countDownTime.ToString();
            yield return new WaitForSeconds(1f);
            countDownTime--;
        }
        countDownText.text = "Restart!";
        SceneManager.LoadScene("Level");

        yield return new WaitForSeconds(1f);
        countDownText.gameObject.SetActive(false);
    }
}
