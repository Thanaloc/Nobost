using UnityEngine;

public class CameraHeadBob : MonoBehaviour
{
    [SerializeField] private CharacterController _CharacterController;
    [SerializeField] private Transform _CameraHolder;
    [SerializeField] private PlayerRefSO _Player;

    private float _timer = 0f;

    private void Update()
    {
        //if (_CharacterController.velocity.z > .2f)
        //{
        //    Debug.Log("bonjour");
        //    _timer += Time.deltaTime;
        //}

        //else
        //{
        //    if (_timer >= 1f)
        //        _timer -= Time.deltaTime;
        //}

        //_CameraHolder.position = new Vector3(_CameraHolder.position.x, _CameraHolder.position.y * Mathf.Sin(_timer * _Player.BobFrequency) * _Player.BobAmplitude, _CameraHolder.position.z);
    }
}
