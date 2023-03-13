using System.Reflection.Emit;
using UnityEngine;

public class SpawnedPrefabManager : MonoBehaviour
{

    [SerializeField] private Material baseMaterial;

    private void Start()
    {
        GetComponent<Renderer>().material.color = baseMaterial.color;
    }

    public void ChangeColor(Color c)
    {
        Debug.Log("Changing color");
        GetComponent<Renderer>().material.color = c;
    }

}
