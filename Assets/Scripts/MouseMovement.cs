using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MouseMovement : MonoBehaviour
{
    private Camera camera;

    private bool isMove;
    private Vector3 destination;
    public float moveSpeed;

    private NavMeshAgent agent;
    private
    void Awake()
    {
        camera = Camera.main;
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            RaycastHit hit;
            if (Physics.Raycast(camera.ScreenPointToRay(Input.mousePosition), out hit))
            {
                SetDestination(hit.point);
            }
        }
        LookMoveDirection();
    }
    private void SetDestination(Vector3 dest)
    {
        agent.SetDestination(dest);

        destination = dest;
        isMove = true;
    }
    private void LookMoveDirection()
    {
        if (isMove)
        {
            //if (Vector3.Distance(transform.position, destination) <= 0.1f)
            if(agent.velocity.magnitude == 0f) // 캐릭터가 엉뚱한 방향 바라보지 않게 하기
            {
                isMove = false;
                return;
                // move animtaion stop
            }
            
            // animation play;
        }
        //var dir = destination - transform.position;
        var dir = new Vector3(agent.steeringTarget.x, transform.position.y, agent.steeringTarget.z) - transform.position;
        transform.forward = dir;
        //transform.position += dir.normalized * Time.deltaTime * moveSpeed; // use navmesh 
    }


}
