using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Bin : MonoBehaviour
{
    [SerializeField] private ProgressBar _progressBar;
    
    private float _timer;
    private float _maxTime = 5f;

    public event UnityAction<float, float> ProgressChanged;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Player>(out Player player))  
        _progressBar.TurnOnSlider();
    }

    private void OnTriggerStay(Collider other)
    {
        _timer += Time.deltaTime;

        ProgressChanged?.Invoke(_timer, _maxTime);

        if (other.TryGetComponent<Player>(out Player player) && _timer > _maxTime)
        {
            player.AddBin();
            Destroy(gameObject);
            _progressBar.TurnOffSlider();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<Player>(out Player player))
        {
            _timer = 0;
            _progressBar.TurnOffSlider();
        }
    }
}
