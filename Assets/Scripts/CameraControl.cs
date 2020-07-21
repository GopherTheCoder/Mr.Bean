using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public float marginX;
    public float marginY;
    public Vector2 max;
    public Vector2 min;

    private Transform transformHero;

    // Start is called before the first frame update
    void Start()
    {

    }

    void Awake()
    {
        transformHero = GameObject.Find("Hero").transform;
    }

    // Update is called once per frame
    void Update()
    {
        FollowHero();
    }

    private void FollowHero()
    {
        float targetX = transform.position.x;
        float targetY = transform.position.y;

        if (isOverX())
        {
            targetX = Mathf.Lerp(transform.position.x, transformHero.position.x, Time.deltaTime);
            targetX = Mathf.Clamp(targetX, min.x, max.x);
        }
        if (isOverY())
        {
            targetY = Mathf.Lerp(transform.position.y, transformHero.position.y, Time.deltaTime);
            targetY = Mathf.Clamp(targetY, min.x, max.x);
        }

        transform.position = new Vector3(targetX, targetY, transform.position.z);
    }

    private bool isOverX()
    {
        return Mathf.Abs(transform.position.x - transformHero.position.x) > marginX;
    }

    private bool isOverY()
    {
        return Mathf.Abs(transform.position.y - transformHero.position.y) > marginY;
    }
}
