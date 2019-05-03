using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class User 
{
    public string ClassName;
    public int Score;

    public User()
    {
        ClassName = GameHandler.ClassName;
        Score = GameHandler.Score; 
    }
}
