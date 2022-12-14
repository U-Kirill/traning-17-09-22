using System;
using Services;
using UnityEngine;
using Zenject;

namespace Logic
{
    public class PlayerMove : MonoBehaviour
    {
        [SerializeField] private CharacterController _controller;
        [SerializeField] private float _speed = 5;

        private IInputService _input;
        private PlayerHolder _playerHolder;

        [Inject]
        public void Constructor(IInputService input, PlayerHolder playerHolder)
        {
            _playerHolder = playerHolder;
            _input = input;
        }

        private void Start()
        {
            _playerHolder.Player = transform;
        }

        private void Update()
        {
            Vector3 movement = new Vector3(_input.Value.x, 0, _input.Value.y);
            _controller.Move(movement * _speed * Time.deltaTime);
        }
    }
}