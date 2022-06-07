using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class Pathfinding : MonoBehaviour
{
  
    public static List<BaseNode> FindPath(BaseNode startNode, BaseNode targetNode)
    {
        var toSearch = new List<BaseNode>() { startNode };
        var processed = new List<BaseNode>();

        while (toSearch.Any())
        {
            var current = toSearch[0]; //sets first part of toSearch array
            

            foreach(var t in toSearch) //checks if the other nodes have better F scores
                
                if(t.F < current.F || t.F == current.F && t.H < current.H) //or the same F score and lower H cost

                    current = t; //current is the best choice
                
                processed.Add(current);
                toSearch.Remove(current);

            if(current == targetNode)
            {
                var currentPathTile = targetNode;
                var path = new List<BaseNode>();
                while (currentPathTile != startNode)
                {
                    path.Add(currentPathTile);
                    currentPathTile = currentPathTile.Connection;
                }
                return path; //once it checks everything
            }
            

            foreach(var neighbor in current.Neighbors.Where(t => t.Walkable && !processed.Contains(t))) //looping over all the neighbors (after getting F cost)
            {
                var inSearch = toSearch.Contains(neighbor);

                var costToNeighbor = current.G + current.GetDistance(neighbor); //determines cost to move to a certain spot

                if(!inSearch || costToNeighbor < neighbor.G) //if NOT inSearch list or cost to a neighbor is lower cost (better cost)
                {
                    neighbor.SetG(costToNeighbor); //new G value
                    neighbor.SetConnection(current);


                    if (!inSearch)
                    {
                        neighbor.SetH(neighbor.GetDistance(targetNode));
                        toSearch.Add(neighbor);
                    }
                }


            }



        }

        Debug.Log("messed up"); //so I know
        return null; //if it messes up
    



    }



}
