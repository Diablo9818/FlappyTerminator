using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    [SerializeField] private EnemyBullet _bullet;
    [SerializeField] private float secondsToNextShoot;
    private WaitForSeconds _shootDelay;
    private Coroutine _shooting;

    private void Awake()
    {
        _shootDelay = new WaitForSeconds(secondsToNextShoot);
    }

    private void OnEnable()
    {
        _shooting = StartCoroutine(Shoot());
    }

    private void OnDisable()
    {
        StopCoroutine(_shooting);
    }

    private IEnumerator Shoot()
    {
        while(enabled)
        {
            var bullet = Instantiate(_bullet, transform.position, transform.rotation);
            bullet.SetDirection(Vector3.left);
            yield return _shootDelay;
        }
    }
}
