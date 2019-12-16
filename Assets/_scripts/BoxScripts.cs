using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxScripts : MonoBehaviour
{
    private float min_x=-2.2f,max_x=2.2f;
    private bool can_move;
    public float move_speed=2f;

    private Rigidbody2D box_body;

    private bool game_over;
    private bool ignore_Collision;
    private bool ignore_trigger;


    public void Awake()
    {
        box_body = GetComponent<Rigidbody2D>();

        box_body.gravityScale = 0f;
    }


    // Start is called before the first frame update
    void Start()
    {
        can_move = true;
        if(Random.Range(0,2)>0)
        {
            move_speed *= -1f;
        }


        GameplayController.Instance.current_box = this;

    }

    // Update is called once per frame
    void Update()
    {

        MoveBox();
        
    }

    void MoveBox()
    {
        if(can_move)
        {
            Vector3 _temp = transform.position;
            _temp.x += move_speed * Time.deltaTime;

            if(_temp.x>max_x)
            {
                move_speed *= -1f;
            }
            else if(_temp.x<min_x)
            {
                move_speed *= -1f;
            }

            transform.position = _temp;
        }
    }

    public void DropBox()
    {
        can_move = false;
        box_body.gravityScale = Random.Range(2,4);

    }

    public void Landed()
    {
        if(game_over)
        {
            return;
        }


        ignore_Collision = true;
        ignore_trigger = true;

        GameplayController.Instance.SpawnNewBox();
        GameplayController.Instance.MoveCamera();
    }

    public void RestartGame()
    {
        GameplayController.Instance.RestartGame();
    }


    public void OnCollisionEnter2D(Collision2D _target)
    {
        if(ignore_Collision)
        {
            return;
        }

        if(_target.gameObject.tag=="Platform")
        {
            Invoke("Landed",2f);
            ignore_Collision = true;
        }

        if (_target.gameObject.tag == "Box")
        {
            Invoke("Landed", 2f);
            ignore_Collision = true;
        }//use || operator for condion Easy :D

    }

    public void OnTriggerEnter2D(Collider2D _target)
    {
        
        if(ignore_trigger)
        {
            return;
        }

        if(_target.gameObject.tag=="GameOver")
        {
            CancelInvoke("Landed");
            game_over = true;
            ignore_trigger = true;


            Invoke("RestartGame",2f);
        }

    }



}//class
