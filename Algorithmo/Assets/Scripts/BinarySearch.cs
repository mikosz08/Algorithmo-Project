using System;
using System.Collections.Generic;
using UnityEngine;

public class BinarySearch : MonoBehaviour
{
    private List<BinaryObject> dataset = null;

    public void SetData(List<GameObject> dataset)
    {
        this.dataset = new List<BinaryObject>();

        foreach (var _object in dataset)
        {
            this.dataset.Add(new BinaryObject(_object));
        }
        
        BinaryObject.nextNumber = 0;
    }

    public BinaryObject SearchFor(int searchedNumber)
    {
        var _left = 0;
        var _right = dataset.Count - 1;

        while (_left <= _right)
        {
            var _mid = (int)Math.Ceiling((_left + _right) / 2d);
            var _midObject = dataset[_mid];

            if (_midObject.Number == searchedNumber)
            {
                _midObject.Object.GetComponent<SpawnedPrefabManager>().ChangeColor(Color.green);
                return _midObject;
            }
            else if (_midObject.Number < searchedNumber)
            {
                _left = _mid + 1;
            }
            else
            {
                _right = _mid - 1;
            }

        }
        return null;
    }

    private void PrintDataset()
    {
        foreach (var d in dataset)
        {
            Debug.Log(d);
        }
    }

    public class BinaryObject
    {
        public GameObject Object { get; private set; } = null;
        public int Number { get; private set; } = 0;

        public static int nextNumber = 0;

        public BinaryObject(GameObject gameObject)
        {
            this.Object = gameObject;
            this.Number = nextNumber++;
        }

        public override string ToString()
        {
            return $"Prefab: {this.Object.name} Number: {this.Number}";
        }

    }

}
