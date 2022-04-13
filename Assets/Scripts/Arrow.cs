using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    private Transform target;
    public float speed = 70f;
    public GameObject impactEffect;
    public int damage = 1;

    public void Seek(Transform _target)
    {
        target = _target;
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if (dir.magnitude <= 0.2f)
        {
            CheckForTarget();
        }
        
        /*if (dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }*/
        
        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
        transform.LookAt(target.position);
    }

    void CheckForTarget()
    {
        Collider[] colliders = Physics.OverlapSphere(this.transform.position, 0.2f);
        foreach (Collider collider in colliders)
        {
            if (collider.CompareTag("Enemy"))
            {
                Debug.Log("hit");
                collider.GetComponent<EnemyDemo>().TakeDamage(1);
                Instantiate(impactEffect, transform.position, transform.rotation);
                Destroy(gameObject);
            }
        }
    }

    void Damage(Transform enemy)
    {
        EnemyDemo e = enemy.GetComponent<EnemyDemo>();

        if (e != null)
        {
            e.TakeDamage(damage);
        }
    }

    /*void HitTarget()
    {
        GameObject effectIns = (GameObject) Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(gameObject);
    }*/

    /*private void OnTriggerEnter(Collider other)
    {
        Debug.Log("hit something");
        if (other.CompareTag("Enemy"))
        {
            Debug.Log("hit an enemy");
            other.GetComponent<EnemyDemo>().TakeDamage(1);
            Instantiate(impactEffect, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        //throw new NotImplementedException();
        Debug.Log("collision hit");
        if (collision.collider.CompareTag("Enemy"))
        {
            Debug.Log("collision hit an enemy");
        }
    }*/
}
