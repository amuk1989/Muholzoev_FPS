using UnityEngine;
using Controller;
using Assets.Scripts;
using UnityEngine.UI;
using System.Collections;

public class BatteryIndicator : MonoBehaviour
{
    #region Serialeze
    [SerializeField] private Color _highColor = Color.green;
    [SerializeField] private Color _middleColor = Color.yellow;
    [SerializeField] private Color _lowColor = Color.red;
    [SerializeField] private float _highEnergy = 85;
    [SerializeField] private float _middleEnergy = 55;
    [SerializeField] private float _lowEnergy = 30;
    [SerializeField] private float _reloadTime = 2.5f;
    [SerializeField] private float _timeOfWork = 10;
    #endregion

    private float _curTime;
    private float _pauseTime;
    private Light _light;
    private Slider _slider;
    private Image _sliderColor;

    private void Awake()
    {
        _light = GameObject.Find("Flashlight").GetComponent<Light>();
        _slider = GameObject.Find("Slider").GetComponent<Slider>();
        _sliderColor = _slider.fillRect.GetComponentInChildren<Image>();
        _curTime = 0;
        _pauseTime = 0;
    }

    private void Start()
    {
        _slider.minValue = 0;
        _slider.maxValue = 100;
        _slider.value = 100;
    }

    private void FixedUpdate()
    {
        if (_light.enabled)
        {
            //if (_pauseTime > 0) _pauseTime -= Time.deltaTime;
            _pauseTime = 0;
            _curTime += Time.deltaTime;
            if (_curTime > _timeOfWork)
            {
                Main.Instance.GetFlashlightController.Off();
                //StartCoroutine(DischargeOfBattery());
            }
        }
        else
        {
            if (_curTime > 0) _pauseTime += Time.deltaTime;
            if (_curTime > 0 && _pauseTime > 1) _curTime -= Time.deltaTime;
        }

        _slider.value = 100 - (_curTime / _timeOfWork) * 100;

        if (_slider.value >= _highEnergy) _sliderColor.color = _highColor;
        if (_slider.value < _middleEnergy) _sliderColor.color = _middleColor;
        if (_slider.value < _lowEnergy) _sliderColor.color = _lowColor;
    }

    private IEnumerator DischargeOfBattery()
    {
        float _countTime = 3f;
        while (_countTime > 0)
        {
            Main.Instance.GetFlashlightController.On();
            yield return new WaitForSeconds(_countTime);
            Main.Instance.GetFlashlightController.Off();
            _countTime = _countTime - 0.5f;
            yield return new WaitForSeconds(_countTime);
            _countTime = _countTime - 0.5f;
        }
    }
}
