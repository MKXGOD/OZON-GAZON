using System.Collections.Generic;
using UnityEngine;

public class ClientQueue : MonoBehaviour
{
    [SerializeField] private DeliveryPackage _deliveryPackage;

    [SerializeField] private Client _clientPefab;

    [SerializeField] private Transform _goal;

    [field: SerializeField] public Queue<Client> _clientQueue = new Queue<Client>();

    private void Start()
    {
        for (int i = 0; i < 5; i++)
        {
            Client client = Instantiate(_clientPefab);
            _clientQueue.Enqueue(client);
            Go();
        }
    }

    private void Go()
    { 
        if (_clientQueue.Count > 0) 
        {
            var client = _clientQueue.Peek();
            client.GoTo(_goal);
        }
    }
}
