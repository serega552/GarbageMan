using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private AudioClip _followSound;
    [SerializeField] private AudioClip _takeDamageSound;
    [SerializeField] private AudioClip _DieSound;
    
    private float _health = 100f;
    private float _damage = 10f;
    private float _rangeFollow = 50;
    private float _timeBetweenAtack = 3;
    private float _timeDestroingObject;

    public AudioSource AudioSourse { get; private set; }

    public AudioClip FollowSound => _followSound;
    public AudioClip TakeDamageSound => _takeDamageSound;
    public float RangeFollow => _rangeFollow;
    public float Damage => _damage;
    public float TimeBetweenAtack => _timeBetweenAtack;

    private void Start()
    {
        AudioSourse = GetComponent<AudioSource>();
    }

    public void TakeDamage(float damage)
    {
        if (_health > 0)
        {
            AudioSourse.PlayOneShot(_takeDamageSound);
            _health -= damage;
        }
        if (_health <= 0)  
        {
            Die();
        }
    }

    private void Die()
    {
        AudioSourse.PlayOneShot(_DieSound);
        Destroy(gameObject, _timeDestroingObject);
    }
}
