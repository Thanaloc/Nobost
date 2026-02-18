using UnityEngine;

public class ObjectiveTrigger : MonoBehaviour
{
    [SerializeField] private GameEvent _VictoryGameEvent;
    private LayerMask _playerLayer;

    private void OnEnable()
    {
        _playerLayer = LayerMask.GetMask("Player");
    }

    private void OnTriggerEnter(Collider p_other)
    {
        if (p_other.gameObject.layer == _playerLayer.value)
            _VictoryGameEvent.Raise();
    }
}
