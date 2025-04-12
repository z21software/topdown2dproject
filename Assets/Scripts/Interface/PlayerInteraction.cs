using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    [Header("Настройки")]
    [SerializeField] private float _interactionTime = 3f;
    [SerializeField] private float _cooldown = 5f;

    private IDrinkable _currentDrinkable;
    private bool _isInteracting;
    private bool _isCooldown;
    private Coroutine _drinkCoroutine;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out IDrinkable drinkable))
        {
            _currentDrinkable = drinkable;
            Debug.Log("Можно пить!");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.TryGetComponent(out IDrinkable _))
        {
            if (_drinkCoroutine != null)
            {
                StopCoroutine(_drinkCoroutine);
                _drinkCoroutine = null;
                _isInteracting = false;

                // Добавляем кулдаун после прерывания взаимодействия
                StartCoroutine(Cooldown());
                Debug.Log("Взаимодействие прервано. Нужно подождать перед следующей попыткой.");
            }

            _currentDrinkable = null;
            Debug.Log("Объект покинут");
        }
    }

    private void Update()
    {
        if (_currentDrinkable == null || _isCooldown) return;

        // Начинаем взаимодействие при нажатии клавиши
        if (Input.GetKeyDown(KeyCode.E) && !_isInteracting)
        {
            _drinkCoroutine = StartCoroutine(DrinkProcess());
        }

        // Прекращаем взаимодействие, если кнопка отпущена
        if (Input.GetKeyUp(KeyCode.E) && _isInteracting)
        {
            if (_drinkCoroutine != null)
            {
                StopCoroutine(_drinkCoroutine);
                _drinkCoroutine = null;
                _isInteracting = false;

                // Добавляем кулдаун после прерывания взаимодействия
                StartCoroutine(Cooldown());
                Debug.Log("Взаимодействие прервано. Нужно подождать перед следующей попыткой.");
            }
        }
    }

    private IEnumerator DrinkProcess()
    {
        _isInteracting = true;
        float timer = 0;

        while (timer < _interactionTime)
        {
            timer += Time.deltaTime;
            float progress = timer / _interactionTime * 100;
            Debug.Log($"Прогресс: {progress}%");
            yield return null;
        }

        _currentDrinkable.Drink(); // Вызов метода интерфейса
        StartCoroutine(Cooldown());
        _isInteracting = false;
        _drinkCoroutine = null;
    }

    private IEnumerator Cooldown()
    {
        _isCooldown = true;
        yield return new WaitForSeconds(_cooldown);
        _isCooldown = false;
    }
}
