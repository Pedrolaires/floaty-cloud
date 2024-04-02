using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    private Rigidbody2D rb;
    private SpriteRenderer sprite_Renderer;

    [SerializeField] 
    private Sprite sprite_idle;

    [SerializeField]
    private Sprite sprite_fly;

    private GameManager gameManager;

    void Start(){
        gameManager = GameManager.Instance;
    }

    private void Awake(){
        rb = GetComponent<Rigidbody2D>();
        sprite_Renderer = GetComponent<SpriteRenderer>();
    }

    private void fly(){
        rb.velocity = Vector2.zero;
        rb.AddForce(Vector2.up * 150);
    }

    void Update(){
        if(gameManager.game_over) return;
        
        GameManager.Instance.SetPlayerPosition(transform.position.x, transform.position.y);
        if(Input.GetMouseButtonDown(0)){
            fly();
            sprite_Renderer.sprite = sprite_fly;
            StopAllCoroutines();
            StartCoroutine(ChangeToIdleSprite());
        }
        
    }

    private IEnumerator ChangeToIdleSprite(){
        yield return new WaitForSeconds(1.0f);
        sprite_Renderer.sprite = sprite_idle;
    }
}
