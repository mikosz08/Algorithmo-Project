using System.Data;
using System.Collections;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class SetupBinaryBoard : MonoBehaviour
{
    private BinarySearch binarySearch;

    [SerializeField] private GameObject prefab = null;

    [SerializeField] private GameObject spawnPoint = null;

    [SerializeField] private Transform instantiateParent = null;
    [SerializeField] private Vector3 prefabSize = new Vector3(1, 1, 1);
    [SerializeField] private Vector2 instantiateOffset = Vector2.right;
    [SerializeField] private Vector2 boardSize = Vector2.zero;

    [SerializeField] private float spawnDelay = 0.1f;

    [SerializeField] public bool setupDone { get; private set; } = false;
    [SerializeField] public bool boardActivated { get; private set; } = false;

    private Vector3 boardPosition = Vector3.zero;
    private Coroutine activationCoroutine = null;

    public List<GameObject> PrefabsList { get; private set; } = null;

    private void Awake()
    {
        binarySearch = GetComponent<BinarySearch>();
    }

    private void Update()
    {
        if (setupDone && !boardActivated && activationCoroutine == null)
        {
            activationCoroutine = StartCoroutine(ActivatePrefabs());
        }
    }

    public void Go(){
        SetUpBoard();
        binarySearch.SetData(PrefabsList);
    }

    private void SetUpBoard()
    {
        PrefabsList = new List<GameObject>();

        var _position = spawnPoint.transform.position;
        var _rotation = spawnPoint.transform.rotation;
        var startY = _position.y;

        for (var x = 0; x < boardSize.x; ++x)
        {
            // Instantiate given prefabs, on given position and inside given parent:
            for (var y = 0; y < boardSize.y; ++y)
            {
                var _prefab = Instantiate(prefab, _position, _rotation, instantiateParent);
                PrefabsList.Add(_prefab);
                _position.y += instantiateOffset.y;
            }
            // Update next prefab's spawn position:
            _position.x += instantiateOffset.x;
            _position.y = startY;
        }
        var _index = PrefabsList.Count - 1;
        var _boardXPos = PrefabsList[_index].transform.position.x;
        setupDone = true;
    }

    private IEnumerator ActivatePrefabs()
    {
        var shuffledList = PrefabsList.OrderBy(x => Random.value).ToList();
        foreach (var prefab in shuffledList)
        {
            prefab.GetComponent<SpawnedPrefabManager>().Activate();
            yield return new WaitForSeconds(spawnDelay);
        }
        boardActivated = true;
    }
}
