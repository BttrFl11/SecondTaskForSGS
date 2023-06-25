using UnityEngine;
using UnityEngine.EventSystems;

namespace Variant3
{
    public class ButtonUI : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        private bool _pressed;
        public bool IsPressed => _pressed;

        public void OnPointerDown(PointerEventData eventData)
        {
            _pressed = true;
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            _pressed = false;
        }
    }
}
