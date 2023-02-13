using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class EnemyControler : MonoBehaviour
{
    [SerializeField] private GameObject _playerTemplate;
    [SerializeField] private Player _player;

    private NavMeshAgent _navMeshAgent;
    private Enemy _enemy;
    private bool _isAttackCoroutineRunning = false;
    private bool _isSoundCoroutineRunning = false;
    private Coroutine _soundCoroutine;
    private Coroutine _attackCoroutine;
        
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
                _soundCoroutine = StartCoroutine(Sound());
                _isSoundCoroutineRunning = true;
            }
        }
        else if(_isSoundCoroutineRunning)
        {
            StopCoroutine(_soundCoroutine);
            _isSoundCoroutineRunning = false;
        }

        if (distance <= 5f && _isAttackCoroutineRunning == false)
        {
            _attackCoroutine = StartCoroutine(Attack());
            _isAttackCoroutineRunning = true;
        }
        else if (distance > 5 && _isAttackCoroutineRunning)
        {
            StopCoroutine(_attackCoroutine);
            _isAttackCoroutineRunning = false;
        }
    }

    private IEnumerator Attack()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.2f);
            _player.TakeDamage(_enemy.Damage);
            yield return new WaitForSeconds(5f);
        }
    }

    private IEnumerator Sound()
    {
        while (true)
        {
            _enemy.AudioSourse.PlayOneShot(_enemy.FollowSound);
            yield return new WaitForSeconds(10f);
        }
    }
}

