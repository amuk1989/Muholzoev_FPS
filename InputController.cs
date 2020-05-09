using Assets.Scripts;
using UnityEngine;

namespace Controller
{
    public class InputController : BaseController
    {
        #region Serialize
        [SerializeField] private KeyCode _keyLight;
        #endregion

        private bool _flasLightActive = EnabledLight;

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
        }
    }
}
