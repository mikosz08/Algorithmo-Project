using System.Data;
using System.Collections;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using TMPro;

public class BinaryBoardManager : MonoBehaviour
{
    /*Spawned object data set.*/
    public List<GameObject> PrefabsList { get; private set; } = null;

    /*Board setup.*/
    [SerializeField] private GameObject prefabToSpawn = null;
    [SerializeField] private Vector3 prefabToSpawnSize = new(1, 1, 1);
    [SerializeField] private Transform instantiateParent = null;
    [SerializeField] private Vector2 boardSize = Vector2.zero;
    [SerializeField] private Vector2 instantiateOffset = Vector2.right;
    [SerializeField] private TextMeshPro prefabIndexLabel = null;

    /*Coroutines*/
    private Coroutine boardActivationCoroutine = null;
    private Coroutine boardSetUpCoroutine = null;

    /*Checks*/
    public bool BoardSetupIsDone { get; private set; } = false;
    public bool BoardIsActivated { get; private set; } = false;

    public bool ShouldSetupTheBoard { get; internal set; } = false;
    public bool BinaryBoardCompleted { get; internal set; } = false;
    public bool ShouldStartSearching { get; internal set; } = false;

    public bool IsSearching { get; internal set; } = false;

    /*BinaryMonitor*/
    [SerializeField] private MonitorIndexManager monitorIndex = null;
    private MonitorIndexManager monitorIndexManager = null;

    /*BinarySearch*/
    [SerializeField] BinarySearch binarySearch = null;
    private static GameObject markedObject = null;

    private void Start()
    {
        prefabToSpawn.transform.localScale = prefabToSpawnSize;
        monitorIndexManager = monitorIndex.GetComponent<MonitorIndexManager>();
    }

    private void Update()
    {
        if (!BinaryBoardCompleted)
        {
            /*Board setup.*/
            CreateBoard();
        }
        else
        {
            /*Binary Search*/
            if (ShouldStartSearching && !IsSearching)
            {
                ShouldStartSearching = false;
                IsSearching = true;
                HandleSearching();
            }
        }
    }

    private void CreateBoard()
    {
        /*Creates the board.*/
        if (ShouldSetupTheBoard && !BoardSetupIsDone && boardSetUpCoroutine == null)
        {
            Debug.Log("Creating board.");
            boardSetUpCoroutine = StartCoroutine(SetUpBoard());
        }

        /*Activates the board.*/
        if (BoardSetupIsDone && !BoardIsActivated && boardActivationCoroutine == null)
        {
            Debug.Log("Activating board.");
            boardActivationCoroutine = StartCoroutine(ActivatePrefabsRandomly());
        }

        /*Index Monitor*/
        if (IsBoardReady() && !monitorIndexManager.IsReady)
        {
            var _maxIndexValue = PrefabsList.Count - 1;
            monitorIndex.TurnOn(_maxIndexValue);
            BinaryBoardCompleted = true;
            Debug.Log($"Index Monitor turned on: {monitorIndexManager.IsReady}.");
        }
    }

    private void HandleSearching()
    {
        Debug.Log($"Searching for: {monitorIndex.MonitorIndexValue}");
        binarySearch.BS_DataSet = PrefabsList;

        var _foundItem = binarySearch.SearchFor(monitorIndex.MonitorIndexValue);
        var _itemIndex = _foundItem.GetComponent<SpawnedPrefabManager>().PrefabIndex;
        Debug.Log($"Found {_foundItem.name}, [{_itemIndex}]");

        IsSearching = false;

        MarkItem(_itemIndex);
    }

    public void MarkItem(int index)
    {
        if (markedObject != null)
        {
            markedObject.GetComponent<SpawnedPrefabManager>().SetDefaultColor();
        }
        markedObject = GetBinaryObject(index);
        markedObject.GetComponent<SpawnedPrefabManager>().ChangeColor(Color.green);
    }

    public GameObject GetBinaryObject(int index)
    {
        return PrefabsList[index];
    }

    private bool IsBoardReady()
    {
        var _isBoardReady = BoardSetupIsDone && BoardIsActivated;
        return _isBoardReady;
    }

    private IEnumerator SetUpBoard()
    {
        PrefabsList = new List<GameObject>();

        var _transform = instantiateParent.transform;
        var _position = _transform.position;
        var _rotation = _transform.rotation;

        var _startY = _position.y;

        var _prefabIndex = 0;

        for (var x = 0; x < boardSize.x; ++x)
        {
            // Instantiate given prefabs, on given position and inside given parent:
            for (var y = 0; y < boardSize.y; ++y)
            {
                var _prefab = Instantiate(prefabToSpawn, _position, _rotation, instantiateParent);
                var _label = Instantiate(prefabIndexLabel, _prefab.transform);
                var prefabSpawnManager = _prefab.GetComponent<SpawnedPrefabManager>();

                _label.SetText(_prefabIndex.ToString());
                _label.rectTransform.localPosition = Vector3.forward;

                prefabSpawnManager.PrefabIndex = _prefabIndex++;
                prefabSpawnManager.Label = _label;

                PrefabsList.Add(_prefab);
                _position.y += instantiateOffset.y;
            }
            // Update next prefab's spawn position:
            _position.x += instantiateOffset.x;
            _position.y = _startY;
            yield return new WaitForEndOfFrame();
        }
        BoardSetupIsDone = true;
        yield return null;
    }

    private IEnumerator ActivatePrefabsRandomly()
    {
        var shuffledList = PrefabsList.OrderBy(x => Random.value).ToList();
        foreach (var prefab in shuffledList)
        {
            prefab.GetComponent<SpawnedPrefabManager>().Activate();
            yield return null;
        }
        BoardIsActivated = true;
    }
}
