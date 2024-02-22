using UnityEngine;
using UnityEngine.AI;

public class Client : MonoBehaviour
{
   [SerializeField] private NavMeshAgent _agent;

   public NavMeshAgent Agent => _agent;

   public int DeliveryCode { get; private set; }

   public delegate void DeliveryHandler();
   public event DeliveryHandler OnGetPackage;

   public void SetCode(int code)
   { 
        DeliveryCode = code;
   }
   public bool GetPackage(int code)
   {
        if (code == DeliveryCode)
        {
            OnGetPackage?.Invoke();
            return true;
        }
       return false;

   }
}
