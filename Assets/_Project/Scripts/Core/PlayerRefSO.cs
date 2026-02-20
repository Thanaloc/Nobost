using UnityEngine;

[CreateAssetMenu(menuName = "Core/PlayerRefSO")]
public class PlayerRefSO : ScriptableObject
{
    public Transform PlayerTransform;
    public float NoiseRadius;
    public float PlayerEyeHeight = 1.0f;
}
