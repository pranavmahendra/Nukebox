using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Square_Model
{
   public Square_Model(ButtoScriptable buttonScriptable)
   {
        Id = buttonScriptable.id;
        Color = buttonScriptable.Color;
    }

    public int Id { get; }
    public Color Color { get; }
}
