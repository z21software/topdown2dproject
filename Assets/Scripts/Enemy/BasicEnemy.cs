using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float _movementSpeed = 2f;
    [SerializeField] private float _nodeReachThreshold = 0.1f;
    [SerializeField] private int _pathLength = 3; // ���������� ����� � ��������

    [Header("Damage")]
    [SerializeField] private int _enemyDamage = 1;
    [SerializeField] private GameObject _damagePopupPrefab;

    private PlayerBlinking _playerBlinking;
    private List<Transform> _pathNode = new List<Transform>();
    private int _currentNodeIndex;

    private void Awake()
    {
        _playerBlinking = FindObjectOfType<PlayerBlinking>();
        InitializePath();
    }

    private void InitializePath()
    {
        _pathNode = NodeManager.Instance.GetRandomNodes(_pathLength);

        if (_pathNode.Count > 0)
        {
            transform.position = _pathNode[0].position;
            _currentNodeIndex = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player")) return;

        HealthStat playerHealth = collision.GetComponent<HealthStat>();
        playerHealth?.Decrease(_enemyDamage);

        _playerBlinking?.StartBlinking();
        ShakeScreen.Instance?.Shake();
        SpawnDamagePopup(collision.transform.position);
        Destroy(gameObject);
    }

    private void SpawnDamagePopup(Vector3 position)
    {
        if (_damagePopupPrefab == null) return;
        Instantiate(_damagePopupPrefab, position, Quaternion.identity)
            .GetComponent<ScorePopup>();
    }

    private void Update()
    {
        if (_pathNode.Count == 0) return;
        MoveBetweenNodes();
    }

    private void MoveBetweenNodes()
    {
        Transform targetNode = _pathNode[_currentNodeIndex];
        transform.position = Vector3.MoveTowards(
            transform.position,
            targetNode.position,
            _movementSpeed * Time.deltaTime
        );

        if (Vector3.Distance(transform.position, targetNode.position) < _nodeReachThreshold)
        {
            // ����������� ������ �������� ����
            _currentNodeIndex++;

            // ���� �������� ���������� ���� � ��������, ���������� ����� �������
            if (_currentNodeIndex >= _pathNode.Count)
            {
                GenerateNewPath();
            }
        }
    }

    private void GenerateNewPath()
    {
        // ��������� ��������� ���� �������� �������� ��� ��������� ����� ������ ��������
        Transform lastNode = _pathNode[_pathNode.Count - 1];

        // �������� ����� ��������� �������
        _pathNode = NodeManager.Instance.GetRandomNodes(_pathLength);

        // ���� �������� ������ �������, ������ ������������
        if (_pathNode.Count == 0) return;

        // ������������� ��������� ������� ������ �������� � ������� ��������� �����
        // ������ ���� ������ �� ������� ���������, ����� ���������� ������������� ��������
        _pathNode[0] = lastNode;

        // ���������� ������ �������� ����
        _currentNodeIndex = 0;
    }

    private void OnDrawGizmos()
    {
        if (_pathNode == null || _pathNode.Count == 0)
            return;


        Gizmos.color = Color.red;
        for (int i = 0; i < _pathNode.Count - 1; i++)
        {
            Vector3 currentNode = _pathNode[i].position;
            Vector3 nextNode = _pathNode[i + 1].position;
            Gizmos.DrawLine(currentNode, nextNode);
            Gizmos.DrawSphere(currentNode, .2f);
        }

        if (_pathNode.Count > 0 && _pathNode[_pathNode.Count - 1] != null)
        {
            Gizmos.DrawSphere(_pathNode[_pathNode.Count - 1].position, .2f);
        }

        if(_currentNodeIndex < _pathNode.Count && _pathNode[_currentNodeIndex] != null)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawSphere(_pathNode[_currentNodeIndex].position, .3f);
        }
    }
}
