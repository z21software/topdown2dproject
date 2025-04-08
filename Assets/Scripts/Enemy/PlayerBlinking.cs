using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerBlinking : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _spriteRenderer;
    private Color _originalColor;
    void Start()
    {
        _originalColor = _spriteRenderer.color;
    }

    // Update is called once per frame
    public void StartBlinking()
    {
        StartCoroutine(BlinkCoroutine());
    }

    private IEnumerator BlinkCoroutine()
    {
        for(int i = 0; i < 2; i++)
        {
            _spriteRenderer.color = Color.red;
            yield return new WaitForSeconds(.2f);
            _spriteRenderer.color = _originalColor;
            yield return new WaitForSeconds(.2f);
        }
    }
}
