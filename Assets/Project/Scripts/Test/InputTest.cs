using System;
using Project.Scripts.UI;
using UnityEngine;

namespace Project.Scripts
{
    public class InputTest : MonoBehaviour
    {
        [SerializeField] private UIManager uiManager;
        [SerializeField] private GameObject player;
        private Animator _animator;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                uiManager.SetScreen(EScreenType.Menu);
            }
        }
    }
}