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
        UpgradeUI();
    }

    //listener inspector player lost game event 
    public void OnPlayerSearchEvent()
    {
        _numberOfChasers--;
        _numberOfSearchers++;
        UpgradeUI();
    }

    //listener inspector player hidden game event
    public void OnPlayerHiddenEvent()
    {
        _numberOfSearchers--;
        UpgradeUI();
    }

    //listener inspector player heard game event
    public void OnPlayerHeardEvent()
    {
        _numberOfSearchers++;
        UpgradeUI();
    }

    private void UpgradeUI()
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
