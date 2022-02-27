using System.Collections;
using UnityEngine;

namespace Managers
{
    public class MenuManager : MonoBehaviour
    {
        public static MenuManager Instance;

        [SerializeField] private RectTransform optionsMenu;
        private bool IsButtonToggle;
        private void Awake()
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Instance = this;
        }

        public IEnumerator MenuStartRoutine()
        {
            Debug.Log("Menu started");
            yield break;
        }

        public void GoToGameButton()
        {
            LoadManager.Instance.StartCoroutine(LoadManager.GoToGame());
        }

        public void EnableOptionsButton()
        {
            var parentAnchoredPosition = optionsMenu.parent.GetComponent<RectTransform>().anchoredPosition;
            optionsMenu.anchoredPosition = new Vector2(parentAnchoredPosition.x, parentAnchoredPosition.y);
        }

        public void DisableOptionsButton()
        {
            optionsMenu.anchoredPosition = new Vector2(5000, 0);
        }

        public void ToggleAudioButton()
        {
            GameManager.Instance.EnableAudio = !IsButtonToggle;
        }

        public void ExitButton()
        {
            GameManager.Instance.ExitGame();
        }
    }
}
