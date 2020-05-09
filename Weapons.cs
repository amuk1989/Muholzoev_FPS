using UnityEngine;

namespace Assets.Scripts
{
    public abstract class Weapons: BaseObject
    {
        #region serialize
        [SerializeField] protected Transform _gunPosition;
        [SerializeField] protected float _delayBetweenShots;
        [SerializeField] protected float _shotPower;
        #endregion

        #region protected variable
        protected bool _shotAllowed = true;
        #endregion

        #region Abstract Function
        public abstract void Fire();
        #endregion
    }
}
