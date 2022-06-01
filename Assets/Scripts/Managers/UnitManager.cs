using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UnitManager : MonoBehaviour
{
    public static UnitManager instance;


    private List<ScriptableUnit> _units;

    public BasePlayer SelectedPlayer;


    void Awake()
    {
        instance = this;

        _units = Resources.LoadAll<ScriptableUnit>("Units").ToList();
    }


    public void SpawnPlayer() //will spawn a random player sprite, cat or dog
    {
        var playerCount = 1;

        for (int i = 0; i < playerCount; i++)
        {
            var randomPrefab = GetRandomUnit<BasePlayer>(Faction.player);
            var spawnedPlayer = Instantiate(randomPrefab); //takes a random prefab from player
            var randomSpawnTile = GridManager.InstanceG.GetPlayerSpawnTile();

            randomSpawnTile.SetUnit(spawnedPlayer);

        }

        GameManager.Instance.updateGameState(GameState.SpawnEnemy);

    }

    public void SpawnEnemy()
    {
        var enemyCount = 1;

        for (int i = 0; i < enemyCount; i++)
        {
            var randomPrefab = GetRandomUnit<BaseEnemy>(Faction.enemy);
            var spawnedEnemy = Instantiate(randomPrefab); //takes a random prefab from enemies
            var randomSpawnTile = GridManager.InstanceG.GetEnemySpawnTile();

            randomSpawnTile.SetUnit(spawnedEnemy);

        }

        GameManager.Instance.updateGameState(GameState.PlayerTurn);


    }


    private T GetRandomUnit<T>(Faction faction) where T : BaseUnit  //gets a random unit 
    {
        return (T)_units.Where(u => u.Faction == faction).OrderBy(o => Random.value).First().UnitPrefab;
    }

    public void SetSelectedPlayer(BasePlayer player)
    {
        SelectedPlayer = player;
    }



}
