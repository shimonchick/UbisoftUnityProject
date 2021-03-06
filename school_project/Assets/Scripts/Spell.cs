﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Spell : MonoBehaviour {

    public abstract IEnumerator Cast();

    
    [SerializeField]
    protected float cooldown;

    [HideInInspector]
    public float currentCooldown = 0.0f;

    public float timeActive;

    public float Cooldown
    {
        get
        {
            return cooldown;
        }

        set
        {
            cooldown = value;
        }
    }

    public GameObject Caster
    {
        get
        {
            return caster;
        }

        set
        {
            caster = value;
        }
    }

    protected GameObject caster;
}
