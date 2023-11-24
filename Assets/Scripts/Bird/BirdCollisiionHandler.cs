using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Bird))]
public class BirdCollisiionHandler : MonoBehaviour
{
    private Bird _bird;

    private void Awake()
    {
        _bird = GetComponent<Bird>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.TryGetComponent(out Ground ground))
        {
            _bird.Die();
        }
    }
}
