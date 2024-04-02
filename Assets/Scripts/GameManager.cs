using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    private static GameManager _Instance;

    [SerializeField]
    private GameObject transition_game_over;
    private bool is_gaming;

    public bool hard_mode;

    public bool game_over { get; set; }
    private float player_x_pos;
    private float player_y_pos;

    [SerializeField][Range(0f, 3000f)]
    public float game_speed;

    public static GameManager Instance{
        get{
            if(_Instance == null){
                _Instance = new GameObject().AddComponent<GameManager>();
                _Instance.name = _Instance.GetType().ToString();
                DontDestroyOnLoad(_Instance.gameObject);
            }
            return _Instance;
        }
    }

    private void Start(){
        game_speed = 1;
        game_over = false;
    }

    private void Awake(){
        Time.timeScale = 0;
        Application.targetFrameRate = 60;
    }

    private void Update(){
        if(is_gaming && !game_over){
            game_speed += 0.003f;
            return;
        }
        if(Input.GetMouseButtonDown(0) && !is_gaming){
            Time.timeScale = 1;
            is_gaming = true;
        }
    }

    public void RestartGame(){
        _Instance.game_speed = 1;
        _Instance.game_over = false;
        _Instance.is_gaming = false;
        SceneManager.LoadScene(0);
    }

    public void SetPlayerPosition(float x, float y){
        player_x_pos = x;
        player_y_pos = y;
    }
}
