using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilitySwitcher : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private GameObject inkPrefab;

    Shooting shootingScript;

    private void Awake()
    {
        shootingScript = GetComponent<Shooting>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) 
        {
            SetAbility(1);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2)) 
        {
            SetAbility(2);
        }
    }

    public void SetAbility(int abilityID)
    {
        switch (abilityID)
        {
            case 1:
                shootingScript.SetBullet(bulletPrefab);
                break;
            case 2:
                shootingScript.SetBullet(inkPrefab);
                break;
            default:
                break;
        }
    }
}
