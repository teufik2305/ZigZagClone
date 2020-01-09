﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road : MonoBehaviour
{
    public GameObject roadPrefab;
    public float offset = 0.71f;
    public Vector3 lastPos = new Vector3(0,0,7.1f);

    private int roadCount = 0;

    public  void StartBuilding()
    {
        InvokeRepeating("CreateNewRoadPart", 1f, 0.5f);
    }

    public void CreateNewRoadPart()
    {
        Vector3 spawnPos = Vector3.zero;

        float chance = Random.Range(0, 100);
        if (chance < 50)
        {
            spawnPos = new Vector3(lastPos.x + offset, lastPos.y, lastPos.z + offset);
        }
        else
        {
            spawnPos = new Vector3(lastPos.x - offset, lastPos.y, lastPos.z + offset);
        }

        GameObject g = Instantiate(roadPrefab, spawnPos, Quaternion.Euler(0, 45, 0));

        lastPos = g.transform.position;

        roadCount++;
        if (roadCount % 5 == 0)
        {
            g.transform.GetChild(0).gameObject.SetActive(true);
        }
    }
}
