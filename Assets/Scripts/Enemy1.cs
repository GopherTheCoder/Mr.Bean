using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : Enemy
{
    public float speed;
    public int HP = 2;
    public Sprite damaged, dead;
    public GameObject score;
    public AudioClip[] deathAudios;

    private SpriteRenderer spriteRenderer;
    private new Rigidbody2D rigidbody;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = transform.Find("char_enemy_alienShip").GetComponent<SpriteRenderer>();
        rigidbody = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        rigidbody.velocity = new Vector2(transform.localScale.x * speed, rigidbody.velocity.y);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Wall"))
            flip();
    }

    private void flip()
    {
        Vector3 vectorT = transform.localScale;
        vectorT.x *= -1;
        transform.localScale = vectorT;
    }

    override public void Hurt()
    {
        if (HP > 0)
        {
            HP--;
            if (HP == 1) spriteRenderer.sprite = damaged;
            else Die();
        }
    }

    private void Die()
    {
        spriteRenderer.sprite = dead;
        audioSource.PlayOneShot(deathAudios[Random.Range(0, deathAudios.Length)]);
        Instantiate(score, transform.position, Quaternion.identity);
        GameObject.Find("ScoreNumber").GetComponent<UI_Score>().AddScore(100);
        GetComponent<Collider2D>().isTrigger = true;
    }
}
