using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Square_Controller
{
    public Square_Controller(Square_Model square_Model, Square_View square_View)
    {
        Square_Model = square_Model;
        Square_View = square_View;

        square_View.initialize(this);
    }

    public Square_Model Square_Model { get; }
    public Square_View Square_View { get; }
}
