using Unity.Mathematics;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    public float jumpForce= 10;
    public float gravityModifier;
    public bool isOnGround = true;
    public bool gameOver =false;
    private Animator playerAnim;
    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;
    public AudioClip jumpSound;
    public AudioClip crashSound;
    private AudioSource playerAudio;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerRb = GetComponent < Rigidbody>();
       playerAnim = GetComponent<Animator>();
       Physics.gravity *= gravityModifier;
       playerAudio = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver){
        {
             dirtParticle.Stop();
             playerRb.AddForce(Vector3.up* jumpForce, ForceMode.Impulse);
             isOnGround = false;
             playerAnim.SetTrigger("Jump_trig");
             playerAudio.PlayOneShot(jumpSound, 1.0f);

        }

        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        //isGround = true;

        if (collision.gameObject.CompareTag("Ground"))
        {
           dirtParticle.Play();
           isOnGround = true; 
           
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        { 
            dirtParticle.Stop();
            Debug.Log("GAME OVER!!");
            gameOver = true;
            playerAnim.SetBool("Death_b",true);
            playerAnim.SetInteger("DeathType_int", 1);
            explosionParticle.Play();
            playerAudio.PlayOneShot(crashSound, 1.0f); 
          
        }
    }
}
