using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D), typeof(SpringJoint2D))]
public class PlayerController : CharacterBase
{
    [SerializeField] private PlayerConfig _config;
    private LineRenderer _lineRenderer;
    private Rigidbody2D _rb;
    private SpringJoint2D _joint;
    private PlayerMover _mover;
    private PlayerJumper _jumper;
    private PlayerGraper _graper;

    public void Init()
    {
        _rb = GetComponent<Rigidbody2D>();
        _joint = GetComponent<SpringJoint2D>();
        _lineRenderer = GetComponent<LineRenderer>();
        _mover = new PlayerMover(_rb, _config);
        _jumper = new PlayerJumper(_rb, _config);
        _graper = new PlayerGraper(_joint, _config, transform, _lineRenderer);
        _currentHealth = _config.MaxHealth;
        _maxHealth = _config.MaxHealth;

        _joint.enabled = false;
    }

    private void Update()
    {
        _mover.Tick();
        _graper.Tick();
    }

    private void OnMove(InputValue value)
    {
        _mover?.Input(value.Get<Vector2>());
    }

    private void OnJump(InputValue value)
    {
        if (value.isPressed)
        {
            _jumper?.Jump();
        }
    }

    private void OnGrap(InputValue value)
    {
        if (value.isPressed)
        {
            Debug.Log("Grap");
            _graper?.Grap();
        }
        else
        {
            Debug.Log("Release");
            _graper?.Release();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<EnemyController>(out var enemy))
        {
            TakeDamage(enemy.Config.AttackPower);
        }
    }
}
