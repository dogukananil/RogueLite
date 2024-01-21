using System.Collections;
using System.Collections.Generic;
using Managers;
using UnityEngine;

public class Map : MonoBehaviour
{
   private MapController _mapController;

    public GameObject targetMap;

    void Start()
    {
        _mapController = FindObjectOfType<MapController>();
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            _mapController.currentMap = targetMap;
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            if (  _mapController.currentMap == targetMap)
            {
                _mapController.currentMap = null;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            GameManager.Instance.mapController.SetActivateOfMap();
        }
    }
}
