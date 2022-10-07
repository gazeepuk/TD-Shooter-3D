using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    [SerializeField]
    private Bullet bulletPrefab;

    public static ObjectPool<Bullet> pool;
    private void Awake()
    {
        pool = new ObjectPool<Bullet>(bulletPrefab, 30, transform);
    }
}
