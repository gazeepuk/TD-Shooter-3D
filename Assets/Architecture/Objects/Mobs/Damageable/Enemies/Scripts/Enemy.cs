using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable
{
    [SerializeField]
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FindPlayer()
    {

    }

    protected virtual void Attack()
    {

    }

    protected virtual void Defence()
    {

    }

    public virtual void TakeDamage()
    {

    }
}
