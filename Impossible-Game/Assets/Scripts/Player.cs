using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float _speed = 2.5f;
    private bool dirRight = true;
    public Animator animator;
    private bool isWinnig;
    private bool isDead;
    [SerializeField]
    private bool isGrounded = true;
    public CapsuleCollider2D collider;
    public GameObject groundCheck;
    public float groundDistnace = 0.5f;
    public LayerMask groundMask;



    // Start is called before the first frame update
    void Start()
    {
        isWinnig = false;
        isDead = false;
    }

    // Update is called once per frame
    void Update()
    {


        if (isDead)
        {
            Dead();
        }
        else
        {
            Movement();
            Fall();

        }
        
    }

    void Movement()
    {
        
        /* move constantly between two points
        if (dirRight)
        {
            transform.Translate(Vector2.right * _speed * Time.deltaTime);
            animator.SetFloat("Horizontal", 1f);
        }
        else
        {
            transform.Translate(-Vector2.right * _speed * Time.deltaTime);
            animator.SetFloat("Horizontal", -1f);
        }


        if (transform.position.x >= 8.0f)
        {
            dirRight = false;
        }

        if (transform.position.x <= -7.5)
        {
            dirRight = true;
        }*/
        if (isWinnig)
        {
            animator.SetFloat("Speed", 0f);
            animator.SetFloat("Horizontal", 0f);
            _speed = 0;
        } else
        {
            animator.SetFloat("Speed", 1f);
            animator.SetFloat("Horizontal", 1f);
        }
        transform.Translate(Vector2.right * _speed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space) )
        {
            
            Jump();
           
        }
        
        

       
    }


    void Jump()
    {
        
        if (isGrounded)
        {
            animator.SetBool("Jump", true);
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 5), ForceMode2D.Impulse);
            isGrounded = false;

            StartCoroutine(OnLanding());
        }
       
       
       
    }

    IEnumerator OnLanding()
    {
        
        yield return new WaitForSeconds(1);
        animator.SetBool("Jump", false);
        isGrounded = true;
    }
    
    void Fall()
    {
        if(transform.position.y < -4)
        {
            isDead = true;
            
        }
    }
    void Dead()
    {
        
        animator.SetFloat("Speed", 0f);
        animator.SetFloat("Horizontal", 0f);
        _speed = 0;
        animator.SetBool("Dead", true);
        FindObjectOfType<GameManager>().EndGame();
        FindObjectOfType<CameraMovement>().isDead = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Collectables"))
        {
            Destroy(GameObject.FindWithTag("Collectables"));
            Debug.Log("You Win!");
            isWinnig = true;
        } else if (collision.CompareTag("Traps"))
        {
            
            isDead = true;
        }
        
    }

   
  
}
