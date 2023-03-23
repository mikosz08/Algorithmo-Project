using UnityEngine;

public class BinarySearchButtons : MonoBehaviour
{
    [SerializeField] private GameObject goButtonHoverText = null;

    public bool IsActive { get { return goButtonHoverText.activeInHierarchy; } }

    private void Start()
    {
        goButtonHoverText.SetActive(false);
    }

    public void SwitchActive(bool isActive)
    {
        if (goButtonHoverText.activeInHierarchy == isActive)
        {
            return;
        }
        goButtonHoverText.SetActive(isActive);
    }



}
