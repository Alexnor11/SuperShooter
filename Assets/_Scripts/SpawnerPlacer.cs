using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.XR.ARFoundation;

public class SpawnerPlacer : MonoBehaviour
{
    ARRaycastManager raycastManager;
    public GameObject spawnerPrefab;
    
    List<ARRaycastHit> hits = new List<ARRaycastHit>();

    private void Awake()
    {
        raycastManager = GetComponent<ARRaycastManager>();
    }

    private void Update()
    {
        var touchPos = Touchscreen.current.primaryTouch.position.ReadValue();

        if(Touchscreen.current.primaryTouch.press.wasPressedThisFrame && raycastManager.Raycast(touchPos, hits))
        {
            Instantiate(spawnerPrefab, hits[0].pose.position, hits[0].pose.rotation);
        }
    }
}
