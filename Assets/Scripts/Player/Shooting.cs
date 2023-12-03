using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    private Camera mainCam;
    private Vector3 mousePos;
    
    public GameObject bullet;
    public Transform bulletTransform;
    public bool canShoot;
    private float shootTimer;
    public float cooldown;

    private CamouflageScript camouflageScript;

    // Start is called before the first frame update
    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        camouflageScript = GameObject.FindGameObjectWithTag("Player").GetComponent<CamouflageScript>();
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        
        Vector3 rotation = mousePos - transform.position;
        
        float angle = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
       
        transform.rotation = Quaternion.Euler(0, 0, angle);
       
       if (!canShoot)
       {
           shootTimer += Time.deltaTime;

           if (shootTimer > cooldown)
           {
               canShoot = true;
               shootTimer = 0;
           }
       }

       if (Input.GetMouseButtonDown(0) && canShoot && !camouflageScript.CamouflagedState())
       {
           canShoot = false;
           Shoot();
       }
           }

    void Shoot()
    {
        Instantiate(bullet, bulletTransform.position, transform.rotation);
    }

    public void SetBullet(GameObject bulletPrefab)
    {
        bullet = bulletPrefab;
    }
}
