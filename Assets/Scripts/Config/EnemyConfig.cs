using UnityEngine;

[CreateAssetMenu(fileName = "EnemyConfig", menuName = "Configs/EnemyConfig")]
public class EnemyConfig : ScriptableObject
{
    public float MoveSpeed => _moveSpeed;
    public float AttackPower => _attackPower;
    public float MaxHealth => _maxHealth;


    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _attackPower;
    [SerializeField] private float _maxHealth;

}
