using System.Collections;
using UnityEngine;

public class SpawnedPrefabManager : MonoBehaviour
{

    [SerializeField] private Material prefabMaterial;
    private Renderer prefabRenderer;

    private void Awake()
    {
        prefabRenderer = GetComponent<Renderer>();
        prefabRenderer.material.color = prefabMaterial.color;
    }

    public void ChangeColor(Color c)
    {
        prefabRenderer.material.color = c;
    }

    public void Activate()
    {
        prefabRenderer.enabled = true;
    }
}