using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    #region Default task

    [SerializeField] private Transform _center;
    [SerializeField] private Transform _secondPoint;
    [SerializeField] private Transform _lookPoint;

    [SerializeField] private CubeSelectionService _selectionService;

    public bool IsTargetCube { get; set; }

    public Vector3 Center { get { return _center.position; } }
    public Vector3 SecondPoint { get { return _secondPoint.position; } }
    public Vector3 LookPoint { get { return _lookPoint.position; } }
    public CubeSelectionService SelectionService { get { return _selectionService; } }

    private void Start()
    {
        _selectionService.TargetCubeWasChosen += OnTargetChosen;
    }


    public void GetSecondPoint()
    {
        this._secondPoint.position = new Vector3(Random.Range(0, 6), Random.Range(0, 6), this.transform.position.z);
    }

    private void OnTargetChosen(GameObject cube)
    {
        if (cube.name != this.name)
            return;

        GetSecondPoint();
    }

    #endregion

    #region Hard task

    //[SerializeField] private Transform _center;
    //[SerializeField] private Transform _secondPoint;
    //[SerializeField] private Transform _lookPoint;

    //[SerializeField] private CubeSelectionService _selectionService;

    //private GameObject[] _cubes;
    //private Cube _nearest;

    //public Vector3 Center { get { return _center.position; } }
    //public Vector3 SecondPoint { get { return _secondPoint.position; } }
    //public Vector3 LookPoint { get { return _lookPoint.position; } }
    //public CubeSelectionService SelectionService { get { return _selectionService; } }

    //private void Start()
    //{
    //    _selectionService.TargetCubeWasChosen += OnTargetChosen;

    //    _cubes = GameObject.FindGameObjectsWithTag("Cube");
    //}


    //public void GetSecondPoint()
    //{
    //    this._secondPoint.position = new Vector3(Random.Range(0, 6), Random.Range(0, 6), Random.Range(0, 6));
    //}

    //private void GetSecondPoint(bool taskIsHarder)
    //{
    //    if (taskIsHarder)
    //        this._secondPoint.position = FindNearestCube().Center;
    //}

    //private Cube FindNearestCube()
    //{
    //    float distance = Mathf.Infinity;

    //    Vector3 position = this.transform.position;

    //    foreach (GameObject cube in _cubes)
    //    {
    //        Vector3 difference = cube.transform.position - position;
    //        float currentDistance = difference.sqrMagnitude;

    //        if (currentDistance < distance && cube.name != this.name)
    //        {
    //            _nearest = cube.GetComponent<Cube>();

    //            distance = currentDistance;
    //        }
    //    }
    //    return _nearest;
    //}

    //private void OnTargetChosen(GameObject cube)
    //{
    //    if (cube.name != this.name)
    //        return;

    //    GetSecondPoint(true);
    //}

    #endregion
}
