using UnityEngine;
using UnityEngine.AI;

public class UnitMovement : MonoBehaviour
{
    Camera camera;
    NavMeshAgent agent;
    public LayerMask ground;

    private Vector3 destination;
    public float rotateSpeed;

    public bool isMove;
    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main;
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            RaycastHit hit;
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, ground))
            {
                //agent.SetDestination(hit.point);
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
        if(isMove)
        {
            if(agent.velocity.magnitude == 0f)
            {
                isMove = false;
                // move animation stop
                return;
            }

            // move animation play
        }
        var dir = new Vector3(agent.steeringTarget.x, transform.position.y, agent.steeringTarget.z) - transform.position;
        transform.forward = dir;
    }

   
}
