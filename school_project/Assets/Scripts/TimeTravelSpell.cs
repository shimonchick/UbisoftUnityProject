﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeTravelSpell : Spell {


    [SerializeField]
    private float timeBack = 2.0f;
    [SerializeField]
    private GameObject TravelFx;
    [SerializeField]
    private float effectDuration = 1.0f;

    [SerializeField]
    private float effectScale = 5.0f;

    private void Awake()
    {
        timeActive = timeBack + 0.5f;
    }
    public override IEnumerator Cast()
    {
        Vector3? newPosition = Caster.GetComponent<Ship>().GetPositionAtTime(Time.time - timeBack);
        
        if (newPosition != null) {
            Caster.transform.position = (Vector3)newPosition;
            GameObject effect = Instantiate(TravelFx, Caster.transform);
            effect.transform.localScale *= effectScale;
            //Debug.Log("effect created");
            Destroy(effect, effectDuration);
        }
        return null;


    }
}
