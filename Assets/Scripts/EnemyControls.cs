using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyControls : MonoBehaviour
{
    [SerializeField] private NavMeshAgent _navMeshAgent;
    private GameObject _playerTemplate;
    private Player _player;
    private Enemy _enemy;
    private float _timer;
    private float _timerAudioClips;

    private void Start()
    {
        _playerTemplate = GameObject.Find("FPSController");
        _player = FindObjectOfType<Player>();
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _enemy = GetComponent<Enemy>();
    }

    private void Update()
    {
        FollowBihindPlayer();
    }

    private void FollowBihindPlayer()
    {
        _timer += Time.deltaTime;
        _timerAudioClips += Time.deltaTime;

        float distance = Vector3.Distance(_enemy.transform.position, _playerTemplate.transform.position);

        if (_playerTemplate != null && distance < _enemy.RangeFollow && distance > _navMeshAgent.stoppingDistance)
        {
            _navMeshAgent.destination = _playerTemplate.transform.position;
            
            if(_timerAudioClips > 10)
            {
                _enemy.AudioSourse.PlayOneShot(_enemy.FollowSound);
                _timerAudioClips = 0;
            }
        }
        if (distance <= 5f && _timer >= _enemy.TimeBetweenAtack)
        {
            _player.TakeDamage(_enemy.Damage);
            _timer = 0;
        }
    }
}

