using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{

    private bool _faceRight;

    [SerializeField] private float _speed;

    private void Update()
    {
        if(_faceRight)
        {
            transform.position += Vector3.right * _speed * Time.deltaTime;
        }
        else
        {
            transform.position += Vector3.left * _speed * Time.deltaTime;
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {

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

    }

    private void RotateFace()
    {
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
    }
}
