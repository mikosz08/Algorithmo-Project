using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using static BinarySearch;

public class BinarySearchTest
{
    // A Test behaves as an ordinary method
    // [Test]
    // public void BinarySearchTestSimplePasses()
    // {
    //     // Use the Assert class to test conditions
    // }

    [Test]
    public void BinarySearchTestResults()
    {
        List<GameObject> objects = new List<GameObject>();
        for (int i = 0; i < 1000; ++i)
        {
            objects.Add(new GameObject());
        }

        var _binarySearch = new GameObject().AddComponent<BinarySearch>();
        _binarySearch.SetData(objects);

        var _size = objects.Count - 1;
        var _searchMe = _binarySearch.SearchFor(0).Number;

        Assert.AreEqual(_searchMe, 0);
        Log($"{_searchMe} == 0");

        for (int i = _size; i > 0; --i)
        {
            var _random = UnityEngine.Random.Range(0, _size);
            _searchMe = _binarySearch.SearchFor(_random).Number;
            
            Assert.AreEqual(_searchMe, _random);
            Log($"{_searchMe} == {_random}");
        }

        _searchMe = _binarySearch.SearchFor(_size).Number;
        Assert.AreEqual(_searchMe, _size);
        Log($"{_searchMe} == {_size}");

    }

    private void Log(string s)
    {
        TestContext.Out.WriteLine(s);
    }

}
