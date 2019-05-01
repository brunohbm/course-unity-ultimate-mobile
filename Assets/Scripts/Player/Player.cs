using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour, IDamageable
{
    public int diamonds;
    [SerializeField]
    private LayerMask _groundLayer;
    [SerializeField]
    private float _jumpForce = 5.0f;
    [SerializeField]
    private float _speed = 2.5f;
    private bool resetJumpNeeded = false;
    private Rigidbody2D _playerRigid;
    private PlayerAnimation _playerAnim;
    private SpriteRenderer _playerSprite;
    private SpriteRenderer _swordArcSprit;
 
    public int Health { get; set; }
    void Start()
    {
        _playerRigid = GetComponent<Rigidbody2D>();
        _playerAnim = GetComponent<PlayerAnimation>();
        _playerSprite = GetComponentInChildren<SpriteRenderer>();
        _swordArcSprit = transform.GetChild(1).GetComponent<SpriteRenderer>();
        Health = 4;
    }

    void Update()
    {
        Moviment();
        Attack();
    }

    void Moviment()
    {
        float move = CrossPlatformInputManager.GetAxis("Horizontal");

        if (move > 0)
        {
            Flip(true);
        }
        else if (move < 0)
        {
            Flip(false);
        }

        _playerAnim.Jump(!IsGrounded());

        if ((Input.GetKeyDown(KeyCode.Space) || CrossPlatformInputManager.GetButtonDown("Jump")) && IsGrounded())
        {
            _playerRigid.velocity = new Vector2(_playerRigid.velocity.x, _jumpForce);
            StartCoroutine(ResetJumpNeededRoutine());
        }
        _playerRigid.velocity = new Vector2(move * _speed, _playerRigid.velocity.y);
        _playerAnim.Move(move);
    }

    bool IsGrounded()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.down, 0.4f, _groundLayer);
        Debug.DrawRay(transform.position, Vector2.down * 0.4f, Color.green);
        if (hitInfo.collider)
        {
            if (!resetJumpNeeded)
                return true;
        }
        return false;

    }

    void Flip(bool faceRight)
    {
        Vector3 newPos = _swordArcSprit.transform.localPosition;

        if (faceRight == true)
        {
            _playerSprite.flipX = false;
            _swordArcSprit.flipX = false;
            _swordArcSprit.flipY = false;                
            newPos.x = 1.01f;
        }
        else if (faceRight == false)
        {
            _playerSprite.flipX = true;
            _swordArcSprit.flipX = true;
            _swordArcSprit.flipY = true;
            newPos.x = -1.01f;
        }

       _swordArcSprit.transform.localPosition = newPos; 
    }

    void Attack()
    {
        if ((Input.GetMouseButtonDown(0) || CrossPlatformInputManager.GetButtonDown("Attack")) && IsGrounded())
        {
            _playerAnim.Attack();
        }
    }

    IEnumerator ResetJumpNeededRoutine()
    {
        yield return new WaitForSeconds(0.1f);
        resetJumpNeeded = false;
    }

    public void Damage() {
        if(Health < 1) return;
        Health--;
        UIManager.Instance.UpdateLives(Health);
        if(Health < 1) {
            _playerAnim.Death();
        }
    }

    public void addDiamonds(int amount) {
        diamonds += amount;
        UIManager.Instance.setDiamondsText(diamonds);
    }

}
