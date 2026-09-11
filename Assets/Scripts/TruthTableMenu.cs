using UnityEngine;
using UnityEngine.UI;
using System;

public class TruthTableMenu : MonoBehaviour
{
    [Serializable] public class TruthTableEntry
    {
        public Button button;
        public Sprite table;
    }

    public static bool GameIsPaused = false;

    [SerializeField] protected GameObject menuUI;
    [SerializeField] protected Image truthTableImage;
    [SerializeField] protected TruthTableEntry[] entries;

    void Awake()
    {
        foreach (TruthTableEntry entry in entries)
        {
            entry.button.onClick.AddListener(() => ChangeTable(entry.table));
        }

        if (entries.Length > 0)
        {
            ChangeTable(entries[0].table);
        }

        menuUI.SetActive(false);
        Time.timeScale = 1;
        GameIsPaused = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    void Pause()
    {
        menuUI.SetActive(true);
        Time.timeScale = 0;
        GameIsPaused = true;
    }

    void Resume()
    {
        menuUI.SetActive(false);
        Time.timeScale = 1;
        GameIsPaused = false;
    }
    void ChangeTable(Sprite table)
    {
        truthTableImage.sprite = table;
    }
}
