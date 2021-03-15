using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;
using Random = System.Random;

public class SpawnNewPath : MonoBehaviour
{
    public GameObject Path; 
    public GameObject[] obstacles = null;
    bool hasEntered = false;
    private GameObject nPath;
    private Vector3 pos;

    // Update is called once per frame
    void OnTriggerEnter(Collider hit)
    {
        //print("trying to spawn path");
        //print("" + hit.gameObject.name);
        
        //if (!hasEntered && hit.gameObject.tag.Equals(Constants.NewPathTag)) {
        if (!hasEntered && hit.gameObject.name == "pC") {   
            //print("spawning new path");
            hasEntered = true;
            if (nPath != null)
            {
                pos = nPath.transform.position;
            }
            else
            {
                pos = Path.transform.position;
            }
            pos.x = pos.x - 400;
            //print("" + pos);
            nPath = Instantiate(Path, pos, Path.transform.rotation, Path.transform.parent) as GameObject;
        }
    }
    

    private void OnTriggerExit(Collider exit)
    {
        if (exit.gameObject.tag.Equals(Constants.NewPathTag))
        {
            hasEntered = false;
            //print("did it");
        } 
    }
}

