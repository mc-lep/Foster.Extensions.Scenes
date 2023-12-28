namespace Foster.Framework.Extensions.Scenes.Transitions
{
    public abstract class Transition
    {
        private float _elapsedTime;
        private readonly float _halfDuration;
        private readonly float _halfDurationRatio;
        private readonly Ease.Easer _easer;

        public event Action? OnInState;
        public event Action? OnCompleted;

        public float DurationInSeconds { get; }
        public TransitionState State { get; private set; }
        public float Progress => _easer(_elapsedTime * _halfDurationRatio);

        public Transition(float durationInSeconds, Ease.Easer? easer = null)
        {
            _halfDuration = durationInSeconds * 0.5f;
            _halfDurationRatio = 1f / _halfDuration;
            _easer = easer ?? Ease.Linear;    

            DurationInSeconds = durationInSeconds;
            State = TransitionState.Out;
        }

        public void Update()
        {
            if (State == TransitionState.Out)
            {
                _elapsedTime += Time.Delta;

                if (_elapsedTime >= _halfDuration)
                {
                    State = TransitionState.In;
                    OnInState?.Invoke();
                }
            }
            else
            {
                _elapsedTime -= Time.Delta;

                if (_elapsedTime <= 0.0f)
                {
                    OnCompleted?.Invoke();
                }
            }
        }

        public abstract void Render(Batcher batch);
    }
}
