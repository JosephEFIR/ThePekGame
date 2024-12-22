using System;
using Project.Scripts.UI;
using UnityEngine;

namespace Project.Scripts
{
    public class InputTest : MonoBehaviour
    {
        [SerializeField] private UIManager uiManager;
        [SerializeField] private GameObject player;
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                uiManager.SetScreen(EScreenType.Menu);
            }
        }
    }
}