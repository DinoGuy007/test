using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Unit", menuName = "Scriptable Unit")]


public class ScriptableUnit : ScriptableObject
{
    public Faction Faction; //look this up

    public BaseUnit UnitPrefab;

}


public enum Faction
{
    player = 0,
    enemy = 1
}