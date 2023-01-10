using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody _rigidbody; //variable
    private bool isOnTheGround = true;

    public float jumpForce = 10;

    public bool gameOver;

    private Animator _animator;
    
    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnTheGround && !gameOver)
        {
            isOnTheGround = false;
            _rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            _animator.SetTrigger("Jump_trig");
        }


    }
 
    private void OnCollisionEnter(Collision otherCollider)
    {
        if (otherCollider.gameObject.CompareTag("Obstacle"))
        {
            gameOver = true;
        }else if (otherCollider.gameObject.CompareTag("Ground"))
        {
            isOnTheGround = true;
        }   
    }
}
