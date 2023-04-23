using System;
using System.Collections.Generic;
using UnityEngine;

public class BinarySearch : MonoBehaviour
{
    public List<GameObject> BS_DataSet { get; set; }

    public GameObject SearchFor(int searchedNumber)
    {
        var _size = BS_DataSet.Count - 1;
        if (searchedNumber > _size)
        {
            Debug.Log("Searched Number is out of dataset bounds!");
            //return BinaryObject.Empty;
        }

        // L - - - - - R
        var _left = 0;
        var _right = _size;

        //         L <= R
        while (_left <= _right)
        {
            // L - - - M - - R
            var _mid = (int)Math.Ceiling((_left + _right) / 2.0d);
            var _currentIndex = GetIndex(_mid);

            if (_currentIndex == searchedNumber)
            {
                // M
                return BS_DataSet[_currentIndex];
            }
            else if (_currentIndex < searchedNumber)
            {
                // L M R
                _left = _mid + 1;
            }
            else
            {
                // L - M - R
                _right = _mid - 1;
            }

        }
        return null;
    }

    private int GetIndex(int index)
    {
        return BS_DataSet[index].GetComponent<SpawnedPrefabManager>().PrefabIndex;
    }


















    //private List<BinaryObject> dataset = null;

    //public void SetData(List<GameObject> objects)
    //{
    //    // Every time it should be a new list.
    //    this.dataset = new List<BinaryObject>();

    //    // Creates BinaryObject list from given objects.
    //    foreach (var _object in objects)
    //    {
    //        this.dataset.Add(new BinaryObject(_object));
    //    }

    //    // Resets BinaryObjects counter after the process is finished.
    //    BinaryObject.nextNumber = 0;
    //}

    //[SerializeField] private BinaryBoardManager binaryBoardManager = null;



    //public bool AbleToSearch { get; private set; } = false;

    //private void Start()
    //{
    //    BS_DataSet = binaryBoardManager.PrefabsList;
    //}



    //public void LogDataset()
    //{
    //    foreach (var d in dataset)
    //    {
    //        Debug.Log(d);
    //    }
    //}

    //public class BinaryObject
    //{
    //    public GameObject Object { get; private set; } = null;
    //    public int Number { get; private set; } = 0;

    //    public static int nextNumber = 0;

    //    public static BinaryObject Empty { get { return new BinaryObject(new GameObject(), -1); } }

    //    public BinaryObject(GameObject gameObject)
    //    {
    //        this.Object = gameObject;
    //        this.Number = nextNumber++;
    //    }

    //    public BinaryObject(GameObject gameObject, int number)
    //    {
    //        this.Object = gameObject;
    //        this.Number = number;
    //    }

    //    public override string ToString()
    //    {
    //        return $"Prefab: {this.Object.name} Number: {this.Number}";
    //    }
    //}

}
