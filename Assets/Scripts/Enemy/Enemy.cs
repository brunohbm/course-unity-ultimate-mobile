using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour {
    [SerializeField]
    protected int health;
    [SerializeField]
    protected int speed;
    [SerializeField]
    protected int gems;
    [SerializeField]
    protected Transform pointA;
    [SerializeField]
    protected Transform pointB;
    protected Vector3 currentTarget;
    protected Animator anim;
    protected SpriteRenderer sprite;

    protected bool isHit = false;

    protected bool isDead = false;

    protected Player player;

    public virtual void Init () {
        anim = GetComponentInChildren<Animator> ();
        sprite = GetComponentInChildren<SpriteRenderer> ();
        player = GameObject.FindGameObjectWithTag ("Player").GetComponent<Player> ();
    }

    public void Start () {
        Init ();
    }

    public virtual void Update () {
        if (IdleAnimatio ()) return;

        if (!isDead) Moviment ();
    }

    public virtual void Moviment () {
        Flip ();
        if (transform.position == pointA.position) {
            SetTarget (pointB.position);
        } else if (transform.position == pointB.position) {
            SetTarget (pointA.position);
        }

        if (!isHit) {
            transform.position = Vector3.MoveTowards (transform.position, currentTarget, speed * Time.deltaTime);
        } else {
            float distance = Vector3.Distance (transform.localPosition, player.transform.localPosition);
            if (distance > 2.0f) {
                anim.SetBool ("InCombat", false);
                isHit = false;
            }
        }

        Vector3 direction = player.transform.localPosition - transform.localPosition;

        if (direction.x > 0 && anim.GetBool ("InCombat")) {
            sprite.flipX = false;
        } else if (direction.x < 0 && anim.GetBool ("InCombat")) {
            sprite.flipX = true;
        }
    }

    public virtual void SetTarget (Vector3 newPosition) {
        currentTarget = newPosition;
        anim.SetTrigger ("Idle");
    }

    public virtual void Flip () {
        if (currentTarget == pointA.position) {
            sprite.flipX = true;
            return;
        }
        sprite.flipX = false;
    }

    public virtual bool IdleAnimatio () {
        return (anim.GetCurrentAnimatorStateInfo (0).IsName ("Idle") && !anim.GetBool ("InCombat"));
    }
}