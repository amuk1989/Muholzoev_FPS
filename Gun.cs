using Assets.Scripts;
using UnityEngine;

public class Gun : Weapons
{
    public override void Fire(Ammunition ammunition)
    {
        if (_shotAllowed)
        {
            if (ammunition)
            {
                Bullet tempbulet = Instantiate(ammunition, gameObject.transform.position, gameObject.transform.rotation) as Bullet;
            }
        }
            
    }
}
