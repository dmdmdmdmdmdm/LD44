using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDamage : MonoBehaviour
{
    private AudioSource ad;

    [SerializeField]
    private float fallScore = 100f;
    [SerializeField]
    private float arrowScore = 10000f;
    [SerializeField]
    private float spinScore = 20000f;
    [SerializeField]
    private float spikeScore = 10000f;

    [SerializeField]
    private GameObject particles;

    [SerializeField]
    private GameObject trail;
    private Animator anim;

    [SerializeField]
    private float spinDelay = 0.2f;
    private float spinTimer = 0f;

    [SerializeField]
    private float trailDelay = 0.2f;
    private float trailTimer;
    private bool inSpinTrap = false;

    private bool decreaseScore;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        ad = GetComponent<AudioSource>();
        decreaseScore = true;
    }

    // Update is called once per frame
    void Update()
    {
     if (trailTimer > trailDelay && decreaseScore)
        {
            trailTimer = 0f;
            GameObject tr = Instantiate(trail, gameObject.transform.position, Quaternion.identity);
            tr.GetComponent<ParticleSystem>().GetComponent<Renderer>().sortingLayerName = "Traps";
            tr.GetComponent<ParticleSystem>().GetComponent<Renderer>().sortingOrder = -5;
            tr.transform.position = new Vector3(tr.transform.position.x, tr.transform.position.y, tr.transform.position.z - 8);
            Destroy(tr, trailDelay * 25);
            ScoreManager.DecreaseScore(fallScore);

        }
        trailTimer += Time.deltaTime;
        spinTimer += Time.deltaTime;

        if ( (spinTimer > spinDelay) && inSpinTrap && decreaseScore)
        {
            spinTimer = 0f;
            Debug.Log("Hit by Spinner!");
            anim.SetTrigger("ArrowHit");

            GameObject obj = Instantiate(particles, gameObject.transform.position, Quaternion.identity);
            obj.GetComponent<ParticleSystem>().GetComponent<Renderer>().sortingLayerName = "Traps";
            obj.GetComponent<ParticleSystem>().GetComponent<Renderer>().sortingOrder = -5;
            obj.transform.position = new Vector3(obj.transform.position.x, obj.transform.position.y, obj.transform.position.z - 8);
            ad.Play();
            Destroy(obj, 10f);
            ScoreManager.DecreaseScore(spinScore);
        }

        if (ScoreManager.GetScore() <= 0)
        {
            GetComponent<PlayerMovement>().enabled = false;
            GameOver.EndGame();
        }
        if (Input.GetKey(KeyCode.Space))
        {
            GetComponent<PlayerMovement>().enabled = true;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Arrow") && decreaseScore)
        {
            Debug.Log("Hit by arrow!");
            Destroy(collision.gameObject);
            anim.SetTrigger("ArrowHit");
            GameObject obj = Instantiate(particles, gameObject.transform.position, Quaternion.identity);
            obj.GetComponent<ParticleSystem>().GetComponent<Renderer>().sortingLayerName = "Traps";
            obj.GetComponent<ParticleSystem>().GetComponent<Renderer>().sortingOrder = -5;
            obj.transform.position = new Vector3(obj.transform.position.x, obj.transform.position.y, obj.transform.position.z - 8);
            //obj.transform.rotation.SetEulerAngles(new Vector3(0, 25, 0));
            //Debug.Log(obj.GetComponent<ParticleSystem>().GetComponent<Renderer>().sortingOrder);
            ScoreManager.DecreaseScore(arrowScore);
            Destroy(obj, 10f);
            ad.Play();

        }
        if (collision.gameObject.CompareTag("SpinTrap"))
        {
            inSpinTrap = true;   
        }

        if(collision.gameObject.CompareTag("SpikeTrapActive") && decreaseScore)
        {
            Debug.Log("Hit by spikes!");
            anim.SetTrigger("ArrowHit");
            GameObject obj = Instantiate(particles, gameObject.transform.position, Quaternion.identity);
            obj.GetComponent<ParticleSystem>().GetComponent<Renderer>().sortingLayerName = "Traps";
            obj.GetComponent<ParticleSystem>().GetComponent<Renderer>().sortingOrder = -5;
            obj.transform.position = new Vector3(obj.transform.position.x, obj.transform.position.y, obj.transform.position.z - 8);
            //obj.transform.rotation.SetEulerAngles(new Vector3(0, 25, 0));
            //Debug.Log(obj.GetComponent<ParticleSystem>().GetComponent<Renderer>().sortingOrder);
            ScoreManager.DecreaseScore(spikeScore);
            Destroy(obj, 10f);
            ad.Play();
        }
        if (collision.gameObject.CompareTag("Goal"))
        {
            GetComponent<PlayerMovement>().enabled = false;
            GameOver.EndGame();
            decreaseScore = false;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("SpinTrap"))
        {
            inSpinTrap = false;
        }
    }
}
