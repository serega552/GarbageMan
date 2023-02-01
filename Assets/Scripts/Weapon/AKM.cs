using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AKM : Weapon
{
    public override void Shoot(Transform shootPoint)
    {
        Force = 500;

        Ray ray = Camera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        
        RaycastHit hit;
        Vector3 targetPoint;

        if (Physics.Raycast(ray, out hit))
            targetPoint = hit.point;
        else
            targetPoint = ray.GetPoint(0);

        Vector3 directionBullet = targetPoint - shootPoint.position;

        GameObject currectBullet = Instantiate(Bullet, shootPoint.position,Quaternion.identity);

        AudioSourseWeapon.PlayOneShot(ShotClip);

        currectBullet.transform.forward = directionBullet.normalized;

        currectBullet.GetComponent<Rigidbody>().AddForce(directionBullet.normalized * Force, ForceMode.Impulse);
    }
}
