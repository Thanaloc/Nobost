using System.Collections;
using UnityEngine;

public class AISearchSoundState : IAIState
{
    private AISettingsSO _data;
    private IEnumerator _searchCoroutine;

    private bool _isSearching = false;

    public AISearchSoundState(AISettingsSO p_data)
    {
        _data = p_data;
    }

    public void Enter(AIPatrolStateMachine p_stateMachine)
    {
        p_stateMachine.Agent.SetDestination(p_stateMachine.LastKnownSoundPosition);
        _searchCoroutine = SearchForSoundCoroutine(p_stateMachine);
    }

    public void Execute(AIPatrolStateMachine p_stateMachine)
    {
        if (!p_stateMachine.AIDetector.IsPlayerHeard)
        {
            p_stateMachine.TransitionTo(p_stateMachine.PatrolState);
            return;
        }

        if(!_isSearching)
            p_stateMachine.StartCoroutine(_searchCoroutine);
    }

    private IEnumerator SearchForSoundCoroutine(AIPatrolStateMachine p_stateMachine)
    {
        //TODO
        yield return null;
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
