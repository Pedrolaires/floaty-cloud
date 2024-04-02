using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalMove : MonoBehaviour
{
    [SerializeField]
    private float speed;

    private GameManager gameManager;

    void Start(){
        gameManager = GameManager.Instance;
    }

    void Update(){
        speed = gameManager.game_speed;
        if(transform.position.x >= -6f){
            transform.position -= new Vector3(Time.smoothDeltaTime * speed, 0, 0);
            return;
        }
        Destroy(gameObject);
    }
}
