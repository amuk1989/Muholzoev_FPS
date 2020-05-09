using UnityEngine;

namespace Assets.Scripts
{
    public abstract class Weapons: BaseObject
    {
        #region serialize
        [SerializeField] protected Transform _gunPosition;
        [SerializeField] protected float _delayBetweenShots;
        [SerializeField] protected float _shotPower;
        [SerializeField] protected float _bulletsInHolder;
        #endregion

        #region protected variable
        protected bool _shotAllowed = true;
        protected Timer _delay = new Timer();
        #endregion

        #region Abstract Function
        public abstract void Fire(Ammunition ammunition);
        #endregion

        protected virtual void Update()
        {
            _delay.Update();
            if (_delay.IsEvent())
            {
                _shotAllowed = true;
            }
        }

    }
}
