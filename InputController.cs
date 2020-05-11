using Assets.Scripts;
using UnityEngine;
using System;

namespace Controller
{
    public class InputController : BaseController
    {
        #region Serialize
        [SerializeField] private KeyCode _keyLight;
        [SerializeField] private KeyCode _nextWeapon;
        [SerializeField] private KeyCode _prevWeapon;
        [SerializeField] private KeyCode _keyShot;
        #endregion

        private bool _flasLightActive = EnabledLight;
        private int _indexWeapon = 0;
        private int _weaponsCount;// = //2;//Main.Instance.GetObjectManager.GetWeaponsCount;
        private ObjectManager _objectManager;

        private void Start()
        {
            _objectManager = Main.Instance.GetObjectManager;
            _weaponsCount = _objectManager.GetAmmunitionList.Length;
            SelectWeapon();
            for (int i = 0; i < _weaponsCount; i++)
            {
                if (i != _indexWeapon)
                {
                    EnabledWeapon(i);
                }
            }
        }
        public void Update()
        {
            if (Input.GetKeyDown(_keyLight))
            {
                _flasLightActive = !_flasLightActive;
                if (_flasLightActive)
                {
                    Main.Instance.GetFlashlightController.On();
                }
                else
                {
                    Main.Instance.GetFlashlightController.Off();
                }
            }

            if (Input.GetKey(_nextWeapon) || Input.GetAxis("Mouse ScrollWheel") > 0)
            {
                EnabledWeapon(_indexWeapon);
                if (_indexWeapon < _weaponsCount-1)
                {
                    _indexWeapon++;
                }
                else
                {
                    _indexWeapon = 0;
                }
                SelectWeapon();
            }
            if (Input.GetKey(_prevWeapon) || Input.GetAxis("Mouse ScrollWheel") < 0)
            {
                EnabledWeapon(_indexWeapon);
                if (_indexWeapon > 0)
                {
                    _indexWeapon--;
                }
                else
                {
                    _indexWeapon = _weaponsCount-1;
                }
                SelectWeapon();
            }
            
        }

        private void SelectWeapon()
        {
            Main.Instance.GetWeaponsController.On(
                _objectManager.GetWeaponsList[_indexWeapon],
                _objectManager.GetAmmunitionList[_indexWeapon]
                );
            _objectManager.GetWeaponsList[_indexWeapon].gameObject.SetActive(true);
            //print("select " + _indexWeapon);
        }

        private void EnabledWeapon(int _i)
        {
            Main.Instance.GetWeaponsController.Off(
                _objectManager.GetWeaponsList[_i],
                _objectManager.GetAmmunitionList[_i]
                );
            _objectManager.GetWeaponsList[_i].gameObject.SetActive(false);
         }
    }
}
