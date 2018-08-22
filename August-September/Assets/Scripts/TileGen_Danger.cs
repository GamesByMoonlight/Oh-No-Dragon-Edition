using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileGen_Danger : MonoBehaviour {


    public Tilemap tilemap; // The layer with the collidable objects
    public TileBase fireTile;
    public TileBase waterTile;
    public TileBase earthTile;
    public TileBase windTile;

    // Use this for initialization
    void Start () {

        //tilemap.SetTile(new Vector3Int(0, 1, 0), fireTile);
       // tilemap.SetTile(new Vector3Int(0, 2, 0), waterTile);
       // tilemap.SetTile(new Vector3Int(0, 3, 0), earthTile);
       // tilemap.SetTile(new Vector3Int(0, 4, 0), windTile);

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
