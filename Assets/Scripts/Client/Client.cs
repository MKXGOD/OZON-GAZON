using UnityEngine;
using UnityEngine.AI;

public class Client : MonoBehaviour
{
   [SerializeField] private NavMeshAgent _agent;

    public void GoTo(Transform goal)
    {
        _agent.destination = goal.position;
    }
}
