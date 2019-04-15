using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour {

    bool _canDamage = true;
  
    void OnTriggerEnter2D(Collider2D other) {        
        IDamageable damageableOther = other.GetComponent<IDamageable>();
        
        if(damageableOther != null && _canDamage) {            
            damageableOther.Damage();
            _canDamage = false;
            StartCoroutine(ResetDamage());
        }
    }

    IEnumerator ResetDamage() {
        yield return new WaitForSeconds(0.5f);
        _canDamage = true;
    }

}
