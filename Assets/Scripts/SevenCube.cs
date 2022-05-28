using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SevenCube : Cube
{
    [SerializeField, Range(0, 1)] private float t;

    [SerializeField] private Transform _startPoint;

    private Cube _targetCube;

    private bool _targetWasChosen;
    private bool _isInAction;
    private bool _isResetPosition;

    public bool IsInAction { get; set; }

    private void Start()
    {
        SelectionService.TargetCubeWasChosen += TargetCubeWasChosen;
        SelectionService.ResetSevenCubePosition += OnResetPosition;
    }

    private void TargetCubeWasChosen(GameObject cube)
    {
        _targetCube = cube.GetComponent<Cube>();

        t = 0;

        GetSecondPoint();       

        Debug.Log($"{this.name}: 1p {this.Center} | 2p {this.SecondPoint} | 3p {_targetCube.SecondPoint} | 4p {_targetCube.Center}");

        _isInAction = true;
        _targetWasChosen = true;
    }

    private void Update()
    {
       

        if (_targetWasChosen)
        {
            Vector3 bezierPoint = Bezier.GetBezierPoin(this._startPoint.position, this.SecondPoint, _targetCube.SecondPoint, _targetCube.Center, t);

            t += Time.deltaTime / 2;


            this.transform.position = bezierPoint;
            this.transform.LookAt(_targetCube.LookPoint);

            if(t >= 1)
            {
                _targetWasChosen = false;
            }
        }
        else
        {
            Vector3 bezierPoint = _startPoint.position;
        }
    }

    private void OnResetPosition()
    {
        this.transform.position = _startPoint.position;
        IsInAction = false;
    }



    //private void OnDrawGizmosSelected()
    //{

    //    int sigmentsNumber = 20;

    //    Vector3 previousPoint = this.Center;

    //    for (int i = 0; i < sigmentsNumber + 1; i++)
    //    {
    //        float parameter = (float)i / sigmentsNumber;

    //        Vector3 point = Bezier.GetBezierPoin(this.Center, this.SecondPoint, _targetCube.Center, _targetCube.SecondPoint, t);
    //        Gizmos.DrawLine(previousPoint, point);
    //        previousPoint = point;
    //    }


    //}
}
