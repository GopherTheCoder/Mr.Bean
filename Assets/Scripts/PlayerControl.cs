using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PlayerControl : MonoBehaviour
{
    public float moveForce = 400f;
    public float maxSpeed = 100f;
    public float jumpForce = 100f;
    public AudioClip[] jumpAudios;
    [HideInInspector]
    public bool faceRight = true;

    private bool jump = false;
    private bool onGround = false;
    private new Rigidbody2D rigidbody;
    private Transform groundCheck;
    private Animator animator;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        groundCheck = transform.Find("GroundCheck");
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        onGround = Physics2D.Linecast(transform.position, groundCheck.position, LayerMask.GetMask("Ground"));
        if (onGround && Input.GetButtonDown("Jump"))
            jump = true;
    }

    private void FixedUpdate()
    {
        float axisHorizontal = Input.GetAxis("Horizontal");

        //控制移动
        if (axisHorizontal * rigidbody.velocity.x < maxSpeed)
            rigidbody.AddForce(Vector2.right * axisHorizontal * moveForce);

        //限制最大速度
        if (Mathf.Abs(rigidbody.velocity.x) > maxSpeed)
            rigidbody.velocity = new Vector2(Mathf.Sign(rigidbody.velocity.x) * maxSpeed, rigidbody.velocity.y);

        //转身
        if (axisHorizontal > 0 && !faceRight)
            flip();
        if (axisHorizontal < 0 && faceRight)
            flip();

        if (jump)
        {
            animator.SetTrigger("jump");
            rigidbody.AddForce(Vector2.up * jumpForce);

            audioSource.PlayOneShot(jumpAudios[Random.Range(0, jumpAudios.Length)]);

            jump = false;
        }

        animator.SetFloat("speed", Mathf.Abs(rigidbody.velocity.x));
    }

    private void flip()
    {
        faceRight = !faceRight;
        Vector3 vectorT = transform.localScale;
        vectorT.x *= -1;
        transform.localScale = vectorT;
    }
}
