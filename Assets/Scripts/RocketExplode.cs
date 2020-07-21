using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketExplode : MonoBehaviour
{
    public GameObject explosion;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 2);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
            collision.gameObject.GetComponent<Enemy>().Hurt();

        if (!collision.CompareTag("Player"))
        {
            Explode();
            Destroy(gameObject);
        }
    }

    void Explode()
    {
        Quaternion randomRotation = Quaternion.Euler(0, 0, Random.Range(0, 360));
        explosion = Instantiate(explosion, transform.position, randomRotation);
    }
}
