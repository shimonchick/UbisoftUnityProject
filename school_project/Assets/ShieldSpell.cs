﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ShieldSpell : Spell {

    
    private GameObject shield;
    private GameObject ship;

    [SerializeField]
    private Material shieldedShipMaterial;

    public float shieldTime = 2.0f;

    private void Start()
    {
        ship = GameObject.FindGameObjectWithTag("Player");
        shield = GameObject.FindGameObjectWithTag("Shield");
        shield.SetActive(false);
        
    }
    public override void Cast()
    {
        Material startMaterial = ship.GetComponent<MeshRenderer>().material;
        ship.GetComponent<MeshRenderer>().material = shieldedShipMaterial;
        StartCoroutine(ShowShield());
        ship.GetComponent<MeshRenderer>().material = startMaterial;

    }

    private IEnumerator ShowShield()
    {
        shield.SetActive(true);
        yield return new WaitForSeconds(shieldTime);
        shield.SetActive(false);

    }
}