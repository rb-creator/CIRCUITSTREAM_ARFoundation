using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _turnSpeed;
    [SerializeField] private Rigidbody _robotBody;
    [SerializeField] private Animator _robotAnim;

    private Joystick _joystick;

    private void OnEnable()
    {
        _joystick = FindObjectOfType<Joystick>(); 
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //rotate robot
        Vector3 targetDirection = new Vector3(_joystick.Direction.x, 0, _joystick.Direction.y);
        Vector3 direction = Vector3.RotateTowards(transform.forward, targetDirection, _turnSpeed * Time.deltaTime, 0);
        transform.rotation = Quaternion.LookRotation(direction);

        //move robot
        if (_joystick.Direction.magnitude > 0)
        {
            _robotBody.AddForce(_moveSpeed * transform.forward);
            _robotAnim.SetBool("Running", true);
        }
        else
        {
            _robotAnim.SetBool("Running", false);
        }
    }
}
