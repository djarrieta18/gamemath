using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{

    // in this case I gointo to use the  on collision  con esto sabremos cuando el player ha chocado.

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "Enemy")
        {
             Debug.Log("Game over");
            PlayerManager.isGameOver = true;
            gameObject.SetActive(false);
        }
    }
}
