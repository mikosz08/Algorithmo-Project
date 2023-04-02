using UnityEngine;

public abstract class ConsoleButton : MonoBehaviour
{

    [SerializeField] private GameObject buttonCanvasText = null;

    private bool isActiveInHierarchy = false;

    public GameObject ButtonCanvasText { get => buttonCanvasText; set => buttonCanvasText = value; }
    public bool IsActiveInHierarchy { get => ButtonCanvasText.activeInHierarchy; set => isActiveInHierarchy = value; }

    private void Start()
    {
        ButtonCanvasText.SetActive(isActiveInHierarchy);
    }

    public abstract void FireButton();

    public void ShowCanvasText(bool isVisible)
    {
        buttonCanvasText.SetActive(isVisible);
    }

}
