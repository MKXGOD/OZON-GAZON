using System.Collections.Generic;
using UnityEngine;

public class ClientQueue : MonoBehaviour
{
    [SerializeField] private Client _client;
    [SerializeField] private Transform _destination;
    [SerializeField] private Transform _leaveRoom;

    private Queue<GameObject> _queuePeople = new Queue<GameObject>();
    private GameObject _lastIn;
    private GameObject _lastOut;

    public Queue<Client> _queueClient = new Queue<Client>();

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
            AddQueueCLient();
        else if (Input.GetKeyDown(KeyCode.X))
            Leave();
       // else if (Input.GetKeyDown(KeyCode.C))
            //ckupOrder(_queueClient[0]);
    }
    /*private void Spawn()
     {
         var people = Instantiate(_client);
         people.transform.position = new Vector3(0, 0, 0);

         if (_queuePeople.Count == 0)
         {
             people.Agent.stoppingDistance = 0;
             people.Agent.SetDestination(_destination.position);
         }
         else
         {
             people.Agent.stoppingDistance = 1.5f;
             people.Agent.SetDestination(_lastIn.transform.position);
         }

         _queuePeople.Enqueue(people.gameObject);
         _lastIn = people.gameObject;
     }
     private void LeftQueue()
     {
         Destroy(_queuePeople.Dequeue());
     }*/

    private void AddQueueCLient()
    {
        var client = Instantiate(_client);
        client.transform.position = Vector3.zero;
        _queueClient.Enqueue(client);
        
        
        
        /*if (_queueClient.Count == 1)
        {
            client.Agent.stoppingDistance = 0;
            client.Agent.SetDestination(_destination.position);
        }
        else if (_queueClient.Count > 1)
        {
            client.Agent.stoppingDistance = 1.5f;
            client.Agent.SetDestination(_lastIn.transform.position);
        }

        _lastIn = client.gameObject;*/
    }
    private void Leave()
    {
        if (_queueClient.Count != 0)
        {
            _queueClient[0].Agent.SetDestination(_leaveRoom.position);
            _queueClient.RemoveAt(0);
            _queueClient[0].Agent.SetDestination(_destination.position);
        }
    }
}
