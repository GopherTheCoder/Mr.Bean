using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class BombExplode : MonoBehaviour
{
    public float explodeRadius, explodeForce;
    public AudioClip bigBoom;

    private ParticleSystem sparks, explode;

    // Start is called before the first frame update
    void Start()
    {
        sparks = transform.Find("Sparks").GetComponent<ParticleSystem>();
        explode = transform.Find("Explode").GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void Explode()
    {
        GetComponent<AudioSource>().clip = bigBoom;
        GetComponent<AudioSource>().Play();
        sparks.Stop();
        explode.Play();
        GetComponent<Rigidbody2D>().simulated = false;

        Collider2D[] enemies = Physics2D.OverlapCircleAll(transform.position, explodeRadius, LayerMask.GetMask("Enemy"));

        foreach (var enemy in enemies)
        {
            enemy.GetComponent<Enemy>().Hurt();
            enemy.attachedRigidbody.AddForce(explodeForce * (enemy.transform.position - transform.position).normalized);
        }
    }
}
