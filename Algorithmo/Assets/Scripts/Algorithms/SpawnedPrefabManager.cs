using TMPro;
using UnityEngine;

public class SpawnedPrefabManager : MonoBehaviour
{
    [SerializeField] private Material prefabMaterial;

    private Color prefabColor = new Color(0, 0, 0);
    private Renderer prefabRenderer = null;
    private MeshRenderer prefabMeshRenderer = null;

    [SerializeField] public int PrefabIndex { get; set; }
    public TextMeshPro Label { get; set; }

    private void Awake()
    {
        prefabRenderer = GetComponent<Renderer>();
        prefabMeshRenderer = GetComponent<MeshRenderer>();
        prefabColor = prefabMaterial.color;


        prefabMeshRenderer.enabled = false;
    }

    public void ChangeColor(Color c)
    {
        prefabRenderer.material.color = c;
    }

    public void SetDefaultColor()
    {
        prefabRenderer.material.color = prefabColor;
    }

    public void Activate()
    {
        prefabRenderer.enabled = true;
        Label.GetComponent<MeshRenderer>().enabled = true;
    }

}
