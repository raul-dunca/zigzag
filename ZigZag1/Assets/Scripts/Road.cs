using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Road : MonoBehaviour
{
    public GameObject RoadPrefab;
    public Vector3 LastPos;
    public float offset = 0.7071068f;
    private int roadcount=0;
    public void StartBuilding()
    {
        InvokeRepeating("CreateNewRoadPart", 1f, 0.5f);
    }
    public void CreateNewRoadPart()
    {
        
        Vector3 spawnPos = Vector3.zero;
       float chance = Random.Range(0,100);
        if(chance<50)
        {
            spawnPos = new Vector3(LastPos.x + offset,LastPos.y,LastPos.z + offset);
        }
        else
        {
            spawnPos = new Vector3(LastPos.x - offset, LastPos.y, LastPos.z + offset);
        }
        GameObject g=Instantiate(RoadPrefab, spawnPos,Quaternion.Euler(0,45,0));
        LastPos = g.transform.position;
        roadcount++;
        if(roadcount%7==0)
        {
            g.transform.GetChild(0).gameObject.SetActive(true);
        }
    }

    
}
