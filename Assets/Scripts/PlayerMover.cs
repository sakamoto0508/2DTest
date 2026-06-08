
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMover
{
    public PlayerMover(Rigidbody2D rb, PlayerConfig config)
    {
        _rb = rb;
        _config = config;
    }

    private Rigidbody2D _rb;
    private PlayerConfig _config;
    private Vector2 _input;

    public void Tick()
    {
        Move();
    }

    public void Input(Vector2 input)
    {
        _input = input;
    }

    private void Move()
    {
        Vector2 velocity = _rb.linearVelocity;
        if (_input != Vector2.zero)
        {
            if (Mathf.Abs(velocity.x) < _config.MoveSpeed)
            {
                _rb.AddForce(new Vector2(_input.x * _config.Acceleration, 0), ForceMode2D.Force);
            }
            else
            {
                velocity.x = _input.x * _config.MoveSpeed;
                _rb.linearVelocity = velocity;
            }
        }
        else
        {
            if (Mathf.Abs(velocity.x) > 0.1f)
            {
                _rb.AddForce(new Vector2(-Mathf.Sign(velocity.x) * _config.Deceleration, 0), ForceMode2D.Force);
            }
            else
            {
                velocity.x = 0;
                _rb.linearVelocity = velocity;
            }
        }
    }
}
