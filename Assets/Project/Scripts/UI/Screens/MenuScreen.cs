using System;
using UnityEngine;

namespace Project.Scripts.UI
{
    public class MenuScreen : Screen
    {
        [SerializeField] private GameObject player;
        private void Start()
        {
            OnShowEvent += OnShow;
        }

        private void OnDestroy()
        {
            OnShowEvent -= OnShow;
        }

        private void OnShow()
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            player.SetActive(false);
        }
    }
}