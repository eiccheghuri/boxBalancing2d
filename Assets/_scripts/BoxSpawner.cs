using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxSpawner : MonoBehaviour
{

    public GameObject box_prefab;


    public void Start()
    {
       // SpawnBox();
    }

    


    public void SpawnBox()
    {
        GameObject _obj = Instantiate(box_prefab);
        Vector3 _temp = transform.position;
        _temp.z = 0f;
        _obj.transform.position = _temp;
    }
    
}
