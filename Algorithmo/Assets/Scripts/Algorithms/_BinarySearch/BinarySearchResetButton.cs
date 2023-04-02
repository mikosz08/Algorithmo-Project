using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BinarySearchResetButton : ConsoleButton
{
    public override void FireButton()
    {
        Debug.Log(gameObject.name + " Fired!!");
    }
}
