using System.Data;
using System.Collections;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class SetupBinaryBoard : MonoBehaviour
{
    private BinarySearch binarySearch;

    [SerializeField] private GameObject prefab = null;
    [SerializeField] private Transform instantiateParent = null;
    [SerializeField] private Vector3 prefabSize = new Vector3(1, 1, 1);
    [SerializeField] private Vector2 instantiateOffset = Vector2.right;
    [SerializeField] private Vector2 boardSize = Vector2.zero;
    [SerializeField] private bool shouldResetBoard = false;
    [SerializeField] private bool setupDone = false;

    private Vector3 boardPosition = Vector3.zero;

    private List<GameObject> prefabsList = null;

    private void Awake()
    {
        binarySearch = GetComponent<BinarySearch>();
    }

    private void Start()
    {
        SetUpBoard();
        StartCoroutine(ActivatePrefabs());
        binarySearch.SetData(prefabsList);
    }

    private void Update()
    {
        if (setupDone && shouldResetBoard)
        {
            Reset();
        }
    }

    private void Reset()
    {
        foreach (var p in prefabsList)
        {
            Destroy(p.gameObject);
        }
        prefabsList = null;
        shouldResetBoard = false;
        setupDone = false;
        Start();
    }

    private void SetUpBoard()
    {
        prefabsList = new List<GameObject>();

        var position = transform.position;
        var startY = position.y;

        for (var x = 0; x < boardSize.x; ++x)
        {
            // Instantiate given prefabs, on given position and inside given parent:
            for (var y = 0; y < boardSize.y; ++y)
            {
                var _prefab = Instantiate(prefab, position, transform.rotation, instantiateParent);
                prefabsList.Add(_prefab);
                position.y += instantiateOffset.y;
            }
            // Update next prefab's spawn position:
            position.x += instantiateOffset.x;
            position.y = startY;
        }
        var _index = prefabsList.Count - 1;
        var _boardXPos = prefabsList[_index].transform.position.x;
        transform.position = new Vector3(_boardXPos / -2, 0, transform.position.z);
    }

    private IEnumerator ActivatePrefabs()
    {
        var _tmpPrefabsList = new List<GameObject>(prefabsList);
        while (_tmpPrefabsList.Count > 0)
        {
            var _randomIndex = Random.Range(0, _tmpPrefabsList.Count);
            var _prefabToActivate = _tmpPrefabsList[_randomIndex];

            _prefabToActivate.SetActive(true);
            _tmpPrefabsList.Remove(_prefabToActivate);
            yield return new WaitForSeconds(0.001f);
        }
        setupDone = true;
    }
}
