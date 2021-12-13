using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdController : MonoBehaviour
{
    public bool isStart;
    private int _countJumps;
    private bool _faceRight = true;
    [SerializeField] private Animator _anim;
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private BoxCollider2D _bx;
    [SerializeField] private ScoreManager _scoreManager;
    [SerializeField] private MenuManager _menuManager;
    [SerializeField] private float _speed;
    [SerializeField] private float _forceJump;
    [SerializeField] private float _secondForceJump;
    
    private void Update()
    {
        if(isStart)
        {
            TapToJump();
            if(_faceRight)
            {
                transform.position += Vector3.right * _speed * Time.deltaTime;
            }
            else
            {
                transform.position += Vector3.left * _speed * Time.deltaTime;
            }
        }

    }


    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("Enemy"))
        {
            _anim.SetBool("isDead", true);
            isStart = false;
            _menuManager.DieBird();
        }

        if(other.gameObject.CompareTag("WallRight"))
        {
            _faceRight = false;
            RotateFace();
        }
        if(other.gameObject.CompareTag("WallLeft"))
        {
            _faceRight = true;
            RotateFace();
        }

        if(other.gameObject.CompareTag("Ground"))
        {
            StartCoroutine(waitToJump(0.1f));
        }

    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("PlusPoint"))
        {
            _scoreManager.AddPoint();
        }
    }
    private void RotateFace()
    {
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
    }
    private void TapToJump()
    {
        if(Input.GetMouseButtonDown(0) && _countJumps < 2)
        {

            if(_countJumps == 0)
            {
                _rb.AddForce(Vector3.up * _forceJump , ForceMode2D.Impulse);
            }
            if(_countJumps == 1)
            {
                _rb.AddForce(Vector3.up * _secondForceJump , ForceMode2D.Impulse);
            }
            _countJumps++;
        }
    }

    IEnumerator waitToJump(float time)
    {
        yield return new WaitForSeconds(time);
        _countJumps = 0;
    }

}
