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

    // Start is called before the first frame update
    void Start()
    {
        isWinnig = false;
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
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
        

       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Collectables"))
        {
            Destroy(GameObject.FindWithTag("Collectables"));
        }

        isWinnig = true;
        Debug.Log("You Win!");
    }
  
}
