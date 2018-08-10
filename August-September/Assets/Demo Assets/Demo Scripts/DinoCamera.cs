using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinoCamera : MonoBehaviour {

    // Public game objects, such as this one, must be assigned in the inspector
    // It's better to use FindObjectOfType<>() methods, but this works well for quick prototyping.
    public GameObject dinoObject;

    void Update()
    {
        // This moves the position of the camera to be equal to the transform.position.x of the dino, but maintains the camera position
        // transform.position must be assigned as a Vector2 or Vector3.  The transform.position.x,y,z components cannot be modified directly
        transform.position = new Vector3(dinoObject.transform.position.x, transform.position.y, transform.position.z);

        // Remove the comments here and see for yourself!
        // transform.position.x = dinoObject.transform.position.x;
    }
}
