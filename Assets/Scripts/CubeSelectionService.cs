using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSelectionService : MonoBehaviour
{
    [SerializeField] private Camera _camera;

    [SerializeField] private SevenCube _sevenCube;

    public event Action<GameObject> TargetCubeWasChosen;
    public event Action ResetSevenCubePosition;

    private void Start()
    {
        _camera = Camera.main;
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0) && !_sevenCube.IsInAction)   
        {
            RaycastHit hit;
            if(Physics.Raycast(_camera.ScreenPointToRay(Input.mousePosition), out hit))
            {
                if(hit.collider.tag == "Cube")
                {
                    _sevenCube.IsInAction = true;
                    OnHitCube(hit.collider.gameObject);
                    Debug.Log("Current = " + hit.collider.gameObject.name);
                }
            }
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            OnResetSevenCubePosition();
        }
    }

    private void OnResetSevenCubePosition()
    {
        ResetSevenCubePosition.Invoke();
    }

    private void OnHitCube(GameObject cube)
    {
        TargetCubeWasChosen.Invoke(cube);

        //Debug.Log(cube.name);
    }

}
