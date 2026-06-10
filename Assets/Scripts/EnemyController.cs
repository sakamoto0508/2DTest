using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyController : CharacterBase
{
    [SerializeField] private EnemyConfig _config;
    public EnemyConfig Config => _config;
    private Transform _player;
    private Rigidbody2D _rb;
    public void Init()
    {
        _currentHealth = _config.MaxHealth;
        _maxHealth = _config.MaxHealth;
        _rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Vector2 direction = ((Vector2)_player.position - _rb.position).normalized;
        _rb.linearVelocity = direction * _config.MoveSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //後で弾に当たったらダメージを受けるようにする
    }
}
