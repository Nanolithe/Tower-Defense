using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPlacements : MonoBehaviour
{
    public GameObject tower;
    public Vector3 positionOffset;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    

    void OnMouseDown()
    {
        if (tower != null)
        {
            Debug.Log("Tower already here");
            return;
        }

        if (Economy.Money < 100)
        {
            Debug.Log("Not Enough Money");
            return;
        }

        GameObject towerToBuild = BuildManager.instance.GetTowerToBuild();
        tower = (GameObject) Instantiate(towerToBuild, transform.position, transform.rotation);
        Economy.Money -= 100;
        Debug.Log("You have $" + Economy.Money);
    }

}
