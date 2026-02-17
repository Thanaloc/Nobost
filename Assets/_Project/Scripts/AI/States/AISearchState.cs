using System.Collections;
using UnityEngine;

public class AISearchState : IAIState
{
    private AISettingsSO _data;
    private IEnumerator _searchCoroutine;

    private bool _isSearching = false;

    public AISearchState(AISettingsSO p_data)
    {
        _data = p_data;
    }

    public void Enter(AIPatrolStateMachine p_stateMachine)
    {
        p_stateMachine.Agent.SetDestination(p_stateMachine.LastKnowPlayerPosition);
        _searchCoroutine = SearchForPlayerCoroutine(p_stateMachine);
    }

    public void Execute(AIPatrolStateMachine p_stateMachine)
    {
        if (p_stateMachine.AIDetector.IsPlayerDetected)
        {
            p_stateMachine.TransitionTo(p_stateMachine.ChaseState);
            return;
        }

        if(!_isSearching)
            p_stateMachine.StartCoroutine(_searchCoroutine);
    }

    private IEnumerator SearchForPlayerCoroutine(AIPatrolStateMachine p_stateMachine)
    {
        _isSearching = true;

        while (p_stateMachine.Agent.remainingDistance < .2f)
            yield return new WaitForEndOfFrame();

        yield return new WaitForSeconds(_data.SearchTime);

        _isSearching = false;
        p_stateMachine.TransitionTo(p_stateMachine.PatrolState);
    }

    public void Exit(AIPatrolStateMachine p_stateMachine)
    {
        if (_searchCoroutine != null)
        {
            p_stateMachine.StopCoroutine(_searchCoroutine);
            _searchCoroutine = null;
            _isSearching = false;
        }
    }
}
