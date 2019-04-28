using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    private static TextMeshProUGUI tmp;
    // Start is called before the first frame update
    void Start()
    {
        tmp = GetComponent<TextMeshProUGUI>();
        tmp.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public static void EndGame()
    {
        float score = 0;
        if (ScoreManager.GetScore() < 0){
            score = 0;
        } else {
            score = ScoreManager.GetScore();
        }
        tmp.text = "You managed to steal " + System.String.Format("{0:C0}", score) + ". \n Press SPACE to play again";
        tmp.enabled = true;
    }
}
