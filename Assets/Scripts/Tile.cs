using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public bool isNull = false;
    public string TileName;


    [SerializeField] private Color _baseColor, _offsetColor;
    [SerializeField] private SpriteRenderer _renderer;
    [SerializeField] private GameObject _highlight;
    [SerializeField] private bool isWalkable;

    public BaseUnit OccupiedUnit;
    public bool Walkable => isWalkable && OccupiedUnit == null;  //checks if the tile is walkable and not occupied





    public void Init(bool isOffset)
    {
        _renderer.color = isOffset ? _offsetColor : _baseColor; 
    }


    void OnMouseEnter()
    {
        _highlight.SetActive(true);
        MenuManager.Instance.ShowTileInfo(this, false); //show the ui
    }

    void OnMouseExit() //problem here
    {
        _highlight.SetActive(false);
        MenuManager.Instance.ShowTileInfo(this, true); //stop showing the ui
    }


    private void OnMouseDown()
    {
        if (GameManager.Instance.gameState != GameState.PlayerTurn) return;

        if(OccupiedUnit != null) //tiles are only occupied if a unit is on the tile
        {
            if (OccupiedUnit.faction == Faction.player) UnitManager.instance.SetSelectedPlayer((BasePlayer)OccupiedUnit, false); //if the faction is player, select it
            else
            {
                if(UnitManager.instance.SelectedPlayer != null) //if a player is already selected (add a range/legal path check)
                {
                    var enemy = (BaseEnemy)OccupiedUnit;
                    enemy.health = enemy.health - GameManager.Instance.power; //enemy health goes down by power
                    //if (enemy.health <= 0)
                    //{
                      //  Destroy(enemy.gameObject);
                    //}
                    UnitManager.instance.SetSelectedPlayer((BasePlayer)OccupiedUnit, true); //unselect player
                }
            }
        }


        else
        {
            if(UnitManager.instance.SelectedPlayer != null)
            {
                SetUnit(UnitManager.instance.SelectedPlayer);
                UnitManager.instance.SetSelectedPlayer((BasePlayer)OccupiedUnit, true); //unselect player
            }
        }



    }

    public void SetUnit(BaseUnit unit)
    {

        if (unit.OccupiedTile != null) unit.OccupiedTile.OccupiedUnit = null;
        unit.transform.position = transform.position; //places player on the spawn tile

        //keep track of position, so units can't move through each other
        OccupiedUnit = unit;
        unit.OccupiedTile = this;
    }


}
