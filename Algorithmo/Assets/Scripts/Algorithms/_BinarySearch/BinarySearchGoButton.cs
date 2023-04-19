using UnityEngine;

public class BinarySearchGoButton : ConsoleButton
{
    [SerializeField] private BinaryBoardManager setupBinaryBoard = null;

    public override void FireButton()
    {
        setupBinaryBoard.ShouldSetupTheBoard = true;
    }
}
