using Assets.Scripts;
using UnityEngine;
using Controller;

namespace Controller
{
    public class FlashlightController : BaseController
    {
        private Light _light;

        private void Awake()
        {
            _light = GameObject.Find("Flashlight").GetComponent<Light>();
            EnabledLight = _light.enabled;
        }

        public void Start()
        {
            _light.enabled = false;
            EnabledLight = false;
        }

        public void Update()
        {
            if (!EnabledLight) return;
        }

        public void On()
        {
            if (EnabledLight) return;
            _light.enabled = true;
            EnabledLight = true;
        }
        public void Off()
        {
            if (!EnabledLight) return;
            _light.enabled = false;
            EnabledLight = false;
        }

    }
}
