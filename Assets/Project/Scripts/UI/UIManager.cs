using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Project.Scripts.UI
{
    public class UIManager : SerializedMonoBehaviour
    {
       [SerializeField] private Dictionary<EScreenType, Screen> _screens = new ();
        private Screen _currentScreen;

        private void Start()
        {
            SetScreen(EScreenType.Menu);
        }

        public void SetScreen(EScreenType screenType, bool hideCurrentScreen = false)
        {
            if (hideCurrentScreen)
            {
                _currentScreen.gameObject.SetActive(false);
            }
            _currentScreen = _screens[screenType];
            _currentScreen.gameObject.SetActive(true);
        }
    }
}