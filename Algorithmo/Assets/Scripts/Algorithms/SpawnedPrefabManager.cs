using TMPro;
using UnityEngine;

public class SpawnedPrefabManager : MonoBehaviour
{
    [SerializeField] private Material prefabMaterial;

    private Renderer prefabRenderer = null;
    private MeshRenderer prefabMeshRenderer = null;

    public int PrefabIndex { get; set; }
    public TextMeshPro Label { get; set; }

    private void Awake()
    {
        prefabRenderer = GetComponent<Renderer>();
        prefabMeshRenderer = GetComponent<MeshRenderer>();

        prefabRenderer.material.color = prefabMaterial.color;
        prefabMeshRenderer.enabled = false;
    }

    public void ChangeColor(Color c)
    {
        prefabRenderer.material.color = c;
    }

    public void Activate()
    {
        prefabRenderer.enabled = true;


        Label.GetComponent<MeshRenderer>().enabled = true;
    }
}
