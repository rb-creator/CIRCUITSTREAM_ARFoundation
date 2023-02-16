using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ARTapToPlace : MonoBehaviour
{
    [SerializeField] private ARPlaneManager _planeManager;
    [SerializeField] private ARRaycastManager _raycastManager;
    [SerializeField] private GameObject _robotPrefab;

    public GameObject ActivePrefab;
    private List<ARRaycastHit> _hits = new List<ARRaycastHit>();

    // Start is called before the first frame update
    void Start()
    {
        ActivePrefab = null;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount > 0) //check if screen has been tapped
        {
            if (ActivePrefab ==null)
            {
                if (_raycastManager.Raycast(Input.GetTouch(0).position, _hits, TrackableType.PlaneWithinPolygon))
                {
                    Pose hitpose = _hits[0].pose;

                    ActivePrefab = Instantiate(_robotPrefab, hitpose.position, Quaternion.identity); //Instantiate the robot
                }
            }
        } 

    }
}
