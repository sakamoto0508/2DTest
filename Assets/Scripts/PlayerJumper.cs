using UnityEngine;

public class PlayerJumper
{
    public PlayerJumper(Rigidbody2D rb, PlayerConfig config)
    {
        _rb = rb;
        _config = config;
    }

    private Rigidbody2D _rb;
    private PlayerConfig _config;

    public void Jump()
    {
        _rb.linearVelocity = new Vector2(_rb.linearVelocity.x, _config.JumpSpeed);
    }
}
