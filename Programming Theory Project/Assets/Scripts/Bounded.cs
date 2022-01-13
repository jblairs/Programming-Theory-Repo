using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Bounded : MonoBehaviour
{
    // ENCAPSULATION
    protected float m_xRange = 10.0f;
    protected float m_zRange = 5.0f;

    public virtual float xRange { get { return m_xRange; } protected set { m_xRange = value; } }
    public virtual float zRange { get { return m_zRange; } protected set { m_zRange = value; } }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // POLYMORPHISM
    protected abstract void CheckBounds();

}
