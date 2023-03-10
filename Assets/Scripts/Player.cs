using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(AudioSource))]
public class Player : MonoBehaviour
{
    [SerializeField] private AudioClip _TakeDamageSound;
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private Weapon _weapon;

    private AudioSource _audioSourse;
    private float _heath = 100f;
    private float _currentHealth;
    private int _bin;

    public event UnityAction<float, float> HealthChanged;
    public event UnityAction<int> ScoreChanged;
    public event UnityAction GameOver;
    public event UnityAction Win;

    private void Start()
    {
        _audioSourse = GetComponent<AudioSource>();
        _currentHealth = _heath;
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            _weapon.Shoot(_shootPoint);
        }
    }

    public void TakeDamage(float damage)
    {
        if (_currentHealth > 0)
        {
            _audioSourse.PlayOneShot(_TakeDamageSound);
            _currentHealth -= damage;
            HealthChanged?.Invoke(_currentHealth, _heath);
        }
        else
        {
            Die();
        }
    }

    public void AddBin()
    {
        _bin++;
        ScoreChanged?.Invoke(_bin);
        WinGame();
    }

    private void WinGame()
    {
        if (_bin == 4)
        {
            Win?.Invoke();
        }
    }

    private void Die()
    {
        GameOver?.Invoke();
    }
}
