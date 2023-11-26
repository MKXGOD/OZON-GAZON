using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private PlayerMovement _playerMovement;

    private CharacterController _characterController;


    [SerializeField] private float _speed;

    private void Awake()
    {
        _playerMovement = new PlayerMovement(this.gameObject, _speed);
        _characterController = GetComponent<CharacterController>();
    }
    private void Update()
    {
        _characterController.Move(_playerMovement.CharacterDirection());
    }
}
