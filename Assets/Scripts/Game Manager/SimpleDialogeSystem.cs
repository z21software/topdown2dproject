using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class SimpleDialogeSystem : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _dialogeText;
    [SerializeField] private Button _nextButton;
    [SerializeField] private AudioClip _clip;

    public string CurrentText
    {
        get => _dialogeText.text;
        set => _dialogeText.text = value;
    }

    private AudioSource _source;
    private int _currentLine = 0;
    private string[] _lines = { "Hello", "I'm simple dialoge text!", "Next click will destroy me =(" };
    private void Start()
    {
        _source = GetComponent<AudioSource>();
        CurrentText = _lines[_currentLine];
        _nextButton.onClick.AddListener(NextLine);
    }

    private void NextLine()
    {
        _currentLine++;
        _source.PlayOneShot(_clip, 1f);
        if (_currentLine < _lines.Length)
            CurrentText = _lines[_currentLine];
        else
            gameObject.SetActive(false);
    }
}
