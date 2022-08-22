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
        yield return new WaitForSeconds(5f);
        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        GetComponent<Rigidbody>().velocity = Vector3.zero;
    }
}
