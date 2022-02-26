using UnityEngine;
using UnityEngine.EventSystems;

namespace Hud
{
    public class TouchControl : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField] private RectTransform stickRectTransform;
        private RectTransform _touchpadRectTransform;
        private Vector2 _consoleTouchDirection;

        // public UnityEvent OnPointer;

        private void Awake()
        {
            _touchpadRectTransform = transform as RectTransform;
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            // InputManager.Instance.IsTouchDown = true;
        }

        public void OnDrag(PointerEventData eventData)
        {
            var setAnchoredPosition = stickRectTransform.anchoredPosition;
            setAnchoredPosition += eventData.delta;
            stickRectTransform.anchoredPosition = setAnchoredPosition;
            var direction = setAnchoredPosition;
            stickRectTransform.anchoredPosition = Vector2.ClampMagnitude(direction, _touchpadRectTransform.sizeDelta.y * 0.5f);
            _consoleTouchDirection = direction.normalized;
            // InputManager.Instance.TouchDirection = direction.normalized;
        }
        
        // When the player drag and release
        public void OnPointerUp(PointerEventData eventData)
        {
            stickRectTransform.anchoredPosition = Vector2.zero;
            Debug.LogFormat("D-pad normalized x: {0}, y: {1}", _consoleTouchDirection.x,  _consoleTouchDirection.y);
            // InputManager.Instance.IsTouchUp = true;
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            // TODO
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            // TODO
        }
    }
}
