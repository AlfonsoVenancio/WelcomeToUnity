using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {
    public GameObject BulletPRefab;// the object bullet that will be spawned
    public Transform muzzle;// gun's muzzle
    float nextShotTime;// time passed since the last shoot
    public float sBetweenShots;// milliseconds between shoots


	
	
	// Update is called once per frame
	public void Shoot () {
        if (Time.time > nextShotTime )
        {
            nextShotTime = Time.time + sBetweenShots;
            GameObject newProjectile = Instantiate(BulletPRefab, muzzle.position, Quaternion.identity) ;
            newProjectile.SendMessage("SetDirection", new Vector3(Mathf.Sin(muzzle.rotation.eulerAngles.y * Mathf.Deg2Rad), 0f, Mathf.Cos(muzzle.rotation.eulerAngles.y * Mathf.Deg2Rad)));
        }
    }
}
