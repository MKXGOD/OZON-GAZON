using UnityEngine;

public class PlayerMovement
{
    private float _speed;
    private GameObject _player;

    public PlayerMovement(GameObject player, float speed)
    {
        _speed = speed;
        _player = player;
    }
    public Vector3 CharacterDirection()
    {
        var characterVelocity = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")) * _speed;

        characterVelocity = _player.transform.InverseTransformDirection(characterVelocity);
        characterVelocity = Vector3.ClampMagnitude(characterVelocity, _speed);

        return characterVelocity * Time.deltaTime;
    }
}
