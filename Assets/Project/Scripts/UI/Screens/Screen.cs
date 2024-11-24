using System;
using UnityEngine;

namespace Project.Scripts.UI
{
    public abstract class Screen : MonoBehaviour
    {
        [SerializeField] private EScreenType screenType;
        
        public EScreenType ScreenType => screenType;

        protected event Action OnShowEvent;
        protected event Action OnHideEvent;

        private void OnEnable()
        {
            OnShowEvent?.Invoke();
            Debug.Log("ON BASE ENABLE");
        }

        private void OnDisable()
        {
            OnHideEvent?.Invoke();
        }
    }
}