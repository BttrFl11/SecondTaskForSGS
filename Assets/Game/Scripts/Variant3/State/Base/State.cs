namespace Variant3
{
    public abstract class State
    {
        private readonly StateController _controller;
        public StateController Controller => _controller;

        public State(StateController controller)
        {
            _controller = controller;
        }

        public virtual void Enter() { }
        public virtual void Exit() { }
        public virtual void Update(float deltaTime) { }
    }
}
