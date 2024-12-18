using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    [SerializeField] List<BulletBase> bullets = new List<BulletBase>();
    [SerializeField] GunController gunController;  
    
    // Start is called before the first frame update
    void Start()
    {
        gunController.changeBullet(bullets[0]);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            gunController.changeBullet(bullets[0]); 
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            gunController.changeBullet(bullets[1]);
        }
    }
}
