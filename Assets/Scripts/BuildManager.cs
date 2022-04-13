using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance; 
    private GameObject towerToBuild;
    public GameObject towerPrefab;

    
    void Awake()
    {
        if (instance != null)
        {
            Debug.Log("More than one BuildManager in the scene");
            return;
        }
        instance = this;
    }


    // Start is called before the first frame update
    void Start()
    {
        towerToBuild = towerPrefab;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject GetTowerToBuild()
    {
        return towerToBuild;
    }
    
}
