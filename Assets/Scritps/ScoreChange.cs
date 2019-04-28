using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreChange : MonoBehaviour
{
    private TextMeshProUGUI tx;

    // Start is called before the first frame update
    void Start()
    {
        tx = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (ScoreManager.GetScore() > 0)
        {
            tx.text = System.String.Format("{0:C0}", ScoreManager.GetScore());
        } else
        {
            ScoreManager.SetScore(0);
            tx.text = System.String.Format("{0:C0}", ScoreManager.GetScore());
        }
    }
}
