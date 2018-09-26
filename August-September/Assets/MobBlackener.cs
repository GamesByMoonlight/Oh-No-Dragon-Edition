using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobBlackener : MonoBehaviour {

    SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void OnEnable()
    {
        EventManager.OnLevelEnd += BlackenTheMob;
    }

    void OnDisable()
    {
        EventManager.OnLevelEnd -= BlackenTheMob;
    }

    void BlackenTheMob()
    {
        InvokeRepeating("SlowlyBurn", 1f, 0.1f);
    }

    void SlowlyBurn()
    {
        Color darkerColor = spriteRenderer.color;
        darkerColor -= new Color(0.1f, 0.1f, 0.1f, 0);

        spriteRenderer.color = darkerColor;

        if (darkerColor == Color.black)
        {
            CancelInvoke("SlowlyBurn");
        }
    }
}
