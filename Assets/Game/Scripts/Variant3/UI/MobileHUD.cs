using UnityEngine;

namespace Variant3
{
    public class MobileHUD : MonoBehaviour
    {
        [SerializeField] private GameObject _panel;
        [SerializeField] private ButtonUI _fireButton;
        [SerializeField] private ButtonUI _jumpButton;
        [SerializeField] private Joystick _moveJoystick;
        [SerializeField] private LookCanvasUI _lookCanvas;

        public bool FirePressed => _fireButton.IsPressed;
        public bool JumpPressed => _jumpButton.IsPressed;
        public float JoystickInputX => _moveJoystick.Horizontal;
        public float JoystickInputY => _moveJoystick.Vertical;
        public LookCanvasUI LookCanvas => _lookCanvas;

        private bool _active;
        public bool Active
        {
            get => _active;
            set
            {
                _active = value;
                _panel.SetActive(value);
            }
        }
    }
}