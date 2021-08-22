using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Mover : MonoBehaviour
{
    InputHandler _input;

    public float moveSpeed;

    public float rotateSpeed;



    private bool rotateTowardsMouse = false;
    [SerializeField] Camera camera;


    private void Awake()
    {
        _input = GetComponent<InputHandler>();

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetVector = new Vector3(_input.InputVector.x , 0 ,_input.InputVector.y);


        // move in the direction we are aiming
        var movementVector =  MovetowardTarget(targetVector);

        if (!rotateTowardsMouse)
            // rotate in the direction we are traveling
            RotateTowardMovementVector(movementVector);
        else
            RotateTowardMouseVector();
    }

    private void RotateTowardMouseVector()
    {
        Ray ray = camera.ScreenPointToRay(_input.MousePosition);

        if (Physics.Raycast(ray, out RaycastHit hitInfo, maxDistance: 300f))
        {
            var target = hitInfo.point;
            target.y = transform.position.y;
            transform.LookAt(target);
        }

    }

    private void RotateTowardMovementVector(Vector3 movementVector)
    {
        if(movementVector.magnitude == 0 )
        {
            return;
        }
        var rotation = Quaternion.LookRotation(movementVector);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, rotateSpeed);
    }

    private Vector3 MovetowardTarget(Vector3 targetVector)
    {
        float speed = moveSpeed * Time.deltaTime;

        targetVector = Quaternion.Euler(0, camera.gameObject.transform.eulerAngles.y, 0) * targetVector;
        Vector3 targetPosition = transform.position + targetVector * speed;

        transform.position = targetPosition;

        return targetVector;
    }
}
