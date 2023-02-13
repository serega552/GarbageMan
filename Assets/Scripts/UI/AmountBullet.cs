using TMPro;
using UnityEngine;

public class AmountBullet : MonoBehaviour
{
    [SerializeField] private TMP_Text _countBullet;
    [SerializeField] private AKM _akm;

    private void OnEnable()
    {
        _akm.BulletChanged += OnCountBulletChanged;
    }

    private void OnDisable()
    {
        _akm.BulletChanged -= OnCountBulletChanged;
    }

    private void OnCountBulletChanged(int countBullet)
    {
        _countBullet.text = countBullet.ToString();
    }
}
