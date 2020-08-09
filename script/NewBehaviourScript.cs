using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    Rigidbody m_Rigidbody;
    public float m_Speed= 50;
    public float n_Speed= 50;
    public float H_balandlik = 2;
    public Transform m_Player ;
    public string jumpButton = "Jump";
    bool m_froze = true ;



    void Start()
    { 
         
        //Fetch the Rigidbody component you attach from your GameObject
        m_Rigidbody = GetComponent<Rigidbody>();
        //Set the speed of the GameObject
        //m_Speed = 50.0f;
        //n_Speed = 50.0f;
        
    }

    void Update()
    {
        RigidbodyConstraints previousConstraints = m_Rigidbody.constraints;

        m_Player.transform.rotation = Quaternion.Euler( 0 ,transform.rotation.eulerAngles.y ,0 );

        if ( m_Player.transform.position.y <  H_balandlik)
        {
            m_Rigidbody.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationX ;
            m_froze = true;
                }
        
        if (Input.GetKey(KeyCode.UpArrow) && m_froze )
        {
            //Move the Rigidbody forwards constantly at speed you define (the blue arrow axis in Scene view)
            m_Rigidbody.velocity = transform.forward * m_Speed;
           
        }
        if (SimpleInput.GetButtonDown(jumpButton) )
        {
            m_froze = false;
            m_Rigidbody.constraints = RigidbodyConstraints.None;

            m_Rigidbody.constraints = RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationX;

            m_Rigidbody.AddForce(0f, 10f, 0f, ForceMode.Impulse);
        }
        if (Input.GetKey(KeyCode.F))
        {
            m_Rigidbody.constraints = RigidbodyConstraints.FreezePositionY| RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationX;

        }

        if (Input.GetKey(KeyCode.G))
        {
            m_Rigidbody.constraints = RigidbodyConstraints.None;
            
            m_Rigidbody.constraints = RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationX;
            

        }
        if (Input.GetKey(KeyCode.DownArrow) && m_froze)
        {   
            //Move the Rigidbody backwards constantly at the speed you define (the blue arrow axis in Scene view)
            m_Rigidbody.velocity = -transform.forward * m_Speed;

            
        }

        if (Input.GetKey(KeyCode.RightArrow) && m_froze )
        {
            //Rotate the sprite about the Y axis in the positive direction
            transform.Rotate(new Vector3(0, 1, 0) * Time.deltaTime * n_Speed, Space.World);
        }

        if (Input.GetKey(KeyCode.LeftArrow) && m_froze )
        {
            //Rotate the sprite about the Y axis in the negative direction
            transform.Rotate(new Vector3(0, -1, 0) * Time.deltaTime * n_Speed, Space.World);
        }
    }
}