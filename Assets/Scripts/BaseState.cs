public abstract class BaseState : IState
    {
        protected PlayerCameraStateMachine _machine;
        public BaseState(PlayerCameraStateMachine machine)
        {
            _machine = machine;
        }
        public abstract void Enter();

        public virtual void Exit()
        {
            _machine.OnCompletedExitChangeValue();
        }
    }