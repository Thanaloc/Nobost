using UnityEngine;

public class AIHearing : MonoBehaviour
{
    [SerializeField] private PlayerRefSO _PlayerRef;
    [SerializeField] private AIPatrolStateMachine _AIStateMachine;

    private Vector3 _lastKnownPlayerSound = new();
    private bool _isPlayerHeard = false;

    public bool IsPlayerHeard => _isPlayerHeard;

    private void Update()
    {
        if (Vector3.Distance(transform.position, _PlayerRef.PlayerTransform.position) < _PlayerRef.NoiseRadius)
        {
            _lastKnownPlayerSound = _PlayerRef.PlayerTransform.position;
            _AIStateMachine.SetLastKnownPlayerPos(_lastKnownPlayerSound);
            _isPlayerHeard = true;
        }
        else
            _isPlayerHeard = false;
    }
}
