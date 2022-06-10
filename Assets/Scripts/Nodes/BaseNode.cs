using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseNode { 

    public BaseNode Connection { get; private set; }
<<<<<<< HEAD
    public List<BaseNode> Neighbors { get; protected set; }
=======


    public List<BaseNode>Neighbors { get; protected set; } //protected can only be accessed by children
>>>>>>> main
    public float G { get; private set; }
    public float H { get; private set; }
    public float F => G + H; //lambda
    public bool _selected;
    public bool Walkable { get; private set; }


    public static event Action<BaseNode> OnHoverTile;

 
    public void onEnable() => OnHoverTile += OnOnHoverTile;
    public void onDisable() => OnHoverTile -= OnOnHoverTile;
    public void OnOnHoverTile(BaseNode selected) => _selected = selected == this; //



    
    

    public bool Walkable { get; private set; }

    public bool _selected;


    public static event Action<BaseNode> OnHoverTile;
    private void OnEnable() => OnHoverTile += OnOnHoverTile;
    private void OnDisable() => OnHoverTile -= OnOnHoverTile;
    private void OnOnHoverTile(BaseNode selected) => _selected = selected == this;



    public void SetConnection(BaseNode baseNode) => Connection = baseNode;




    public void SetG(float g) => G = g; //sets the variable G to the new g

    public void SetH(float h) => H = h;

    internal float GetDistance(object neighbor)
    {
        throw new NotImplementedException();
    }
}
