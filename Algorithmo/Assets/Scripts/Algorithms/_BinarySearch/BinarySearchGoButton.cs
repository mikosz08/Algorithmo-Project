using UnityEngine;

public class BinarySearchGoButton : ConsoleButton
{
    [SerializeField] private SetupBinaryBoard setupBinaryBoard = null;

    public override void FireButton()
    {
        Debug.Log(gameObject.name + " Fired!!");
        setupBinaryBoard.BeginSetupBoard = true;
    }
}
