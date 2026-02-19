using UnityEngine;

public class AIHearing : MonoBehaviour
{
    [SerializeField] private PlayerRefSO _PlayerRef;
    [SerializeField] private AIPatrolStateMachine _AIStateMachine;

    private void Update()
    {
        if (Vector3.Distance(transform.position, _PlayerRef.PlayerTransform.position) < _PlayerRef.NoiseRadius && _AIStateMachine.CurrentState == _AIStateMachine.PatrolState)
        {
            _AIStateMachine.TransitionTo(_AIStateMachine.SearchState);
        }
    }
}
