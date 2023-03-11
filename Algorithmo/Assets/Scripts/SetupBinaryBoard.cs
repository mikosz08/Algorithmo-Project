using System.Collections;
using UnityEngine;
using System.Collections.Generic;

public class SetupBinaryBoard : MonoBehaviour
{

    private BinarySearch binarySearch;

    [SerializeField] private GameObject gameBallPrefab = null;
    [SerializeField] private Vector2 boardSize = Vector2.zero;
    [SerializeField] private Vector2 instantiateOffset = Vector2.right;
    [SerializeField] private Transform instantiateParent = null;

    [SerializeField] private bool shouldResetBoard = false;
    [SerializeField] private bool doneSetup = false;

    private List<GameObject> prefabList = null;

    private void Start()
    {
        SetUpBoard();
        binarySearch = GetComponent<BinarySearch>();
    }

    private void Update()
    {
        if (doneSetup && shouldResetBoard)
        {
            Reset();
        }
    }

    private void Reset()
    {
        foreach (var p in prefabList)
        {
            Destroy(p.gameObject);
        }
        shouldResetBoard = false;
        doneSetup = false;
        SetUpBoard();
    }

    private void SetUpBoard()
    {
        prefabList = new List<GameObject>();

        var position = transform.position;
        var startY = position.y;
        for (var x = 0; x < boardSize.x; ++x)
        {
            for (var y = 0; y < boardSize.y; ++y)
            {
                var prefab = Instantiate(gameBallPrefab, position, transform.rotation, instantiateParent);
                prefabList.Add(prefab);
                position.y += instantiateOffset.y;
            }
            position.x += instantiateOffset.x;
            position.y = startY;
        }
        StartCoroutine(ActivatePrefabs());
    }

    private IEnumerator ActivatePrefabs()
    {
        var tmpList = new List<GameObject>(prefabList);
        while (prefabList.Count > 0)
        {
            var randomIndex = Random.Range(0, prefabList.Count);
            var prefabToActivate = prefabList[randomIndex];

            prefabToActivate.SetActive(true);
            prefabList.Remove(prefabToActivate);
            yield return new WaitForSeconds(0.01f);
        }
        prefabList = tmpList;
        doneSetup = true;
    }
}
