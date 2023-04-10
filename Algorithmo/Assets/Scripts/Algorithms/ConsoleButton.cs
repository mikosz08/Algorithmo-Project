using UnityEngine;

public abstract class ConsoleButton : MonoBehaviour
{
    [SerializeField] private GameObject buttonCanvasText = null;

    public GameObject ButtonCanvasText { get => buttonCanvasText; set => buttonCanvasText = value; }

    private void Awake()
    {
        if (this.isActiveAndEnabled)
        {
            ButtonCanvasText.SetActive(false);
        }
    }

    public abstract void FireButton();

    public void ShowCanvasText(bool isVisible)
    {
        buttonCanvasText.SetActive(isVisible);
    }
}
