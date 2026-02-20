using UnityEngine;

[CreateAssetMenu(menuName = "Data/Player/StateData")]
public class PlayerStateDataSO : ScriptableObject
{
    [Header("Movement")]
    public float MoveSpeed;
    public float ColliderHeight;

    [Header("Stealth")]
    public float NoiseMultiplier;

    [Header("Camera")]
    public float CameraHeight;

    [Header("Bob")]
    public float BobFrequency;
    public float BobAmplitude;
}
