using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody _rigidbody; //variable
    private Animator _animator;

    private bool isOnTheGround = true;
    public float jumpForce = 10;
    public bool gameOver;
    public float gravityMultiplier = 1.5f;

    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;

    public AudioClip[] jumpSounds;
    public AudioClip[] crashSounds;
    private AudioSource _audioSource;


    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
        Physics.gravity *= gravityMultiplier;
        _audioSource = GetComponent<AudioSource>();
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
        ChooseRandomSFX(crashSounds);
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnTheGround && !gameOver) //estar en el suelo y no estar muertoss
        {
            isOnTheGround = false; //DEJO DE TOCAR EL SUELO
            _rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse); //llamamos al trigger para que se dé la transición de correr a saltar
            _animator.SetTrigger("Jump_trig");
            dirtParticle.Stop();
            ChooseRandomSFX(jumpSounds);
        }
    }

    private void ChooseRandomSFX(AudioClip[] sounds)
    {
        int randomIdx = Random.Range(0, sounds.Length);  //sonido random
        _audioSource.PlayOneShot(sounds[randomIdx], 1);
    }
}
