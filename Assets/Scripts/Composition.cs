using UnityEngine;

public class Composition : MonoBehaviour
{
    [SerializeField] private PlayerController _playerController;

    void Start()
    {
        _playerController?.Init();
    }
}
