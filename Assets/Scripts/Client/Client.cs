using UnityEngine;
using UnityEngine.AI;

public class Client : MonoBehaviour
{
   [SerializeField] private NavMeshAgent _agent;
    public NavMeshAgent Agent => _agent;
}
