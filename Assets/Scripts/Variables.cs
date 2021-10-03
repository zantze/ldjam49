using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Variables 
{
    public static Variables current;

    public enum Difficulty
    {
        EASY, HARD
    }

    public Difficulty difficulty = Difficulty.EASY;

    public int score = 0;

    public Variables()
    {
        current = this;
    }
}
