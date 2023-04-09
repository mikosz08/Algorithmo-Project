using System.Data;
using System.Collections;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class SetupBinaryBoard : MonoBehaviour
{
    [SerializeField] private GameObject prefab = null;
    [SerializeField] private GameObject spawnPoint = null;
    [SerializeField] private Transform instantiateParent = null;
    [SerializeField] private Vector2 instantiateOffset = Vector2.right;
    [SerializeField] private Vector2 boardSize = Vector2.zero;
    [SerializeField] [Range(0.001f, 0.01f)] private float spawnDelay = 0.1f;

    private Coroutine boardActivationCoroutine = null;

    public List<GameObject> PrefabsList { get; private set; } = null;
    public bool BoardSetupIsDone { get; private set; } = false;
    public bool BoardIsActivated { get; private set; } = false;
    public bool ShouldSetupTheBoard { get; internal set; }

    private void Update()
    {
        if (ShouldSetupTheBoard && !BoardSetupIsDone)
        {
            SetUpBoard();
        }

        if (BoardSetupIsDone && !BoardIsActivated && boardActivationCoroutine == null)
        {
            boardActivationCoroutine = StartCoroutine(ActivatePrefabsRandomly());
        }
    }

    private void SetUpBoard()
    {
        PrefabsList = new List<GameObject>();

        var _position = spawnPoint.transform.position;
        var _rotation = spawnPoint.transform.rotation;
        var _startY = _position.y;

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
            _position.y = _startY;
        }
        BoardSetupIsDone = true;
    }

    private IEnumerator ActivatePrefabsRandomly()
    {
        var shuffledList = PrefabsList.OrderBy(x => Random.value).ToList();
        foreach (var prefab in shuffledList)
        {
            prefab.GetComponent<SpawnedPrefabManager>().Activate();
            yield return new WaitForSeconds(spawnDelay);
            //yield return null;
        }
        BoardIsActivated = true;
    }
}
