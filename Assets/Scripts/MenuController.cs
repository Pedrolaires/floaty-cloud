using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour{

    private GameManager gameManager;

    private Animator transition_configuration_animation;

    private Animator transition_configuration_animation_reverse;

    [SerializeField]
    private GameObject transition_menu;

    [SerializeField]
    private GameObject main_menu;

    [SerializeField]
    private GameObject configuration_menu;

    [SerializeField]
    private GameObject transition_menu_reverse;

    void Awake(){
        gameManager = GameManager.Instance;
        transition_configuration_animation = transition_menu.GetComponent<Animator>();
        transition_configuration_animation_reverse = transition_menu_reverse.GetComponent<Animator>();
    }

    public void LoadScene(String _name){
        SceneManager.LoadScene(_name);
    }
    

    public void ConfigurateGame(){
        StartCoroutine(ChangePanel(transition_configuration_animation_reverse, "Transition_Menu_Reverse", main_menu, false));
        StartCoroutine(ChangePanel(transition_configuration_animation, "Transition_Menu", configuration_menu, true));
    }

    public void backToMenu(){
      StartCoroutine(ChangePanel(transition_configuration_animation_reverse, "Transition_Menu_Reverse", configuration_menu, false));
      StartCoroutine(ChangePanel(transition_configuration_animation, "Transition_Menu", main_menu, true));
    }

    public void SetHardMode(){
        gameManager.hard_mode = true;
        LoadScene("Gameplay");
    }

    private IEnumerator ChangePanel( Animator transition, String name, GameObject panel, bool state){
        transition.Play(name);
        yield return new WaitForSecondsRealtime(0.1f);
        panel.SetActive(state);

    }
}