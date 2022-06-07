using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseNode { 

    public BaseNode Connection { get; private set; }
    public float G { get; private set; }
    public float H { get; private set; }
    public float F => G + H; //lambda


    public void SetConnection(BaseNode baseNode) => Connection = baseNode;


    public void SetG(float g) => G = g; //sets the variable G to the new g

    public void SetH(float h) => H = h;

    internal float GetDistance(object neighbor)
    {
        throw new NotImplementedException();
    }
}
