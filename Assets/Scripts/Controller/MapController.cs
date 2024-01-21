using System;
using System.Collections;
using System.Collections.Generic;
using Managers;
using Player;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class MapController : MonoBehaviour
{
    [SerializeField] private List<GameObject> maps;
    [SerializeField] private float radiusChecker;
    public LayerMask mapLayerMask;
    [HideInInspector]public GameObject currentMap;
    
    private Vector3 _newMapPosition;
    private readonly Vector3[] _directions =
    {
        Vector3.right, Vector3.left, Vector3.up, Vector3.down,
        new (1, 1, 0), new Vector3(1, -1, 0),
        new(-1, 1, 0), new(-1, -1, 0)
    };
    
    [SerializeField] private List<GameObject> spawnedMaps;
    public float maxDistanceWithMap;
    
    private GameObject _latestMap;
    private float _currentDistance;

    private void Start()
    {
        spawnedMaps.Add(currentMap);
    }

    private void Update()
    {
        CheckMap();
    }

    private void CheckMap()
    {
        if(!currentMap)
        {
            return;
        }
        var playerMovementMoveDirection = GameManager.Instance.playerController.playerMovement.moveDirection;
        for (int i = 0; i < _directions.Length; i++)
        {
            Vector3 offset = _directions[i] * 16;
            if (playerMovementMoveDirection.x * offset.x > 0 || playerMovementMoveDirection.y * offset.y > 0)
            {
                if (!Physics2D.OverlapCircle(currentMap.transform.position+offset, radiusChecker, mapLayerMask))
                {
                    _newMapPosition = currentMap.transform.position+offset;
                    SpawnMap();
                    break; 
                }
            }
        }
    }

    private void SpawnMap()
    {
        int rand = Random.Range(0, maps.Count);
        _latestMap= Instantiate(maps[rand], _newMapPosition, Quaternion.identity);
        _latestMap.transform.parent = transform;
        spawnedMaps.Add(_latestMap);
    }

    public void SetActivateOfMap()
    {
        foreach (var map in spawnedMaps)
        {
            _currentDistance = Vector3.Distance(GameManager.Instance.playerController.transform.position, map.transform.position);
            if (_currentDistance > maxDistanceWithMap)
            {
                map.SetActive(false);
            }
            else
            {
                map.SetActive(true);
            }
            
        }
    }
}