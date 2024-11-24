using Project.Scripts.UI.Base;
using UnityEngine;

namespace Project.Scripts.UI.Menu
{
    public class ContinueButton : BaseUIButton
    {
        [SerializeField] private UIManager uiManager; // zenject не завезли
        [SerializeField] private GameObject player; // аче могу себе позволить, потом добавлю нормис
        protected override void OnClick()
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            
            player.gameObject.SetActive(true);
            uiManager.SetScreen(EScreenType.Game, true);
        }
    }
}