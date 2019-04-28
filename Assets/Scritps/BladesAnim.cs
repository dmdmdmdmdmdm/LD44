using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BladesAnim : MonoBehaviour
{


    [SerializeField]
    private GameObject blades1;
    [SerializeField]
    private GameObject blades2;
    [SerializeField]
    private GameObject blades1shadow;
    [SerializeField]
    private GameObject blades2shadow;
    [SerializeField]
    private bool one = true;
    [SerializeField]
    private float switchDelay = 0.1f;
    private float switchTimer = 0f;
    // Start is called before the first frame update
    void Start()
    {
        if (one)
        {
            blades2.GetComponent<SpriteRenderer>().enabled = false;
            blades2shadow.GetComponent<SpriteRenderer>().enabled = false;
        } else
        {
            blades1.GetComponent<SpriteRenderer>().enabled = false;
            blades1shadow.GetComponent<SpriteRenderer>().enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (switchTimer > switchDelay)
        {
            switchTimer = 0f;
            if(one)
            {
                blades1.GetComponent<SpriteRenderer>().enabled = false;
                blades2.GetComponent<SpriteRenderer>().enabled = true;
                blades1shadow.GetComponent<SpriteRenderer>().enabled = false;
                blades2shadow.GetComponent<SpriteRenderer>().enabled = true;
                one = false;
            } else
            {
                blades1.GetComponent<SpriteRenderer>().enabled = true;
                blades2.GetComponent<SpriteRenderer>().enabled = false;
                blades1shadow.GetComponent<SpriteRenderer>().enabled = true;
                blades2shadow.GetComponent<SpriteRenderer>().enabled = false;
                one = true;
            }
        }
        switchTimer += Time.deltaTime;
    }
}
