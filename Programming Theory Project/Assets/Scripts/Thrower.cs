using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// INHERITANCE
public class Thrower : Bounded
{

    private void Awake()
    {
        // INHERITANCE
        zRange = zRange - 2;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // POLYMORPHISM, INHERITANCE
    protected virtual Vector3 GetTarget()
    {
        float x = 0, y = 0, z = 0;
        x = Random.Range(-m_xRange, m_xRange);

        return new Vector3(x, y, z);
    }

    protected virtual Vector3 GetVectorInRange()
    {
        float x = 0, y = 0, z = 0;
        x = Random.Range(-m_xRange, m_xRange);
        z = Random.Range(-m_zRange, m_zRange);
        return new Vector3(x, y, z);
    }

    protected override void CheckBounds()
    {
        throw new System.NotImplementedException();
    }

    public virtual void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Throwable"))
        {
            Destroy(collision.gameObject);
        }
    }

}
