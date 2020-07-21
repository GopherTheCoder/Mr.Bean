using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCameraControl : MonoBehaviour
{
    public float scale;
    public float offsetY;

    private Transform transformHero;

    // Start is called before the first frame update
    void Start()
    {

    }

    void Awake() => transformHero = GameObject.Find("Hero").transform;

    // Update is called once per frame
    void Update()
    {
        if (transformHero != null)
            transform.position = new Vector3(transformHero.position.x * scale, transformHero.position.y * scale + offsetY, -10);
        else enabled = false;
    }
}
