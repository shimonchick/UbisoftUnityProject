﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShip : Ship {


    private void Start()
    {
        base.Start();
        GameStateController.Instance.RegisterPlayer(gameObject);
        if (AsteroidSpawner.Instance)
        {
            AsteroidSpawner.Instance.RegisterPlayer(gameObject);
        }
        if (EnemySpawner.Instance)
        {
           EnemySpawner.Instance.RegisterPlayer(gameObject);
        }
        //DontDestroyOnLoad(gameObject);
    }
    // Update is called once per frame
    private void Update () {
        base.Update();
        UpdateShootInputs();
        UpdateSpellInputs();
    }

    private void FixedUpdate()
    {
        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");

        float playerCameraOffset = Camera.main.transform.position.y - transform.position.y;
        Vector3 mousePositionScreenSpace = new Vector3(Input.mousePosition.x, Input.mousePosition.y, playerCameraOffset);
        Vector3 mousePositionWorldSpace = Camera.main.ScreenToWorldPoint(mousePositionScreenSpace);

        Move(horizontalInput, verticalInput);
        LookTarget(mousePositionWorldSpace);


    }
    private void UpdateShootInputs()
    {
        if (Input.GetButton("Fire1"))
        {
            Shoot();
        }
    }
    //legacy dota spell buttons FTW
    private void UpdateSpellInputs()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            CastSpell(0);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            CastSpell(1);
        }
        //if (Input.GetKeyDown(KeyCode.Alpha3))
        //{
        //    CastSpell(2);
        //}
        //if (Input.GetKeyDown(KeyCode.Alpha3))
        //{
        //    CastSpell(3);
        //}
    }

}
