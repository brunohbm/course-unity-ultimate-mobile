using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : Enemy, IDamageable {

    public int Health { get; set; }

    public void Damage () {
        base.anim.SetTrigger ("Hit");
        Health--;
        base.isHit = true;
        base.anim.SetBool ("InCombat", true);
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
        base.Moviment ();
    }

}