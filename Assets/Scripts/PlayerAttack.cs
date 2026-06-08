using UnityEngine;

public class PlayerAttack
{
    public PlayerAttack(PlayerConfig config, GameObject bullet)
    {
        _config = config;
        _bullet = bullet;
    }

    private PlayerConfig _config;
    private GameObject _bullet;

    public void Tick()
    {

    }
}
