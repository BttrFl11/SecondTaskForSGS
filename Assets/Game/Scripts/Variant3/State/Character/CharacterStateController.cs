namespace Variant3
{
    public class CharacterStateController : StateController
    {
        public void Init(CState_Move move,
            CState_Jump jump,
            CState_Fall fall)
        {
            _states = new()
            {
                move, jump, fall
            };

            CurrentState = move;
        }
    }
}
