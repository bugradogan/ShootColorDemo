using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private int boxCount;
    private int activeLevel;
    private Box[] boxes;
    public GameObject nextLevelPanel;
    public GameObject finishParticleObject;  
    public GameObject[] levels;
    public Text levelText;
    [HideInInspector] public int trueColor;
    [HideInInspector] public bool startGame = false;

    private void Awake()
    {      
        Instance = this;
        for (int i = 0; i < levels.Length; i++)
        {
            levels[i].SetActive(false);
        }
        if (PlayerPrefs.HasKey("Level"))
        {
            activeLevel = PlayerPrefs.GetInt("Level");
            levels[activeLevel].SetActive(true);
        }
        else
        {
            activeLevel = 0;
            PlayerPrefs.SetInt("Level", activeLevel);
            levels[activeLevel].SetActive(true);
        }
        levelText.text = "Level " + (activeLevel+1);
    }
    private void Start()
    {
        boxes = GameObject.FindObjectsOfType<Box>();
        boxCount = boxes.Length;
        nextLevelPanel.SetActive(false);   
    }


    void Update()
    {                   
        trueColor = Mathf.Clamp(trueColor, 0, boxCount);       
        if(startGame)
        {
            if (boxCount == trueColor)
            {
                startGame = false;
                nextLevelPanel.SetActive(true);
                activeLevel++;
                PlayerPrefs.SetInt("Level", activeLevel);
                finishParticleObject.SetActive(true);
               
            }
        }       
    }

    public void StartGame()
    {
        startGame = true;
    }

    public void NextLevel()
    {
        SceneManager.LoadScene("Game");
    }
}
