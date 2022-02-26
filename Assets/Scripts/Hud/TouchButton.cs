using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Hud
{
    public class TouchButton : MonoBehaviour, IPointerClickHandler, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler, IPointerUpHandler
    {
        [SerializeField] private Image imageBg;
        [SerializeField] private Color normalColor;
        [SerializeField] private Color hoverColor;
        [SerializeField] private Color clickedColor;
        
        public UnityEvent onButtonClicked = new UnityEvent();
        public UnityEvent onButtonDown = new UnityEvent();
        public UnityEvent onButtonReleased = new UnityEvent();
        public UnityEvent<bool> onButtonHover = new UnityEvent<bool>();

        private bool _isClicked;
        public bool TouchActivated { get; set; } = true;

        public void OnPointerClick(PointerEventData eventData)
        {
            onButtonClicked.Invoke();
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            if (!TouchActivated) return; 
            onButtonReleased.Invoke();
            _isClicked = false;
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            if (!TouchActivated) return;
            imageBg.color = clickedColor;
            onButtonClicked.Invoke();
            onButtonDown.Invoke();
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            if (!TouchActivated) return;
            if (!_isClicked) imageBg.color = hoverColor;
            onButtonHover.Invoke(true);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            if (!TouchActivated) return;
            if (!_isClicked) imageBg.color = normalColor;
            onButtonHover.Invoke(false);
        }
    }
}