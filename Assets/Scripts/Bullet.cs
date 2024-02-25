using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Rigidbody _rigidbody;

    public void SetDirection(Vector3 direction)
    {
        _rigidbody.transform.up = direction;
        _rigidbody.velocity = direction * _speed;
    }
}
