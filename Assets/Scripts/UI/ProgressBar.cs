using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : Bar
{
    [SerializeField] private Bin[] _bins;

    private void Start()
    {
        Slider.gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        foreach (Bin bin in _bins)
        {
            bin.ProgressChanged += OnValueChanged;
        }
        Slider.value = 1;
    }

    private void OnDisable()
    {
        foreach (Bin bin in _bins)
        {
            bin.ProgressChanged -= OnValueChanged;
        }
    }

    public void TurnOnSlider()
    {
        Slider.gameObject.SetActive(true);
    }

    public void TurnOffSlider()
    {
        Slider.gameObject.SetActive(false);
    }
}
