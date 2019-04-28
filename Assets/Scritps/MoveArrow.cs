using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveArrow : MonoBehaviour
{
    [SerializeField]
    private float xfactor = 1f;
    [SerializeField]
    private float yfactor = 1f;
    [SerializeField]
    private float speed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, 3f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(transform.position.x + xfactor * Time.deltaTime * speed, transform.position.y + yfactor * Time.deltaTime * speed);
    }
}
