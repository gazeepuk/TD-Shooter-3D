using System.Collections;
using UnityEngine;
public class Bullet : MonoBehaviour
{
    private void OnEnable()
    {
        GetComponent<Rigidbody>().isKinematic = false;
        StartCoroutine(SetBulletDisable());
    }

    private IEnumerator SetBulletDisable()
    {
        yield return new WaitForSeconds(5f);
        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        GetComponent<Rigidbody>().isKinematic = true;
    }
}
