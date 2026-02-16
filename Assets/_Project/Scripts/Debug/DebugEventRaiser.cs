using UnityEngine;

public class DebugEventRaiser : MonoBehaviour
{
    [SerializeField] private GameEvent _GameEvent;

    void Update()
    {
        if(Input.anyKeyDown)
            _GameEvent.Raise();
    }

    public void DebugLog()
    {
        Debug.Log("received");
    }
}
