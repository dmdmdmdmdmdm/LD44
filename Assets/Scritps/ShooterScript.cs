using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterScript : MonoBehaviour
{
    [SerializeField]
    private float shootDelay = 5f;
    private float shootTimer = 0f;

    [SerializeField]
    private GameObject arrow;
    [SerializeField]
    private GameObject parent;

    private AudioSource ad;
    // Start is called before the first frame update
    void Start()
    {
        ad = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(shootTimer > shootDelay)
        {
            shootTimer = 0f;
            //Debug.Log("Shooting");
            Instantiate(arrow, gameObject.transform.position, Quaternion.identity);
            ad.Play();
        }
        shootTimer += Time.deltaTime;
    }
}
