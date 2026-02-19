using UnityEngine;

public class AIHearing : MonoBehaviour
{
    [SerializeField] private PlayerRefSO _PlayerRef;
    [SerializeField] private AIPatrolStateMachine _AIStateMachine;

    private Vector3 _lastKnownPlayerSound = new();

    private void Update()
    {
        _lastKnownPlayerSound = _AIStateMachine.AIDetector.PlayerTransform.position;

        if (Vector3.Distance(transform.position, _PlayerRef.PlayerTransform.position) < _PlayerRef.NoiseRadius && _AIStateMachine.CurrentState == _AIStateMachine.PatrolState)
        {
            _AIStateMachine.SetLastKnownPlayerPos(_lastKnownPlayerSound);
            _AIStateMachine.TransitionTo(_AIStateMachine.SearchState);
        }
    }
}
