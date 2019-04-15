using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : Enemy, IDamageable {

    public GameObject acidEffectPrefab;
    public int Health { get; set; }

    public void Damage () {
        Health--;
        if (Health < 1) {
            base.isDead = true;
            anim.SetTrigger("Death");
        }
    }

    public override void Init () {
        base.Init ();
        Health = base.health;
    }

    public override void Moviment () {
        // do nothing for now.
    }

    public void Attack () {
        Instantiate (acidEffectPrefab, transform.position, Quaternion.identity);
    }

}