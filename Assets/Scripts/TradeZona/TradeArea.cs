using System.Collections.Generic;
using UnityEngine;

public class TradeArea : MonoBehaviour
{
    private int _itemCode;
    private List<Collider> _colliders = new List<Collider>();

    private void OnTriggerEnter(Collider other)
    {
        _colliders.Add(other);
        if (other.tag == "Client")
            Debug.Log("Get client code");

        if (_colliders.Count > 1)
            Debug.Log($"Show code: {_itemCode}");
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Mail")
        {
            var mail = other.gameObject.GetComponent<ItemObject>();

            if (mail.GetCode() == _itemCode)
                Debug.Log("Take mail");
            else Debug.Log("It is not my mail");
        }
         
    }
    private void OnTriggerExit(Collider other)
    {
      _colliders.Remove(other);
    }
}
