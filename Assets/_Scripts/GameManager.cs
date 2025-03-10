using TMPro;
using UnityEngine;
using UnityEditor;

public class GameManager : SingletonMonoBehavior<GameManager>
{
    [SerializeField] private int score = 0;
    [SerializeField] private CoinCounterUI coinCounter;
    [SerializeField] private InputManager inputManager;
    [SerializeField] private GameObject settingsMenu;

    private bool is_SettingsMenuActive;

    public bool isSettingsMenuActive => is_SettingsMenuActive;

    protected override void Awake()
    {
        base.Awake();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        inputManager.OnSettingsMenu.AddListener(ToggleSettingsMenu);
       DisableSettingsMenu();
    }

    public void IncreaseScore()
    {
        score++;
        coinCounter.UpdateScore(score);
    
    }

    private void ToggleSettingsMenu(){
        if(is_SettingsMenuActive) DisableSettingsMenu();
        else EnableSettingsMenu();
    }

    private void EnableSettingsMenu(){
        Time.timeScale = 0f;
        settingsMenu.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        is_SettingsMenuActive = true;
    }

    public void DisableSettingsMenu(){
        Time.timeScale = 1f;
        settingsMenu.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        is_SettingsMenuActive = false;
    }

    public void QuitGame(){
        #if UNITY_EDITOR
        EditorApplication.isPlaying = false;
        #else
        Application.Quit();
        #endif
    }

}
