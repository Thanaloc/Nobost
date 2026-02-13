using UnityEngine;

public class DebugEventRaiser : MonoBehaviour
{
    [SerializeField] private GameEvent _gE;

    private void Start()
    {

    }

    void Update()
    {
        if(Input.anyKeyDown)
            _gE.Raise();
    }

    public void DebugLog()
    {
        Debug.Log("received");
    }
}
