using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class AIPatrol : MonoBehaviour
{
    [SerializeField] private Transform[] _Waypoints;

    [SerializeField] private AISettingsSO _AIConfig;

    [SerializeField] private NavMeshAgent _Agent;

    private IEnumerator _agentCoroutine;

    private void Start()
    {
        _Agent.speed = _AIConfig.PatrolSpeed;
        _agentCoroutine = AgentMoveRoutine();
        StartCoroutine(_agentCoroutine);
    }


    private IEnumerator AgentMoveRoutine()
    {
        int i = 0;
        while (true)
        {
            _Agent.SetDestination(_Waypoints[i].position);

            yield return null;

            while (_Agent.pathPending || _Agent.remainingDistance > 0.2f)
                yield return null;

            yield return new WaitForSeconds(_AIConfig.WaitTime);

            i = (i + 1) % _Waypoints.Length;
        }


    }
}
