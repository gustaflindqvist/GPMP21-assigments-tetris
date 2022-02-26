using Hud;
using UnityEngine;

namespace Managers
{
    public class InputManager : MonoBehaviour
    {
        public static InputManager Instance;

        // TouchControl
        public bool IsTouchUp { get; set; }
        public bool IsTouchDown { get; set; }
        public Vector2 TouchDirection { get; set; }
        public static bool TouchOnPress { get; set; }
        public static bool TouchOnHold { get; set; }

        private void Awake()
        {
            Instance = this;
        }

        public static void ActivateButtons()
        {
            var buttons = FindObjectsOfType<TouchButton>();
            foreach (var button in buttons)
                button.TouchActivated = true;
        }

        public static void DeactivateButtons()
        {
            var buttons = FindObjectsOfType<TouchButton>();
            foreach (var button in buttons)
                button.TouchActivated = false;
        }

        public static void ButtonListeners()
        {
            HudManager.Instance.abilityButton.onButtonClicked.AddListener(StartAbility);
            HudManager.Instance.abilityButton.onButtonDown.AddListener(TouchAbility);
            HudManager.Instance.abilityButton.onButtonReleased.AddListener(TouchAbilityOnReleased);
        }

        private static void StartAbility()
        {
            TouchOnPress = true;
            Debug.Log("Ability button pressed");
        }

        private static void TouchAbility()
        {
            TouchOnHold = true;
            Debug.Log("Touch on hold");
        }

        private static void TouchAbilityOnReleased()
        {
            TouchOnPress = false;
            TouchOnHold = false;
            Debug.Log("Touch ability button on released");
        }
    }
}
