using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    [SerializeField]
    private Bullet bulletPrefab;

    public static BulletPool Instance;

    public ObjectPool<Bullet> pool;
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        pool = new ObjectPool<Bullet>(bulletPrefab, 30, transform);
    }
}
