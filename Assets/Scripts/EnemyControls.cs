using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyControls : MonoBehaviour
{
    [SerializeField] private GameObject _playerTemplate;
    [SerializeField] private Player _player;

    private NavMeshAgent _navMeshAgent;
    private Enemy _enemy;
    private bool _isAtackCoroutineRunning = false;
    private bool _isSoundCoroutineRunning = false;

    private void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _enemy = GetComponent<Enemy>();
    }

    private void Update()
    {
        FollowBihindPlayer();
    }

    private void FollowBihindPlayer()
    {
        float distance = Vector3.Distance(_enemy.transform.position, _playerTemplate.transform.position);

        if (_playerTemplate != null && distance < _enemy.RangeFollow && distance > _navMeshAgent.stoppingDistance)
        {
            _navMeshAgent.destination = _playerTemplate.transform.position;

            if (_isSoundCoroutineRunning == false)
            {
                StartCoroutine(Sound());
                _isSoundCoroutineRunning = true;
            }
        }
        else
        {
            StopCoroutine(Sound());
            _isSoundCoroutineRunning = false;
        }

        if (distance <= 5f && _isAtackCoroutineRunning == false)
        {
            StartCoroutine(Attack());
            _isAtackCoroutineRunning = true;
        }
        else if (distance > 5)
        {
            StopCoroutine(Attack());
            _isAtackCoroutineRunning = false;
        }
    }

    private IEnumerator Attack()
    {
        _player.TakeDamage(_enemy.Damage);
        yield return new WaitForSeconds(5f);

    }

    private IEnumerator Sound()
    {
        _enemy.AudioSourse.PlayOneShot(_enemy.FollowSound);
        yield return new WaitForSeconds(10f);
    }
}

