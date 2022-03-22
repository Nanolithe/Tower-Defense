using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100.0f) && hit.transform.gameObject != null)
            {
                if (hit.transform.gameObject.CompareTag("Enemy"))
                {
                    //GameObject.Destroy(hit.transform.gameObject);
                    hit.transform.GetComponent<EnemyDemo>().TakeDamage(1);
                    //Debug.Log("Enemy Hit! " + hit.transform.GetComponent<EnemyDemo>().enemyHealth.ToString());
                    
                }
            }
            Debug.Log("Pressed primary button.");

        }
    }
}
