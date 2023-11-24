using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdShooter : MonoBehaviour
{
    [SerializeField] private Bullet _bullet;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift)) 
        {
            Shoot(_bullet);
        }
    }

    private void Shoot(Bullet bullet)
    {
        var sentProjectile = GameObject.Instantiate(bullet, transform.position, transform.rotation);
        sentProjectile.SetDirection(transform.right);
    }
}
