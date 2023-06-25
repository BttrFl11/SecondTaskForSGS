using UnityEngine;

namespace Variant2
{
    public class InputProvider : MonoBehaviour
    {
        [SerializeField] private ArrowButton _upArrow;
        [SerializeField] private ArrowButton _downArrow;
        [SerializeField] private ArrowButton _leftArrow;
        [SerializeField] private ArrowButton _rightArrow;

        private int _horizontalInput;
        private int _verticalInput;

        public int HorizontalInput => _horizontalInput;
        public int VerticalInput => _verticalInput;

        private void Update()
        {
            if (_upArrow.IsPressed)
                _verticalInput = 1;
            else if (_downArrow.IsPressed)
                _verticalInput = -1;
            else
                _verticalInput = 0;

            if (_rightArrow.IsPressed)
                _horizontalInput = 1;
            else if (_leftArrow.IsPressed)
                _horizontalInput = -1;
            else
                _horizontalInput = 0;
        }
    }
}