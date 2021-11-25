using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using View;

namespace Controller
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField]
        private GameObject _player;
        private PlayerView _playerView;
        [SerializeField]
        public GameObject Bullet;
        void Awake()
        {
            _playerView = FindObjectOfType<PlayerView>();
        }

        void Update()
        {
            _playerView.movement.x = Input.GetAxisRaw("Horizontal");
            _playerView.movement.y = Input.GetAxisRaw("Vertical");
            if (Input.GetMouseButtonDown(0))
            {
                var bullet = Instantiate(Bullet, _player.transform.position, Quaternion.identity);
            }
        }
    }
}
