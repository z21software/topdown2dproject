using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinAnimation : MonoBehaviour
{
    private float _animationDuration = .5f;
    private float _timer = 0f;

    private void Start()
    {
        transform.localScale = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        if (_timer < _animationDuration)
        {
            _timer += Time.deltaTime;
            float scale = Mathf.Sin(_timer / _animationDuration * Mathf.PI / 2);
            transform.localScale = Vector3.one * scale;
        }
        else
        {
            Destroy(this); // Удалить компонент после анимации, чтобы не тратить ресурсы
        }
    }
}
