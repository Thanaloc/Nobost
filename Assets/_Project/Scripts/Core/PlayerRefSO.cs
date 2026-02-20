using UnityEngine;

[CreateAssetMenu(menuName = "Core/PlayerRefSO")]
public class PlayerRefSO : ScriptableObject
{
    [Header("Runtime Variables")]
    public Transform PlayerTransform;
    public float NoiseRadius;

    [Header("Precompiled Variables")]
    public float PlayerEyeHeight = 1.0f;
    public float SprintFOVMultiplier = .17f;
}
