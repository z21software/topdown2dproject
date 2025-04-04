using System.Collections.Generic;
using UnityEngine;

public class NodeManager : MonoBehaviour
{
    public static NodeManager Instance { get; private set; }
    [SerializeField] private List<Transform> _allNodes = new List<Transform>();
    // Start is called before the first frame update
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    public Transform GetRandomNode()
    {
        if(_allNodes.Count == 0)
        {
            Debug.Log("No nodes");
            return null;
        }
        return _allNodes[Random.Range(0, _allNodes.Count)];
    }

    public List<Transform> GetRandomNodes(int count)
    {
        List<Transform> selectedNodes = new List<Transform>();
        List<Transform> availableNodes = new List<Transform>(_allNodes);

        for(int i = 0; i < Mathf.Min(count, availableNodes.Count); i++)
        {
            int randomIndex = Random.Range(0, availableNodes.Count);
            selectedNodes.Add(availableNodes[randomIndex]);
            availableNodes.RemoveAt(randomIndex);
        }

        return selectedNodes;
    }
}
