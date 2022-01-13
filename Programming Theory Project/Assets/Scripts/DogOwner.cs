using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogOwner : Thrower
{
    [SerializeField] private GameObject[] throwable;
    private GameObject thrown;
    // Start is called before the first frame update
    void Start()
    {
        thrown = Instantiate(throwable[0], GetVectorInRange(), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindWithTag("Throwable") == null)
        {
            Instantiate(throwable[0], GetVectorInRange(), Quaternion.identity);
        }

    }

    // POLYMORPHISM
    public override void OnCollisionEnter(Collision collision)
    {
        base.OnCollisionEnter(collision);
        if (collision.gameObject.CompareTag("Throwable"))
        { Instantiate(throwable[0], GetVectorInRange(), Quaternion.identity); }
    }
}
