using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Bounded
{
    private Animator playerAnim;
    private GameObject throwable = null;
    // may not be needed
    public bool hasFetched = false;

    private float verticalInput;
    private float horizontalInput;
    private float offset = 0.5f;

    // ENCAPSULATION
    private float m_speed = 5;
    public float speed 
    { 
        get { return m_speed; } 
        set
        {
            if (value < 0.0f)
            {
                Debug.LogError("You can't set a negative player speed!");
            }
            else
            {
                m_speed = value;
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        playerAnim = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        // ABSTRACTION
        CheckBounds();
        MovePlayer();
        MoveThrowable();
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("Collision");
        if (collision.gameObject.CompareTag("Throwable"))
        {
            throwable = collision.gameObject;
        }
        else if (collision.gameObject.CompareTag("Eatable"))
        {
            Destroy(collision.gameObject);
        }
    }

    // ABSTRACTION
    void MovePlayer()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        if (horizontalInput == 0 && verticalInput == 0)
        { Sit(); }
        else
        {
            Stand();
            transform.rotation = Quaternion.LookRotation(new Vector3(horizontalInput, 0, verticalInput));
            transform.Translate(Vector3.right * m_speed * Time.deltaTime * horizontalInput, Space.World);
            transform.Translate(Vector3.forward * m_speed * Time.deltaTime * verticalInput, Space.World);
        }

    }

    void MoveThrowable()
    {
        if (throwable != null)
        {
            throwable.transform.position = new Vector3(transform.position.x, 0, transform.position.z + offset);
        }
    }

    // ABSTRACTION
    void Sit()
    {
        playerAnim.SetBool("Sit_b", true);
    }

    // ABSTRACTION
    void Stand()
    {
        playerAnim.SetBool("Sit_b", false);
    }

    // POLYMORHPISM and ABSTRACTION
    protected override void CheckBounds()
    {
        if (transform.position.x < -m_xRange)
        {
            transform.position = new Vector3(-m_xRange, 0, transform.position.z);
        }
        else if (transform.position.x > m_xRange)
        {
            transform.position = new Vector3(m_xRange, 0, transform.position.z);
        }
        if (transform.position.z < -m_zRange)
        {
            transform.position = new Vector3(transform.position.x, 0, -m_zRange);
        }
        else if (transform.position.z > m_zRange)
        {
            transform.position = new Vector3(transform.position.x, 0, m_zRange);
        }
    }
    }
