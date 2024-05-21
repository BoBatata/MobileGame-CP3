using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceBlockBehavior : MonoBehaviour
{
    private Transform transform;
    private Collider2D collider;
    private void Awake()
    {
        transform = GetComponent<Transform>();
        collider = GetComponent<Collider2D>();
    }

    private void Update()
    {
        transform.Translate(-3 * Time.deltaTime, 0,0);    
    }
}
