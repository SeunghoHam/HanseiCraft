using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToTarget : MonoBehaviour
{
    /*
    public Transform[] targets;
    public float speed = 15.0f;
    Transform tran;
    int targetIndex = 0;

    private void Start()
    {
        tran = gameobject.GetComponent<Transform>();
    }

    private void Update()
    {
        UpdateMove();
    }


    void UpdateMove()
    {
        if(targets.Length <= 0)
            return;
        Vector3 dir = targets[targetIndex].position - tran.position;
        dir.Normalize();
        dir *= speed * Time.deltaTime;
        tarn.position += dir;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameobject.GetComponent<Transform>() == targets[targetIndex])
        {
            ChangeTarget();
        }
    }

    void ChangeTarget()
    {
        targetIndex++;
        if(targetIndex > targets.Length -1 )
            targetIndex = 0;
    }*/
}
