using UnityEngine;
using Assets.Scripts;

namespace Controller
{
    public class WeaponsController: BaseController
    {
        private Weapons _weapons;
        private Ammunition _ammunition;
        public bool fireEnabled;
        private int _mouseButton;

        public void Awake()
        {
            fireEnabled = false;
        }

        public Weapons SelectedWeapons
        {
            get { return _weapons; }
        }

        public void Update()
        {
            if (Input.GetMouseButton(0))
            {
                SelectedWeapons.Fire(_ammunition);
            }
        }

        public void On(Weapons weapons, Ammunition ammunition)
        {
            //if (fireEnabled) return;
            //weapons.gameObject.SetActive(true);
            _weapons = weapons;
            _ammunition = ammunition;
            //_weapons.IsVisible = true;

        }
        public void Off(Weapons weapons, Ammunition ammunition)
        {
            //if (fireEnabled) return;
            weapons = null;
            ammunition = null;
            //weapons.gameObject.SetActive(false);
            //weapons.IsVisible = false;
        }

    }
}
