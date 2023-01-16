using UnityEngine;
using Microsoft.MixedReality.Toolkit.UI;

public class Moving : MonoBehaviour
{
    private Rigidbody _conveyer;
    [SerializeField] private Rigidbody _botPartOfConv;
    [SerializeField] private Material _botMaterial;
    public float _speed = 0;
    private float _matirealSpeed = 0;
    private Material _material;
    private bool _moveStatus = false;
    [SerializeField] private GameObject _speedBar;
    [SerializeField] private GameObject _leftBaraban;
    [SerializeField] private GameObject _rightBaraban;
    private float _startSpeedBarStatus = 0.5f;
    private void Start()
    {
        _conveyer = GetComponent<Rigidbody>();
        _material = GetComponent<MeshRenderer>().material;
    }
    void FixedUpdate()
    {
        if (_moveStatus)
        {
            _material.mainTextureOffset = new Vector2(0f, Time.time * _matirealSpeed * Time.deltaTime);
            Vector3 pos = _conveyer.position;
            _conveyer.position += Vector3.left * _speed * Time.fixedDeltaTime;
            _conveyer.MovePosition(pos);
            _botMaterial.mainTextureOffset = new Vector2(0, Time.time * _matirealSpeed * -1 * Time.deltaTime);
            Vector3 pos1 = _botPartOfConv.position;
            _botPartOfConv.position += Vector3.right * _speed * Time.fixedDeltaTime;
            _botPartOfConv.MovePosition(pos1); 
        }

    }
    public void Pusk() {
        _moveStatus = true;
        _speed = 0.1f;
        _matirealSpeed = 1;
        _speedBar.GetComponent<PinchSlider>().SliderValue = _speed / 2 + 0.5f;
        _speedBar.GetComponent<SliderSounds>().playTickSounds = true;
        SetSpeedBaraban();
    }
    public void Stop() {
        _moveStatus = false;
        _speed = 0;
        _matirealSpeed = 0;
        _speedBar.GetComponent<PinchSlider>().SliderValue = 0.5f;
        _speedBar.GetComponent<SliderSounds>().playTickSounds = false;
        SetSpeedBaraban();
    }

    public void SpeedBar()
    {
        //max = 1;
        //min = -1;

        float currentSpeedOfBar = _speedBar.GetComponent<PinchSlider>().SliderValue;
        if (currentSpeedOfBar != _startSpeedBarStatus)
        {
            if (_moveStatus)
            {
                float deltaSpeed = currentSpeedOfBar - _startSpeedBarStatus;
                _speed = deltaSpeed * 2;

                _matirealSpeed = deltaSpeed * 20;
                SetSpeedBaraban();
            }
            else
            {
                _speedBar.GetComponent<PinchSlider>().SliderValue = 0.5f;
            }
        }

    }
    private void SetSpeedBaraban()
    {
        _leftBaraban.GetComponent<Baraban>().SetSpeed(_speed * 480);
        _rightBaraban.GetComponent<Baraban>().SetSpeed(_speed * 480);
    }
}
