using System.Collections;
using System.Globalization;
using Gustaf.Scripts.Managers;
using Hud;
using TMPro;
using UnityEngine;

namespace Managers
{
    public class HudManager : MonoBehaviour
    {
        public static HudManager Instance;

        [SerializeField] private TextMeshProUGUI scoreTextMeshPro;
        [SerializeField] private RectTransform optionsInGameMenu;

        public TouchButton abilityButton;

        private bool _isButtonToggle;
        private void Awake()
        {
            Instance = this;
            InputManager.ButtonListeners();
        }

        private void Update()
        {
            HudScoreCounter();
        }

        private void HudScoreCounter()
        {
            if (scoreTextMeshPro == null) return;
            var score = GameManager.Score;
            scoreTextMeshPro.text = score.ToString(CultureInfo.InvariantCulture);
        }

        public static IEnumerator HudStartRoutine()
        {
            InputManager.ButtonListeners();
            Debug.Log("Hud started");
            yield break;
        }

        public void GoToStartMenuButton()
        {
            LoadManager.Instance.StartCoroutine(LoadManager.GoToMenu());
        }

        public void EnableOptionsInGameButton()
        {
            Time.timeScale = 0f;
            var parentAnchoredPosition = optionsInGameMenu.parent.GetComponent<RectTransform>().anchoredPosition;
            optionsInGameMenu.anchoredPosition = new Vector2(parentAnchoredPosition.x, parentAnchoredPosition.y);
        }

        public void DisableOptionsInGameButton()
        {
            Time.timeScale = 1f;
            optionsInGameMenu.anchoredPosition = new Vector2(5000, 0);
        }

        public void ToggleAudioButton()
        {
            GameManager.Instance.EnableAudio = !_isButtonToggle;
        }
    }
}
