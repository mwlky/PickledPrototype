using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnDestiny : MonoBehaviour
{
    [SerializeField] private MousePosition mouseController;
    [SerializeField] private GameObject destinyPoint;
    [SerializeField] private string groundTag;
    
    private void OnEnable()
    {
        InputController.onSpawnDestiny += CheckTag;
    }

    private void OnDisable()
    {
        InputController.onSpawnDestiny -= CheckTag;
    }

    void SpawnDestinyPoint(Vector3 position)
    {
        destinyPoint.transform.position = position;
    }

    void CheckTag()
    {
        RaycastHit hit = mouseController.GetObjectThatPlayerClicked();
        
        GameObject clickedObject = hit.transform.gameObject;
        Vector3 position = hit.point;

        if(clickedObject.CompareTag(groundTag))
            SpawnDestinyPoint(position);
    }
}
