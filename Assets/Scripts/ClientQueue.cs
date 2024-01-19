using System.Collections.Generic;
using UnityEngine;

public class ClientQueue : MonoBehaviour
{
    [SerializeField] private Client _clientPrefab;
    [SerializeField] private Transform _LeaveRoomPosition;
    [SerializeField] private Transform _deliveryPlace;

    private Transform _spawnPosition;
    
    private List<Client> _clients = new List<Client>();

    private Client _firstOut;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
            AddInQueue();

        if (Input.GetKeyDown(KeyCode.L))
            LeaveRoom();

            if (_clients.Count > 1)
            MoveQueue();
    }
    public void AddInQueue()
    {
        var cylinder = Instantiate(_clientPrefab);
        if (_clients.Count == 0)
        {
            cylinder.Agent.stoppingDistance = 1;
            cylinder.Agent.SetDestination(_deliveryPlace.position);
            _firstOut = cylinder;
        }
        else cylinder.Agent.stoppingDistance = 2;
        
        _clients.Add(cylinder);
        
    }
    public void MoveQueue()
    {
        for (int i = 1; i < _clients.Count; i++)
        {
            _clients[i].Agent.SetDestination(_clients[i-1].transform.position);
        }
    }

    public void LeaveRoom()
    {
        _clients.Remove(_firstOut);
        _firstOut.Agent.SetDestination(_LeaveRoomPosition.position);

        if (_clients.Count > 0)
        {
            _clients[0].Agent.stoppingDistance = 0;
            _clients[0].Agent.SetDestination(_deliveryPlace.position);
            _firstOut = _clients[0];
        }
    }
}
