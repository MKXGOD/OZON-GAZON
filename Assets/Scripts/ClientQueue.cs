using System.Collections.Generic;
using UnityEngine;

public class ClientQueue : MonoBehaviour
{
    [SerializeField] private DeliveryPackage _deliveryPackage;
    [SerializeField] private Client _clientPrefab;

    [SerializeField] private Transform _spawnPosition;
    [SerializeField] private Transform _placeIssue;

    private List<Client> _clients = new List<Client>();

    

    private Client Head;
    private Client Lox;

    private void Awake()
    {
        _deliveryPackage.NotifyOnDelivered += SpawnClient;
    }
    private void Update()
    {
        MoveQueue();
    }
    private void SpawnClient(int itemCode)
    {
        Client client = Instantiate(_clientPrefab);
        client.SetCode(itemCode);
        client.transform.position = _spawnPosition.position;
        AddInQueue(client);
    }
    private void AddInQueue(Client client)
    {
        _clients.Add(client);
        if (_clients.Count == 1)
        {
            SetHead(client);
        }
        else client.Agent.stoppingDistance = 2;

        client.OnGetPackage += LeaveRoom;

    }
    private void MoveQueue()
    {
        for (int i = 1; i < _clients.Count; i++)
        {
            _clients[i].Agent.SetDestination(_clients[i-1].transform.position);
        }
    }
    private void LeaveRoom()
    {
        _clients.Remove(Head);
        Lox = Head;
        Head = null;
        if (_clients.Count > 0)
            SetHead(_clients[0]);
        Lox.Agent.SetDestination(_spawnPosition.position);
        Lox.OnGetPackage -= LeaveRoom;
    }
    public void SetHead(Client client)
    {
        if (Head != null)
            return;
        Head = client;
        Head.Agent.stoppingDistance = 0.2f;
        Head.Agent.SetDestination(_placeIssue.position);
        
    }
}
