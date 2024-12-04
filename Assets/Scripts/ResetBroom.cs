using UnityEngine;

public class ResetBroom : MonoBehaviour
{
    [SerializeField] private GameObject _broom;
    private Vector3 _initialPosition;
    private Quaternion _initialRotation;

    private void Start()
    {
        if (_broom != null)
        {
            _initialPosition = _broom.transform.position;
            _initialRotation = _broom.transform.rotation;
        }
    }

    public void ResetToInitial()
    {
        if (_broom != null)
        {
            _broom.transform.position = _initialPosition;
            _broom.transform.rotation = _initialRotation;
        }
    }
}