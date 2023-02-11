using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float _damage = 20;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Enemy enemy))
        {
            enemy.TakeDamage(_damage);
            DisableObject();
        }
            DisableObject();
    }

    private void DisableObject()
    {
        gameObject.SetActive(false);
        gameObject.GetComponent<Rigidbody>().velocity= Vector3.zero;
    }
}
