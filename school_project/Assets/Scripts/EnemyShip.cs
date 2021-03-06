﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShip : Ship {

    public float rotationSpeed = 1.0f;
    public float castSpellTime = 2.0f; // cast spell every 2 seconds
    public float shootingDelay = 1.0f;
    private GameObject target;

    public void SetTarget(GameObject targetToSet)
    {
        target = targetToSet;
    }

    private float startShootingAfter;
    private bool isMovingRight;
    private void Start()
    {
        base.Start();
        startShootingAfter = Time.time + shootingDelay;
        isMovingRight = (Random.Range(0, 100) > 49) ? true : false;

    }
    private void Update()
    {
        base.Update();
    }
    //TODO use FixedUpdate
    private void FixedUpdate () {
        
        
        if (target != null)
        {
           
            MoveTowards(target.transform.position);

            RotateAround(target.transform.position);
            LookTarget(target.transform.position);
            if (Time.time % castSpellTime == 0)
            {
                CastSpell(Random.Range(0, 2)); // TODO make it get the number of spells from the spell component
            }
            if (Time.time > startShootingAfter)
            {
                Shoot();
                //Debug.Log("enemy shooting target");
            }
        }
        else
        {
            Debug.Log("target not set");
        }
        
	}



}
