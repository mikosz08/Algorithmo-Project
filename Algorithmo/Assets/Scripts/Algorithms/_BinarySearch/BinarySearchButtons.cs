using UnityEngine;

public class BinarySearchButtons : MonoBehaviour
{
    [SerializeField] private GameObject goButtonHoverText = null;
    [SerializeField] private SetupBinaryBoard setupBinaryBoard = null;

    public bool IsActive { get { return goButtonHoverText.activeInHierarchy; } }

    private void Start()
    {
        goButtonHoverText.SetActive(false);
    }

    private void Update() {
        if (IsActive && Input.GetKey(KeyCode.F)){
            setupBinaryBoard.BeginSetupBoard = true;
        }
    }

    public void SwitchActive(bool flag)
    {
        if (IsActive == flag)
        {
            return;
        }
        goButtonHoverText.SetActive(flag);
    }



}
