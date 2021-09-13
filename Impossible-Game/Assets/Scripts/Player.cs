using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float _speed = 2.5f;
    private bool dirRight = true;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    void Movement()
    {
        animator.SetFloat("Speed", 1f);

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
        }



    }
}
