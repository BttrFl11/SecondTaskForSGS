using System;
using System.Collections.Generic;

namespace Variant3
{
    public abstract class StateController : IDisposable
    {
        protected List<State> _states = new();

        private State _currentState;
        protected State CurrentState
        {
            get => _currentState;
            set
            {
                if (_currentState == value)
                    return;

                if (_currentState != null)
                    _currentState.Exit();

                _currentState = value;
                _currentState.Enter();
            }
        }

        public void Dispose()
        {
            if (_currentState == null) return;

            _currentState.Exit();
        }

        public void Update(float deltaTime)
        {
            if(_currentState == null) return;

            _currentState.Update(deltaTime);
        }

        public void Change<T>() where T : State
        {
            CurrentState = Find<T>();
        }

        public T Find<T>() where T : State
        {
            foreach (var state in _states)
            {
                if(typeof(T) == state.GetType())
                    return (T)state;
            }

            throw new Exception($"Could not found state of type {typeof(T)}");
        }
    }
}
