using UnityEngine;

namespace Variant3
{
    public class InputProvider : Singleton<InputProvider>
    {
        [SerializeField] private MobileHUD _mobileHUD;

        public bool IsFiring => GetFireInput();
        public bool IsJumping => GetJumpInput();

        protected override void Awake()
        {
            base.Awake();

            if (DeviceInfo.IsMobile)
                _mobileHUD.Active = true;
        }

        public float GetMoveInputX()
        {
            if (DeviceInfo.IsMobile)
                return _mobileHUD.JoystickInputX;
            else
                return Input.GetAxis("Horizontal");
        }

        public float GetMoveInputY()
        {
            if (DeviceInfo.IsMobile)
                return _mobileHUD.JoystickInputY;
            else
                return Input.GetAxis("Vertical");
        }

        public float GetMouseInputX()
        {
           // if (DeviceInfo.IsMobile)
                return _mobileHUD.LookCanvas.DeltaX;
           // else
                //return Input.GetAxisRaw("Mouse X");
        }

        private bool GetJumpInput()
        {
            if (DeviceInfo.IsMobile)
                return _mobileHUD.JumpPressed;
            else
                return Input.GetKeyDown(KeyCode.Space);
        }

        private bool GetFireInput()
        {
            if (DeviceInfo.IsMobile)
                return _mobileHUD.FirePressed;
            else
                return Input.GetMouseButton(0);
        }
    }
}
