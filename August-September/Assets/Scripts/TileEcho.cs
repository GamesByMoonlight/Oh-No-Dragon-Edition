using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class TileEcho : MonoBehaviour {

    Collider m_ObjectCollider;
    private void Start()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Test");

    }

    void OnTriggerExit2D(Collider2D other)
    {
        m_ObjectCollider = GetComponent<Collider>();
        m_ObjectCollider.isTrigger = false;
        //Debug.Log("Trigger On : " + m_ObjectCollider.isTrigger);
    }
}
