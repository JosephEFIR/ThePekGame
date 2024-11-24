using UnityEngine;
using UnityEngine.UI;

namespace Project.Scripts.UI.Base
{
    public abstract class BaseUIButton : MonoBehaviour
    {
        protected Button Button;

        protected virtual void Awake()
        {
            Button = GetComponent<Button>();
        }

        protected virtual void Start()
        {
            Button.onClick.AddListener(OnClick);
        }

        protected virtual void OnDestroy()
        {
            Button.onClick.RemoveListener(OnClick);
        }

        protected abstract void OnClick();
    }
}