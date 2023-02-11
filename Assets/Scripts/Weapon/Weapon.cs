using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] protected GameObject Bullet;
    [SerializeField] protected Camera Camera;
    [SerializeField] protected AudioClip ShotClip;
    [SerializeField] protected AudioSource AudioSourseWeapon;

    public int Force { get; protected set; }

    public abstract void Shoot(Transform shootPoint);
}
