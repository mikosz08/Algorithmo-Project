using UnityEngine;

public class BinarySearchSearchButton : ConsoleButton
{
    [SerializeField] private BinaryBoardManager setupBinaryBoard = null;

    public override void FireButton()
    {
        if (setupBinaryBoard.BinaryBoardCompleted)
            setupBinaryBoard.ShouldStartSearching = true;
    }
}
