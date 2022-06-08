using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance;

    [SerializeField] private GameObject _SelectedPlayerObject, _tileUnitObject, _tileObject;


    void Awake()
    {
        Instance = this; //sets instance
    }

    public void ShowTileInfo(Tile tile, bool isNull) //tile can't be null, change in tile
    {

        if(isNull || tile == null)
        {
            _tileObject.SetActive(false);
            _tileUnitObject.SetActive(false);
            return;
        }

        
            _tileObject.GetComponentInChildren<Text>().text = tile.TileName;
            _tileObject.SetActive(true);
        
        

        if (tile.OccupiedUnit) //if the tile is occupied
        {
            _tileUnitObject.GetComponentInChildren<Text>().text = tile.OccupiedUnit.UnitName;
            _tileUnitObject.SetActive(true);
        }
    }




    public void ShowSelectedPlayer(BasePlayer player, bool isNull)
    {
        if(isNull)
        {
            _SelectedPlayerObject.SetActive(false);
            return;
        }
       
            _SelectedPlayerObject.GetComponentInChildren<Text>().text = player.UnitName;
            _SelectedPlayerObject.SetActive(true);
        
    }



}
