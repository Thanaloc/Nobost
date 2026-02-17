using UnityEngine;

public class AIDetectionDebug : MonoBehaviour
{
    [SerializeField] private AIDetection _AIDetection;
    [SerializeField] private AISettingsSO _AISettingsSO;
    [SerializeField] private Transform _Eye1;
    [SerializeField] private Transform _Eye2;

    private void OnDrawGizmos()
    {
        Vector3 dirEye1 = Quaternion.AngleAxis(_AISettingsSO.DetectionAngle, Vector3.up) * _Eye1.forward;
        Vector3 dirEye2 = Quaternion.AngleAxis(-_AISettingsSO.DetectionAngle, Vector3.up) * _Eye2.forward;

        if (_AIDetection.IsPlayerDetected)
            Gizmos.color = Color.red;

        else Gizmos.color = Color.green;

        Gizmos.DrawWireSphere(_AIDetection.gameObject.transform.position, 1); 

        Gizmos.DrawLine(_Eye1.position, _Eye1.position + dirEye1 * _AISettingsSO.DetectionRange);
        Gizmos.DrawLine(_Eye2.position, _Eye2.position + dirEye2 * _AISettingsSO.DetectionRange);

    }
}
