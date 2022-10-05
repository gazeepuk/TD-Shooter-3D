using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable
{
    [SerializeField]
    private GameObject player;

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

    private enum EnemyStates
    {

    }
}
