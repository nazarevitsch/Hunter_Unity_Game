using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using View;

namespace Controller
{
    public class PlayerController : MonoBehaviour
    {
        private PlayerView _playerView;
        void Awake()
        {
            _playerView = FindObjectOfType<PlayerView>();
        }

        void Update()
        {
            _playerView.movement.x = Input.GetAxisRaw("Horizontal");
            _playerView.movement.y = Input.GetAxisRaw("Vertical");
            _playerView.Move();
        }
    }
}
