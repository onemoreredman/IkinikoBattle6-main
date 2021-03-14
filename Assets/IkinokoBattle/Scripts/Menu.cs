using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField] private ItemsDialog itemsDialog;
    [SerializeField] private Button pauseButton;
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private Button resumeButton;

    [SerializeField] private Button itemsButton;
    [SerializeField] private Button recipeButton;
    // Start is called before the first frame update
    void Start()
    {
        pausePanel.SetActive(false);

        pauseButton.onClick.AddListener(Pause);
        resumeButton.onClick.AddListener(Resume);
        itemsButton.onClick.AddListener(ToggleItemsDialog);
        recipeButton.onClick.AddListener(ToggleRecipeDialog);
        
    }
    /// <summary>
    /// ゲームを一時停止するメソッド
    /// </summary>
    private void Pause()
    {
        Time.timeScale = 0;
        pausePanel.SetActive(true);
    }

    /// <summary>
    /// ゲームを再開する
    /// </summary>
    private void Resume() {
        Time.timeScale = 1;
        pausePanel.SetActive(false);
    }

    /// <summary>
    /// アイテムウインドウを開ける
    /// </summary>
    private void ToggleItemsDialog() {

        itemsDialog.Toggle();
    }

    /// <summary>
    /// レシピウィンドウを開ける
    /// </summary>
    private void ToggleRecipeDialog() { }
    // Update is called once per frame

  
}
