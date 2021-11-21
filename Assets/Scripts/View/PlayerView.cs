using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace View
{
    public class PlayerView : MonoBehaviour
    {
        public Rigidbody2D rb;
        public float movementSpeed = 4;
        public Vector2 movement;
        
        public void Move()
        {
            rb.MovePosition(rb.position + movement * movementSpeed * Time.fixedDeltaTime);
        }
    }

}
