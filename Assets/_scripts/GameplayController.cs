using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayController : MonoBehaviour
{

    public BoxSpawner box_spawner;

    [HideInInspector]
    public BoxScripts current_box;


    public CameraFollow camera_script;

    private int moveCount;


    public static GameplayController Instance;
    public void Awake()
    {
        if(Instance==null)
        {
            Instance = this;
        }
    }

    public void Start()
    {

        box_spawner.SpawnBox();
    }

    public void Update()
    {
        DetectInput();
    }

    public void DetectInput()
    {
        if(Input.GetMouseButtonDown(0))
        {
            current_box.DropBox();
        }
    }

    public void SpawnNewBox()
    {
        Invoke("NewBox", 2f);
    }

    public void NewBox()
    {
        box_spawner.SpawnBox();
    }


    public void MoveCamera()
    {
        moveCount++;

        if(moveCount==3)
        {
            moveCount = 0;
            camera_script.target_position.y += 2f;
        }
    }


    public void RestartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(
            UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }






}//GameplayController class
