using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadiationZone : MonoBehaviour, IRadiactive
{
    [SerializeField] private RadiationStat _radiatonStat;
    [SerializeField] private float _radiationCount = 5f;
    [SerializeField] private bool _inRadiationZone = false;
    private float _timer;
    

    public float GetRadiationCount() => _radiationCount;
    public void AddRadiation() => _radiatonStat.Increase(GetRadiationCount());

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            Debug.Log("Radiation");
            _inRadiationZone = true;
            RadiationIncrease(_inRadiationZone);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Radiation");
            _inRadiationZone = false;
            RadiationIncrease(_inRadiationZone);
        }
    }

    private void RadiationIncrease(bool value)
    {
        while(value)
        {
            _timer += Time.deltaTime;
            if (_timer >= 1f)
            {
                AddRadiation();
                _timer = 0f;
            }
        }
    }
}
