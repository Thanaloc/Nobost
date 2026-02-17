using UnityEngine;

[CreateAssetMenu(menuName = "Data/AI/AISettings")]
public class AISettingsSO : ScriptableObject
{
    [Header("Config")]
    public float PatrolSpeed = 4.0f;
    public float WaitTime = 3.0f;

    [Header("Vision")]
    public float DetectionRange = 15.0f;
    public float DetectionAngle = 45f;

    [Header("Detection State Config")]
    public float ChaseSpeed = 6.0f;
    public float SearchTime = 5.0f;
}
