using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileGen_Ground : MonoBehaviour {

    public Tilemap tilemap; // The layer with the collidable objects
    public int MapLength = 0;
    public int MapXStart = 0;
    public TileBase groundTile;

    // Use this for initialization
    void Start () {

        // Draw ground.
        for (int i = 0; i < MapLength; i++)
            for (int j = 0; j < 10; j++)
                tilemap.SetTile(new Vector3Int(MapXStart + i, -5 + j, 0), groundTile);


    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
