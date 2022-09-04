using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gamelevel
{
    public string name { get; }
    public int NumOfMirrors { get; }
    public int NumOfLamps { get; }
    public bool Haspattern { get; }
    public int score { get; set; }
    public float timer { get; }
    public int ID;
    public int light;

    public Gamelevel( int ID ,string name , float timer , int Nmirrors , int Nlamps ,bool pattern , int light)
    {
        this.name = name;
        this.timer = timer;
        this.NumOfMirrors = Nmirrors;
        this.NumOfLamps = Nlamps;
        this.Haspattern = pattern;
        score = 0;
        this.ID = ID;
        this.light = light;
        this.score = (int)((50 / this.NumOfMirrors) + (this.NumOfLamps * 20) + (100 / this.light) + (1000/(this.timer)* this.timer));


    }
}
/**/