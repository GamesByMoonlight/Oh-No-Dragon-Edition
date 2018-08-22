using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileGen_Boundary : MonoBehaviour {

    public Tilemap tilemap; // The layer with the collidable objects
    public TileBase topTile;
    public TileBase bottomTile;
    public TileBase leftTileWall;
    public TileBase rightTileWall;
    public TileBase groundTile;
    public int MapLength = 0;
    public int MapXStart = 0;

    // Use this for initialization
    void Start () {

        // Set the top and bottom walls.
        for (int i = 0; i < MapLength; i++)
        {
            // Draw top walls.
            tilemap.SetTile(new Vector3Int(MapXStart + i, 4, 0), topTile);
            tilemap.SetTile(new Vector3Int(MapXStart + i, 3, 0), bottomTile);

            // Draw bottom walls.
            tilemap.SetTile(new Vector3Int(MapXStart + i, -4, 0), topTile);
            tilemap.SetTile(new Vector3Int(MapXStart + i, -5, 0), bottomTile);



        }

        //Set the left endcap.
        for (int i = 0; i < 10; i++)
        {
            tilemap.SetTile(new Vector3Int(MapXStart - 1, i - 5, 0), leftTileWall);
        }

        //Set the right endcap.
        for (int i = 0; i < 10; i++)
        {
            tilemap.SetTile(new Vector3Int(MapLength, i - 5, 0), rightTileWall);
        }

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
