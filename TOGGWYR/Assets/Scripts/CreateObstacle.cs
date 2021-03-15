using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateObstacle : MonoBehaviour
{
    public GameObject Path;
    public GameObject ObstacleSpawners;
    public GameObject[] obstacles = null;

    // Start is called before the first frame update
    void Start()
    {
        //print("creating obstacles" + this.name);
        obstacles = Resources.LoadAll<GameObject>("Prefabs/Obstacles");

        GameObject             bottomObstacle;
        Vector3 upperObstacle;
        for (int i = 0; i < ObstacleSpawners.transform.childCount - 1; i++)
        {
            int firstRandomNumber = UnityEngine.Random.Range(0, obstacles.Length - 1);
            int secondRandomNumber = 0;
            //preventing a unpassable obstacle
            if (firstRandomNumber == obstacles.Length - 1)
            {
                secondRandomNumber = UnityEngine.Random.Range(0, obstacles.Length - 2);
            }
            else
            {
                secondRandomNumber = UnityEngine.Random.Range(0, obstacles.Length - 1);
            }

            bottomObstacle = Instantiate(obstacles[firstRandomNumber].gameObject,
                ObstacleSpawners.transform.GetChild(i).transform.position, Path.transform.rotation,
                Path.transform.parent);
            bottomObstacle.transform.SetParent(Path.transform);
            upperObstacle = ObstacleSpawners.transform.GetChild(i).transform.position;
            upperObstacle.y = upperObstacle.y + 3;
            bottomObstacle = Instantiate(obstacles[secondRandomNumber].gameObject, upperObstacle, Path.transform.rotation, Path.transform.parent);
            bottomObstacle.transform.SetParent(Path.transform);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
