using UnityEngine;

namespace Assets.Scripts
{
    public class Gun : Weapons
    {
        public override void Fire(Ammunition ammunition)
        {
            if (_countOfBullets > 0)
            {
                if (_shotAllowed)
                {
                    if (ammunition)
                    {

                        Bullet tempbulet = Instantiate(ammunition, _gunPosition.position, _gunPosition.rotation) as Bullet;
                        if (tempbulet)
                        {
                            print("Fire");
                            _countOfBullets--;
                            tempbulet.GetComponent<Rigidbody>().AddForce(_gunPosition.forward * _shotPower);
                            tempbulet.name = "Bullet";
                            _shotAllowed = false;
                            _delay.Start(_delayBetweenShots);
                        }
                    }
                }
            }
            

        }

    }
}

