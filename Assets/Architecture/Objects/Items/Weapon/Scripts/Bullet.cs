using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Bullet : MonoBehaviour
{
    private void OnEnable()
    {
        StartCoroutine(SetBulletDisable());
    }

    private IEnumerator SetBulletDisable()
    {
        yield return new WaitForSeconds(10f);
        gameObject.SetActive(false);
    }
}
