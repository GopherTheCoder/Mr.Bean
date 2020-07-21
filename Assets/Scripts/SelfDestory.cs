using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestory : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void Destory()
    {
        Destroy(gameObject);
    }

    void DestoryWithDelay(float delay)
    {
        Destroy(gameObject, delay);
    }
}
