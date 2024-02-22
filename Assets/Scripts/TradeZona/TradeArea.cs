using System.Collections.Generic;
using UnityEngine;

public class TradeArea : MonoBehaviour
{

    private List<Collider> _colliders = new List<Collider>();

    private void OnTriggerEnter(Collider other)
    {
        if (_colliders.Count <= 2)
            _colliders.Add(other);

        if (_colliders.Count == 2)
        {
            PackageTransfer();
        }
        else Debug.Log("Get client code");
    }
    private void PackageTransfer()
    {
        Client client;
        PlayerInventory playerInventory;

        if (_colliders[0].tag == "Player")
        {
            playerInventory = _colliders[0].GetComponent<PlayerInventory>();
            client = _colliders[1].GetComponent<Client>();
        }
        else
        {
            client = _colliders[0].GetComponent<Client>();
            playerInventory = _colliders[1].GetComponent<PlayerInventory>();
        }

        if (playerInventory.GetItem().IsEmpty == true)
        {
            Debug.Log($"Show code: {client.DeliveryCode}");
        }
        else
        {
            if (client.GetPackage(playerInventory.GetItem().ItemCode))
                Debug.Log("Thank you");
            else Debug.Log("It is not my mail");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (_colliders.Count != 0)
            _colliders.Remove(other);
    }
}
