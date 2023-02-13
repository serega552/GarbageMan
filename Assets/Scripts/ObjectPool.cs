using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject _container;
    [SerializeField] private int _capacity;

    [SerializeField]  private Camera _camera;

    private List<GameObject> _pool = new List<GameObject>();

    public void Initialize(GameObject prefab)
    {
        _camera = Camera.main;

        for(int i = 0;i < _capacity;i++)
        {
            GameObject spawned = Instantiate(prefab,_container.transform.position,Quaternion.identity);   
            spawned.SetActive(false);

            _pool.Add(spawned);
        }
    }

    public bool TryGetObject(out GameObject result)
    {
        result = _pool.FirstOrDefault(p => p.activeSelf == false);

        return result != null;
    }

    public void ResetObjects()
    {
        foreach(var item in _pool)
        {
            item.SetActive(false);
            item.transform.position = _container.transform.position;
            item.GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
    }
}
