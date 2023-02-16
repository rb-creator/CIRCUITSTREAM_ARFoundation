using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    [SerializeField] private Transform _turretHead;
    [SerializeField] private float _turnSpeed;

    private Robot _robot;

    private void OnEnable()
    {
        _robot = GameObject.Find("Blue_Robot").GetComponent<Robot>();
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_robot != null)
        {
            Vector3 targetDirection = _robot.transform.position - transform.position;
            Vector3 direction = Vector3.RotateTowards(transform.forward, targetDirection, _turnSpeed * Time.deltaTime, 0);
            transform.rotation = Quaternion.LookRotation(direction);
        }
    }
}
