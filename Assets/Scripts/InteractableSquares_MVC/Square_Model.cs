using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Square_Model
{
   public Square_Model(int id, Color color)
   {
        Id = id;
        Color = color;
    }

    public int Id { get; }
    public Color Color { get; }
}
