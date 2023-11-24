using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if( collision.TryGetComponent(out Bird bird))
        {
            bird.Die();
        }

        if(!collision.TryGetComponent(out EnemyBullet enemyBullet))
        {
            Die();
        }
    }

    private void Die()
    {
        gameObject.SetActive(false);
    }
}
