using UnityEngine;
using UnityEngine.Events;

public class AKM : Weapon
{
    [SerializeField] private ObjectPool _objectPool;

    private int _currentCountBullet = 30;
    private int _maxCountBullet = 30;

    public event UnityAction<int> CountBullet;

    private void Start()
    {
        _objectPool.Initialize(Bullet);
    }

    public override void Shoot(Transform shootPoint)
    {
        Force = 500;

        if (_currentCountBullet > 0)
        {
            _currentCountBullet--;

            CountBullet?.Invoke(_currentCountBullet);

            Ray ray = Camera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));

            RaycastHit hit;
            Vector3 targetPoint;

            if (Physics.Raycast(ray, out hit))
                targetPoint = hit.point;
            else
                targetPoint = ray.GetPoint(0);

            SpawnBullet(shootPoint, targetPoint);
        }
        else
        {
            _objectPool.ResetPool();
            _currentCountBullet = _maxCountBullet;
            
        }
    }

    private void SpawnBullet(Transform shootPoint, Vector3 targetPoint)
    {
        Vector3 directionBullet = targetPoint - shootPoint.position;

        if (_objectPool.TryGetObject(out GameObject bullet))
        {
            bullet.transform.position = shootPoint.position;
            bullet.transform.forward = directionBullet.normalized;

            bullet.SetActive(true);
         
            bullet.GetComponent<Rigidbody>().AddForce(directionBullet.normalized * Force, ForceMode.Impulse);
            AudioSourseWeapon.PlayOneShot(ShotClip);
        }
    }
}
