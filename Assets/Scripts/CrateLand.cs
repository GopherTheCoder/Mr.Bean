using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrateLand : MonoBehaviour
{
    // Start is called before the first frame update
    void Start() { }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Land"))
        {
            gameObject.GetComponent<Animator>().enabled = false;
            transform.Find("prop_parachute").GetComponent<Animator>().enabled = true;
            GetComponent<Rigidbody2D>().gravityScale = 10;
        }
    }
}
