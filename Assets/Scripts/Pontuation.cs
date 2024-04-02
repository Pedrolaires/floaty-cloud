using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Pontuation : MonoBehaviour{

    private float time;
    private float points;

    [SerializeField]
    private TMP_Text text_points;

    [SerializeField]
    private TMP_Text text_gameOver_points;

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        points = (int) (time * 5);

        text_points.text = points.ToString("000000");
        text_gameOver_points.text = points.ToString("000000");
        
    }
}
