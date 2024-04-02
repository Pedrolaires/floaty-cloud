using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColision : MonoBehaviour{

    private SpriteRenderer sprite_renderer;
    
    [SerializeField]
    private Sprite sprite_player_dead;

    [SerializeField]
    private GameObject transition_game_over;

    [SerializeField]
    private GameObject game_over_panel;

    private GameManager gameManager;

    void Start(){
        gameManager = GameManager.Instance;
    }

    void Awake(){
        sprite_renderer = GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "Enemy" || other.gameObject.tag == "Scene_Limit"){
            GameOver();
        }
    }

    private void GameOver(){
        Time.timeScale = 0;

        sprite_renderer.sprite = sprite_player_dead;
        
        transition_game_over.transform.position = transform.position;
        transition_game_over.SetActive(true);
        gameManager.game_over = true;
        StartCoroutine(ShowGameOverPanel());
    }

    private IEnumerator ShowGameOverPanel(){
        yield return new WaitForSecondsRealtime(1.0f);
        game_over_panel.SetActive(true);
    }
}
