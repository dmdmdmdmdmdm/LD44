using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField]
    private static float scoreStart = 1000000f;
    private static float score;

    // Start is called before the first frame update
    void Start()
    {
        score = scoreStart;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static float GetScore()
    {
        return score;
    }
    public static void DecreaseScore(float amount)
    {
        score = score - amount;
    }
    public static void SetScore(float amount)
    {
        score = amount;
    }
}
