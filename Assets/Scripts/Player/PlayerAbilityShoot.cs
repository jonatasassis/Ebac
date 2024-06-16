using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAbilityShoot : PlayerAbilityBase
{
    public List<UIFillUpdater> uiGunUpdateList;
    
    public GunBase arma1,arma2;
    private GunBase currentGun;
    public Transform gunPosition;
    public FlashColor[] flashColor;

    protected override void Init()
    {
        base.Init();
        CreateGun();
        inputs.Gameplay.Shoot.performed += cts => StartShoot();
        inputs.Gameplay.Shoot.canceled += cts => StopShoot();
    }

    private void CreateGun()
    {
        
        currentGun = Instantiate(arma1, gunPosition);
        currentGun.transform.localPosition = currentGun.transform.localEulerAngles = Vector3.zero;
       
    }

    private void Update()
    {
        SelectGun();
    }

    private void StartShoot()
    {

        currentGun.StartShoot();
        for(int x=0;x<3;x++)
        {
            flashColor[x]?.Flash();
        }
        
        Debug.Log("Atirar");
    }
    private void StopShoot()
    {
        currentGun.StopShoot();
        Debug.Log("Parar de Atirar");
    }

    private void SelectGun()
    {
        if (Input.GetKeyDown(KeyCode.Keypad1))
        {
             DestroyGun();
            currentGun = Instantiate(arma1, gunPosition);
            currentGun.transform.localPosition = currentGun.transform.localEulerAngles = Vector3.zero;


        }
        else if (Input.GetKeyDown(KeyCode.Keypad2))
        {


            DestroyGun();
            currentGun = Instantiate(arma2, gunPosition);
            currentGun.transform.localPosition = currentGun.transform.localEulerAngles = Vector3.zero;


        }
    }

    private void DestroyGun()
    {
        Destroy(currentGun.gameObject);
    }
}