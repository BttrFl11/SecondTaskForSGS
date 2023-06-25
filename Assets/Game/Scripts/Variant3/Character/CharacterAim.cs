using UnityEngine;

namespace Variant3
{
    public class CharacterAim
    {
        private readonly Character _character;
        private CharacterAimSettings Data => _character.Settings.Aim;

        public CharacterAim(Character character)
        {
            _character = character;
        }

        public void Update()
        {
            Rotate();
        }

        private void Rotate()
        {
            float mouseX = InputProvider.Instance.GetMouseInputX();
            _character.transform.Rotate(Data.LookSensitivity * mouseX * Vector3.up, Space.Self);
        }
    }
}
