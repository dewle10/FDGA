using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockback : MonoBehaviour
{
    public CharacterController2D CharacterController2D;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Tile") 
        {
            CharacterController2D.KBCounter = CharacterController2D.KBTotalTime;
            if (collision.transform.position.x <= transform.position.x)
            {
                CharacterController2D.m_FacingRight = true;
            }
            if
            (collision.transform.position.x <= transform.position.x)
            {
                CharacterController2D.m_FacingRight = true;
            }
        }
    }
}
