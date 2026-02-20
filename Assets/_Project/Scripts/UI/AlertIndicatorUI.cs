using UnityEngine;
using UnityEngine.UI;

public class AlertIndicatorUI : MonoBehaviour
{
    [SerializeField] private Image _PlayerStateIcon;

    private int _numberOfChasers = 0;
    private int _numberOfSearchers = 0;

    //listener inspector player found game event
    public void OnPlayerChasedEvent()
    {
        _numberOfChasers++;
        UpdateUI();
    }

    //listener inspector player lost game event 
    public void OnPlayerSearchEvent()
    {
        _numberOfChasers--;
        _numberOfSearchers++;
        UpdateUI();
    }

    //listener inspector player hidden game event
    public void OnPlayerHiddenEvent()
    {
        _numberOfSearchers--;
        UpdateUI();
    }

    //listener inspector player heard game event
    public void OnPlayerHeardEvent()
    {
        _numberOfSearchers++;
        UpdateUI();
    }

    private void UpdateUI()
    {
        if (_numberOfChasers != 0)
        {
            _PlayerStateIcon.color = Color.red;
        }

        if (_numberOfSearchers != 0 && _numberOfChasers == 0)
        {
            _PlayerStateIcon.color = Color.yellow;
        }

        if (_numberOfChasers == 0 && _numberOfSearchers == 0)
        {
            _PlayerStateIcon.color = Color.green;
        }
    }

}
