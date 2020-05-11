using UnityEngine;
using Controller;

namespace Assets.Scripts
{
    public sealed class Main: MonoBehaviour
    {
        private GameObject _controllersGameObject;
        private InputController _inputController;
        private FlashlightController _flashlightController;
        private WeaponsController _weaponsController;
        private static Main _instance;
        private ObjectManager _objectManager;

        private void Start()
        {
            Instance = this;
            _controllersGameObject = new GameObject { name = "Controllers" };
            _inputController = _controllersGameObject.AddComponent<InputController>();
            _flashlightController = _controllersGameObject.AddComponent<FlashlightController>();
            _weaponsController = _controllersGameObject.AddComponent<WeaponsController>();
            _objectManager = GetComponent<ObjectManager>();
        }

        #region Property
        public FlashlightController GetFlashlightController
        {
            get { return _flashlightController; }
        }
        public WeaponsController GetWeaponsController
        {
            get { return _weaponsController; }
        }
        public ObjectManager GetObjectManager
        {
            get { return _objectManager; }
        }
        public static Main Instance { get => _instance; private set => _instance = value; }

        public InputController GetInputController()
        {
            return _inputController;
        }

        #endregion
    }
}
