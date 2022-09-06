using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckTargetOnTrigger : MonoBehaviour
{

    public bool onCollisionEnter2D;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
            onCollisionEnter2D = true;
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
            onCollisionEnter2D = true;
    }


    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
            onCollisionEnter2D = false;
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (transform.GetComponentInChildren<Collision2D>().collider.tag == "Player")
    //        onCollisionEnter2D = true;
    //}

    //private void OnTriggerStay2D(Collider2D collision)
    //{
    //    if (transform.GetComponentInChildren<Collision2D>().collider.tag == "Player")
    //        onCollisionEnter2D = true;
    //}

    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    if (transform.GetComponentInChildren<Collision2D>().collider.tag == "Player")
    //        onCollisionEnter2D = false;
    //}

}
