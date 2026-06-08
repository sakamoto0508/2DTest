using UnityEngine;

[CreateAssetMenu(fileName = "PlayerConfig", menuName = "Configs/PlayerConfig")]
public class PlayerConfig : ScriptableObject
{
    public float MoveSpeed => _moveSpeed;
    public float Acceleration => _acceleration;
    public float Deceleration => _deceleration;
    public float JumpSpeed => _jumpSpeed;
    public LayerMask GrappleLayer => _grappleLayer;
    public float MaxGrappleDistance => _maxGrappleDistance;
    public float GrappleFrequency => _grappleFrequency;
    public float DampingRatio => _dampingRatio;
    public float WindingSpeed => _windingSpeed;
    public float MaxHealth => _maxHealth;
    public float AttackPower => _attackPower;

    [Header("Movement Settings")]
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _acceleration;
    [SerializeField] private float _deceleration;
    [SerializeField] private float _jumpSpeed;
    [Header("Grapple Settings")]
    [SerializeField] private LayerMask _grappleLayer;
    [SerializeField] private float _maxGrappleDistance;
    [SerializeField] private float _grappleFrequency;
    [SerializeField] private float _dampingRatio;
    [SerializeField] private float _windingSpeed;
    [Header("Stats")]
    [SerializeField] private float _maxHealth;
    [SerializeField] private float _attackPower;
}
