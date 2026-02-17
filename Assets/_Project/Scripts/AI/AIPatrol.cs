using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class AIPatrol : MonoBehaviour
{
    [SerializeField] private Transform[] _Waypoints;

    [SerializeField] private AiSettingsSO _AIConfig;

    [SerializeField] private NavMeshAgent _Agent;

    private IEnumerator _agentCoroutine;
    private bool _restartCoroutine = false;

    private void Start()
    {
        _agentCoroutine = AgentMoveRoutine();
        StartCoroutine(_agentCoroutine);
    }

    private void Update()
    {
        if (_restartCoroutine)
        {
            StopCoroutine(_agentCoroutine);
            _agentCoroutine = null;
            _agentCoroutine = AgentMoveRoutine();
            StartCoroutine( _agentCoroutine);
            _restartCoroutine = false;
        }
    }

    private IEnumerator AgentMoveRoutine()
    {
        int i = 0;
        while (i < _Waypoints.Length)
        {
            _Agent.SetDestination(_Waypoints[i].position);

            if (_Agent.pathPending)
                yield return null;

            while (_Agent.remainingDistance > 0)
            {
                yield return new WaitForEndOfFrame();
            }

            if (_Agent.remainingDistance == 0)
            {
                yield return new WaitForSeconds(_AIConfig.WaitTime);
            }

            i++;
        }

        _restartCoroutine = true;

    }
}
