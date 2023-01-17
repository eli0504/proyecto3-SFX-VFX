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
    public float gravityMultiplier = 1.5f;
    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;


    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
        Physics.gravity *= gravityMultiplier;
    }

    private void Update()
    {
        Jump();
    }
 
    private void OnCollisionEnter(Collision otherCollider)
    {
        if (otherCollider.gameObject.CompareTag("Obstacle"))
        {
            GameOver();
        }else if (otherCollider.gameObject.CompareTag("Ground"))
        {
            isOnTheGround = true;
            dirtParticle.Play();
        }   
    }

    private void GameOver()
    {
        gameOver = true;
        _animator.SetBool("Death_b", true);
        _animator.SetInteger("DeathType_int", Random.Range(1, 3));
        explosionParticle.Play();
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnTheGround && !gameOver) //estar en el suelo y no estar muertoss
        {
            isOnTheGround = false;
            _rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            _animator.SetTrigger("Jump_trig");
            dirtParticle.Stop();
        }
    }
}
