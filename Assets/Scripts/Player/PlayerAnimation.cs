using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator _playerAnim;
    private Animator _swordAnim;
    void Start()
    {
        _playerAnim = transform.GetChild(0).GetComponent<Animator>();
        _swordAnim = transform.GetChild(1).GetComponent<Animator>();
    }

    public void Move(float move)
    {
        _playerAnim.SetFloat("Move", Mathf.Abs(move));
    }

    public void Jump(bool jumping)
    {
        _playerAnim.SetBool("Jumping", jumping);
    }

    public void Attack() {
        _playerAnim.SetTrigger("Attack");
        _swordAnim.SetTrigger("SwordAnimation");
    }
}
