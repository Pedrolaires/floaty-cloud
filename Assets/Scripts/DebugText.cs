using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DebugText : MonoBehaviour{


    [SerializeField]
    private TMP_Text text_speed_debug;

    private GameManager gameManager;

    void Start(){
        gameManager = GameManager.Instance;
    }

    void Update(){
        text_speed_debug.text = "Game Speed: " + gameManager.game_speed.ToString("0.0000");
    }


}