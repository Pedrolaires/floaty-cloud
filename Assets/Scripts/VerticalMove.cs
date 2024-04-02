using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalMove : MonoBehaviour
{
    [SerializeField][Range(0,2)]private float speed;

    private enum Direction
    {
        UP,
        DOWN
    }
    [SerializeField] private Direction direction = Direction.UP;

    void Start(){
        int startDirection = Random.Range(0, 2);

        if(startDirection == 0)
            direction = Direction.DOWN;
    }

    // Update is called once per frame
    void Update(){
        switch(direction){
            case Direction.UP:
                transform.position += new Vector3(0, Time.deltaTime * speed, 0);
                if(transform.position.y >= 6f){
                    direction = Direction.DOWN;  
                }
                return;
            case Direction.DOWN:
                transform.position -= new Vector3(0, Time.deltaTime * speed, 0);
                if(transform.position.y <= -6f){
                    direction = Direction.UP;
                }
                return;
        }
    }
}
