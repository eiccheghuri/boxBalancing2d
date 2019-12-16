using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    [HideInInspector]
    public Vector3 target_position;

    private float smoot_move = 1f;

    public void Start()
    {
        target_position = transform.position;
    }

    public void Update()
    {
        transform.position = Vector3.Lerp(transform.position, target_position, smoot_move * Time.deltaTime);
    }



}
