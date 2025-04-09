using System.Collections;
using UnityEngine;

public class ShakeScreen : MonoBehaviour
{
    public static ShakeScreen Instance { get; private set; }

    [Header("Settings")]
    [SerializeField] private float _shakePower = .1f;
    [SerializeField] private float _shakeDuration = .2f;

    private Vector3 _originalPosition;
    private bool _isShaking;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            _originalPosition = transform.localPosition;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Shake(float customDuration = -1)
    {
        if (_isShaking) return;
        StartCoroutine(ShakeCoroutine(customDuration > 0 ? customDuration : _shakeDuration));
    }

    private IEnumerator ShakeCoroutine(float duration)
    {
        _isShaking = true;
        float elapsed = 0f;

        while(elapsed < duration)
        {
            Vector3 randomOffset = Random.insideUnitSphere * _shakePower;
            transform.localPosition = _originalPosition + randomOffset;
            elapsed += Time.deltaTime;
            yield return null;
        }

        transform.localPosition = _originalPosition;
        _isShaking = false;
    }
}
