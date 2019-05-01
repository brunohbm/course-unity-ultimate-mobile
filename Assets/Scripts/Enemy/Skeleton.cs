using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : Enemy, IDamageable {

    public GameObject diamond;

    public int Health { get; set; }

    public void Damage () {
        if(base.isDead) return;
        
        base.anim.SetTrigger ("Hit");
        Health--;
        base.isHit = true;
        base.anim.SetBool ("InCombat", true);
        if (Health < 1) {
            base.isDead = true;
            anim.SetTrigger ("Death");
            instantiateDiamond ();
        }
    }

    void instantiateDiamond () {
        GameObject newDiamond = Instantiate (diamond, transform.position, Quaternion.identity) as GameObject;
        newDiamond.GetComponent<Diamond> ().gems = base.gems;
    }

    public override void Init () {
        base.Init ();
        Health = base.health;
    }

    public override void Moviment () {
        base.Moviment ();
    }

}