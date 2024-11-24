using System;
using UnityEngine;

namespace Project.Scripts.UI
{
    public class GameScreen : Screen
    {
        [SerializeField] private GameObject[] objectsfasd;

        private void Start()
        {
            OnShowEvent += OnShow;
            OnHideEvent += OnHide;
        }

        private void OnDestroy()
        {
            OnShowEvent -= OnShow;
            OnHideEvent -= OnHide;
        }

        private void OnShow()
        {
            foreach (var VARIABLE in objectsfasd)
            {
                VARIABLE.SetActive(false);
            }
            Debug.Log("Show");
        }

        private void OnHide()
        {
            foreach (var VARIABLE in objectsfasd)
            {
                VARIABLE.SetActive(true);
            }
        }
    }
}