using UnityEngine;
using UnityEngine.EventSystems;

namespace Variant3
{
    public class LookCanvasUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        private PointerEventData _pointerEvent;

        private float _deltaX;
        public float DeltaX => _deltaX;

        public void OnPointerEnter(PointerEventData eventData)
        {
            _pointerEvent = eventData;
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            _pointerEvent = null;
            _deltaX = 0;
        }

        private void Update()
        {
            if (_pointerEvent == null) return;

            _deltaX = _pointerEvent.delta.x;
        }
    }
}
