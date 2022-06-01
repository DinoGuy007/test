using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;
using Random = UnityEngine.Random;

public class GridManager : MonoBehaviour
    
{

    public static GridManager InstanceG;
    public string test = "hello";


    [SerializeField] private int _width, _height;

    [SerializeField] private Tile _grassTile, _boulderTile;

    [SerializeField] private Transform _cam;


    private Dictionary<Vector2, Tile> _tiles;




    void Awake()
    {
        Debug.Log("HI!!!!!!!!");
        InstanceG = this;
        GenerateGrid();
    }
    

    public void GenerateGrid()
    {
        _tiles = new Dictionary<Vector2, Tile>();
        for (int x = 0; x < _width; x++)
        {
            for (int y = 0; y < _height; y++)
            {
                var randomtile = Random.Range(0, 6) == 3 ? _boulderTile : _grassTile; //if the random number between 0 and 6 is 3, spawn a boulder. could add more logic here
               
                var spawnedTile = Instantiate(randomtile, new Vector3(x, y), Quaternion.identity); //spawns the random tile
                spawnedTile.name = $"Tile{x} {y}";


                var isOffset = (x + y) % 2 == 1; //checkerboard
                spawnedTile.Init(isOffset);

                _tiles[new Vector2(x, y)] = spawnedTile;
            }
        }



        _cam.transform.position = new Vector3((float)_width / 2 - 0.5f, (float)_height / 2 - 0.5f, -10);


        GameManager.Instance.updateGameState(GameState.SpawnPlayer);
    }

    public Tile GetPlayerSpawnTile()
    {
        return _tiles.Where(t => t.Key.x < _width / 2 && t.Value.Walkable).OrderBy(tag => Random.value).First().Value; //spawns player on the left side of the map on a walkable tile
    }

    public Tile GetEnemySpawnTile()
    {
        return _tiles.Where(t => t.Key.x > _width/2 && t.Value.Walkable).OrderBy(tag => Random.value).First().Value; //spawns enemy on the right side of the map on a walkable tile
    }

    public Tile GetTileAtPosition(Vector2 position)
    {
        if(_tiles.TryGetValue(position, out var tile))
        {
            return tile;
        }
        return null; 

    }


}
