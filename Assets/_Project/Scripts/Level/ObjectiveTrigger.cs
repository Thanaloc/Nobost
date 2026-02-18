using UnityEngine;

public class ObjectiveTrigger : MonoBehaviour
{
    [SerializeField] private GameEvent _VictoryGameEvent;

    private void OnTriggerEnter(Collider p_other)
    {
        if (p_other.gameObject.layer == LayerMask.NameToLayer("Player"))
            _VictoryGameEvent.Raise();
    }
}
