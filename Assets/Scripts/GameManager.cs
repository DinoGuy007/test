
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.Collections;
using System;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameState gameState;

   
    //public static event Action<>;  
    //something is wrong and Action is giving an error


    public int money;
    public int health = 5;
    public int power = 1;
    public int experience = 0;
    public int damage = 3;
    public int level = 1;
    public GameState state;



    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        Instance = this;
    }

    void Start()
    {
        NewGame();
     
    }
 

    private void NewGame()
    {
        
        LoadStage(1);
        updateGameState(GameState.GenerateGrid); //currently calling this before it is instantiated, need to instantiate
    }

    private void nextLevel()
    {
        level = level + 1;
        LoadStage(level);
    }
    private void LoadStage(int Level)
    {
        this.level = Level;


        SceneManager.LoadScene("Level" + Level);

        //using this to load the levels. Instead of using complex biome logic, I can design each level in a different scene. I can use this to make different stages look different
    }

    public void updateGameState(GameState newState )
    {
        state = newState;

        switch (newState)
        {
            case GameState.Intro:
                updateGameState(GameState.GenerateGrid);
                break;//breaks are similar to the return statement, as they stop the other things with cases from running, but the other code beneath it gets run as well 
            case GameState.GenerateGrid:
                Debug.Log("test");
                //
                //GridManager.InstanceG.GenerateGrid();
                break;
            case GameState.SpawnPlayer:
                UnitManager.instance.SpawnPlayer();
                break;
            case GameState.SpawnEnemy:
                UnitManager.instance.SpawnEnemy();
                break;
            case GameState.PlayerTurn:
                break;
            case GameState.EnemyTurn:
                break;
            case GameState.Shop:
                break;
            case GameState.Victory:
                break;
            case GameState.Defeat:
                break;
            default:
                throw new System.ArgumentOutOfRangeException(nameof(newState), newState, null); //look into what this actually is
        }


    }

}

public enum GameState{

    Intro,
    GenerateGrid,
    SpawnPlayer,
    SpawnEnemy,
    PlayerTurn,
    EnemyTurn,
    Shop,
    Victory,
    Defeat

}