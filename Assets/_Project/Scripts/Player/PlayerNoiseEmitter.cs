using UnityEngine;

public class PlayerNoiseEmitter : MonoBehaviour
{
    [SerializeField] private PlayerStateMachine _PlayerStateMachine;
    [SerializeField] private PlayerRefSO _PlayerRef;
    public float NoiseRadius => _noiseRadius;

    private float _noiseRadius = 0f;

    private void OnEnable()
    {
        _PlayerRef.NoiseRadius = _noiseRadius;
    }

    private void OnDisable()
    {
        _PlayerRef.NoiseRadius = 0;
    }

    private void Start()
    {
        OnPlayerStateChanged();
    }

    //called by game event "PlayerStateChanged" response 
    public void OnPlayerStateChanged()
    {
        _noiseRadius = _PlayerStateMachine.CurrentState.GetNoiseMultiplier();
        _PlayerRef.NoiseRadius = _noiseRadius;
    }
}
