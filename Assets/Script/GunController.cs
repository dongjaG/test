using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{

    [SerializeField]
    private Gun currnetGun;

    private float currentFireRate;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GunFireRateCalc();
        TryFire();
    }

    private void GunFireRateCalc()
    {
        if (currentFireRate > 0)
            currentFireRate -= Time.deltaTime;
    }

    private void TryFire()
    {
        if (Input.GetButton("Fire1") && currentFireRate <= 0)
        {
            Fire();
        }
    }

    private void Fire()
    {
        if (currnetGun.currentBulletCount > 0)
            Shoot();
        else
            Reload();
    }

    private void Shoot()
    {
        currnetGun.currentBulletCount--;
        currentFireRate = currnetGun.fireRate;
        Debug.Log("ÃÑ¾Ë ¹ß»ç");

    }

    private void Reload()
    {
        if (currnetGun.currentBulletCount > 0)
        {
            if (currnetGun.currentBulletCount >= currnetGun.reloadBulletCount)
            {
                currnetGun.currentBulletCount = currnetGun.reloadBulletCount;
                currnetGun.carryBulletCount -= currnetGun.reloadBulletCount;
            }
            else
            {
                currnetGun.currentBulletCount = currnetGun.carryBulletCount;
                currnetGun.carryBulletCount = 0;
            }
        }
    }
}
