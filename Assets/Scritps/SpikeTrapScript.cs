using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeTrapScript : MonoBehaviour
{
    [SerializeField]
    private float desyncDelay = 0f;
    private float desyncTimer = 0f;
    [SerializeField]
    private bool startActive = false;
    [SerializeField]
    private float spikeDelay = 3f;
    [SerializeField]
    private float spikeActiveDelay = 3f;
    private float spikeActiveTimer = 0f;
    private float spikeTimer = 0f;

    private EdgeCollider2D coll;

    [SerializeField]
    private AudioSource audioUp;
    [SerializeField]
    private AudioSource audioDown;

    private bool spikeActive = false;
    private Animator spikeAnim;
    // Start is called before the first frame update
    void Start()
    {
        coll = GetComponent<EdgeCollider2D>();
        spikeAnim = GetComponentInChildren<Animator>();
        this.tag = "SpikeTrap";
        coll.enabled = false;
        if (startActive)
        {
            coll.enabled = true;
            spikeActive = true;
            this.tag = "SpikeTrapActive";
            spikeAnim.SetTrigger("ActivateSpikes");
            audioUp.Play();
        }
        if(desyncDelay == 0f)
        {
            desyncTimer = 50;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (desyncTimer > desyncDelay)
        {
            if (spikeTimer > spikeDelay)
            {
                
                this.tag = "SpikeTrapActive";
                spikeActiveTimer = 0f;
                spikeAnim.SetTrigger("ActivateSpikes");
                spikeActive = true;
                spikeTimer = 0f;
                coll.enabled = true;
                audioUp.Play();
            }
            if (spikeActiveTimer > spikeActiveDelay)
            {

                spikeTimer = 0f;
                spikeActiveTimer = 0f;
                spikeActive = false;
                this.tag = "SpikeTrap";
                spikeAnim.SetTrigger("DeactivateSpikes");
                coll.enabled = false;
                audioDown.Play();
            }
            if (spikeActive)
            {
                spikeActiveTimer += Time.deltaTime;
            }
            else
            {
                spikeTimer += Time.deltaTime;
            }
        }
        if ( desyncTimer < desyncDelay * 2 + 5 ) desyncTimer += Time.deltaTime;
    }

}
