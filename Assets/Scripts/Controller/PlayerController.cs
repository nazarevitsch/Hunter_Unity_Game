using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using View;

namespace Controller
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] 
        private Rigidbody2D rb;
        [SerializeField] 
        private new Camera camera;
        
        
        private PlayerView _playerView;
        
        void Awake()
        {
            _playerView = FindObjectOfType<PlayerView>();
        }

        void Update()
        {
            if (_playerView is null) return;
            _playerView.movement.x = Input.GetAxisRaw("Horizontal");
            _playerView.movement.y = Input.GetAxisRaw("Vertical");

            Vector2 mousePosition = camera.ScreenToWorldPoint(Input.mousePosition);
            Vector2 look = mousePosition - rb.position;
            float angel = Mathf.Atan2(look.y, look.x) * Mathf.Rad2Deg - 90f;
            rb.rotation = angel;
            
        }
    }
}
