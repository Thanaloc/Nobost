using UnityEngine;

public class AIDetectionDebug : MonoBehaviour
{
    [SerializeField] private AIDetection _AIDetection;
    [SerializeField] private AISettingsSO _AISettingsSO;

    //lines for vision cone
    private void OnDrawGizmos()
    {
        Vector3 dir1 = Quaternion.AngleAxis(_AISettingsSO.DetectionAngle, Vector3.up) * transform.forward;
        Vector3 dir2 = Quaternion.AngleAxis(-_AISettingsSO.DetectionAngle, Vector3.up) * transform.forward;

        if (_AIDetection.IsPlayerDetected)
            Gizmos.color = Color.red;

        else Gizmos.color = Color.green;

        Gizmos.DrawWireSphere(_AIDetection.gameObject.transform.position, 1); 

        Gizmos.DrawLine(transform.position + Vector3.up * _AISettingsSO.EyeHeight, transform.position + Vector3.up * _AISettingsSO.EyeHeight + dir1 * _AISettingsSO.DetectionRange);
        Gizmos.DrawLine(transform.position + Vector3.up * _AISettingsSO.EyeHeight, transform.position + Vector3.up * _AISettingsSO.EyeHeight + dir2 * _AISettingsSO.DetectionRange);

    }

    //debug log for player detected / player lost events
    public void OnEventRaised(string p_eventName)
    {
        Debug.Log($"Event {p_eventName} raised !");
    }
}
