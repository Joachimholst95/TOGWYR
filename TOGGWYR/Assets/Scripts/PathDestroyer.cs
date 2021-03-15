using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathDestroyer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroyPath", lifeTime);
    }

    // Update is called once per frame
    void DestroyPath()
    {
        if (GameManager.Instance.GameState != GameState.Dead)
        {
            Destroy(gameObject);
        }
    }

    public float lifeTime = 200f;
}
