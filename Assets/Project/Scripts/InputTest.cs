using System;
using UnityEngine;

namespace Project.Scripts
{
    public class InputTest : MonoBehaviour
    {
        private Animator _animator;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                _animator.SetTrigger("BreakDance01");
            }
            if (Input.GetKeyDown(KeyCode.F))
            {
                _animator.SetTrigger("BreakDance02");
            }
            if (Input.GetKeyDown(KeyCode.R))
            {
                _animator.SetTrigger("Dance01");
            }
        }
    }
}