using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLives  {

    public static int Lives { get; set; }
    

    public static void RemoveLife()
    {
        Lives = Mathf.Max(Lives-1, 0);
    }

    public static void ResetLives(int lives)
    {
        Lives = lives;
    }
}
