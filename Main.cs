using UnityEngine;
using Controller;

namespace Assets.Scripts
{
    public sealed class Main: MonoBehaviour
    {
        private GameObject _controllersGameObject;
        private InputController _inputController;
        private FlashlightController _flashlightController;
        private static Main _instance;

        private void Start()
        {
            Instance = this;
            _controllersGameObject = new GameObject { name = "Controllers" };
            _inputController = _controllersGameObject.AddComponent<InputController>();
            _flashlightController = _controllersGameObject.AddComponent<FlashlightController>();
        }

        #region Property
        public FlashlightController GetFlashlightController
        {
            get { return _flashlightController; }
        }

        public static Main Instance { get => _instance; private set => _instance = value; }

        public InputController GetInputController()
        {
            return _inputController;
        }

        #endregion
    }
}
